using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assembly_Emulator
{
    class Parser
    {
        static string C = Settings.Constants["C"].ToString();
        static string A = Settings.Constants["A"].ToString();
        static char[] delim = new char[] { ' ', '\t', ',', ';' };
        
        int commandCount = 0;

        public void Create(string[] lines)
        {
            var tokens = new List<string[]>();
            var content = lines.Select(c => c.ToUpper());

            foreach (var c in content)
                tokens.Add(ParseTokens(c.Split(delim, StringSplitOptions.RemoveEmptyEntries)));

            for (int i = 0; i < tokens.Count; i++)
                if (tokens[i].Length == 0)
                    continue;
                else if (CommandDict.ContainsKey(tokens[i][0]))
                {
                    var kv = CommandDict[tokens[i][0]];

                    if (kv.Item1 != tokens[i].Length)
                        DockingManagerForm.This.AddError("Error [line: " + (i + 1) + "] : Unexpected amount of Tokens : " + String.Join(" ", tokens[i]));
                    else
                        kv.Item2(tokens[i], i);
                }
                else
                    DockingManagerForm.This.AddError("Error [line: " + (i + 1) + "] : Unknown Command : " + String.Join(" ", tokens[i]));
        }

        string[] ParseTokens(string[] tokens)
        {
            var cleanTokens = new List<string>();
            
            if (tokens.Length == 0)
                return cleanTokens.ToArray();

            foreach (var t in tokens)
            {
                string toAdd = t;
                if (t.Contains(';'))
                    toAdd = t.Substring(0, t.IndexOf(';'));

                if (toAdd.EndsWith(":"))
                {
                    ProgramData.JumpPositions.Add(toAdd.TrimEnd(':'), commandCount);
                    cleanTokens.Clear();
                    toAdd = "";
                }

                else if (toAdd[0] == '@' && ProgramData.Constants.ContainsKey(toAdd.Substring(1)))
                    toAdd = "@" + ProgramData.Constants[toAdd.Substring(1)].ToString();

                else if (ProgramData.Constants.ContainsKey(toAdd))
                    toAdd = ProgramData.Constants[toAdd].ToString();

                if (toAdd != "")
                    cleanTokens.Add(toAdd);

                if (t.Contains(';'))
                    break;
            }

            if (tokens.Length > 1 && tokens[1] == "EQE")
            {
                ProgramData.Constants.Add(tokens[0], ParseNumber(tokens[2]));
                cleanTokens.Clear();
            }

            if (tokens[0].Substring(1) == "INCLUDE")
            { 
                new Parser().Create(File.ReadAllLines(tokens[1].Replace('\"', ' ')));
                cleanTokens.Clear();
            }

            if (tokens.Length > 0 && CommandDict.Keys.Contains(tokens[0]))
                commandCount++;

            if (tokens[0] == "ORG")
            {
                ProgramData.Orgs[tokens[1]] = commandCount;
                cleanTokens.Clear();
            }

            if (tokens[0] == "DB")
            {
                ProgramData.ROM.Byte(commandCount * 8, ParseNumber(tokens[1]));
                cleanTokens.Clear();
            }

            return cleanTokens.ToArray();
        }

        static int ParseNumber(string t)
        {
            var number = t.ToUpper();

            try
            {
                if (number.EndsWith("B"))
                    return Convert.ToInt32(number.TrimEnd('B'), 2);

                if (number.EndsWith("H"))
                    return Convert.ToInt32(number.TrimEnd('H'), 16);

                return Convert.ToInt32(number, 10);
            }
            catch (Exception)
            {
                DockingManagerForm.This.AddError("Failed to parse Number: " + t);
                return 0;
            }
        }

        Dictionary<string, (int, Action<string[], int>)> CommandDict = new Dictionary<string, (int, Action<string[], int>)>
        {
            { "MOV", (3, (tokens, idx) =>
            {
                    if (tokens[1].StartsWith("@"))
                        ProgramData.Commands.Add(new MOV_AT_TO { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2].Substring(1)) });
                    else if (tokens[2].StartsWith("@"))
                        ProgramData.Commands.Add(new MOV_AT_FROM { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2].Substring(1)) });
                    else if (tokens[2].StartsWith("#"))
                        ProgramData.Commands.Add(new MOV_NUM { LineIdx = idx, to = ParseNumber(tokens[1]), num = ParseNumber(tokens[2].Substring(1)) });
                    else if (tokens[1] == C || tokens[2] == C)
                        ProgramData.Commands.Add(new MOV_B { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2]) });
                    else
                        ProgramData.Commands.Add(new MOV { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2]) });
            } ) },
            { "MOVX", (3, (tokens, idx) =>
            {
                    if (tokens[1].StartsWith("@"))
                        ProgramData.Commands.Add(new MOV_AT_TO { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2].Substring(1)) });
                    if (tokens[2].StartsWith("@"))
                        ProgramData.Commands.Add(new MOV_AT_FROM { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2].Substring(1)) });
            } ) },
            { "MOVC", ( 3, (tokens, idx) =>
            {
                    if (tokens[2] == "@A+DPTR")
                        ProgramData.Commands.Add(new MOV_DPTR { LineIdx = idx });
                    if (tokens[2] == "@A+PC")
                        ProgramData.Commands.Add(new MOV_PC { LineIdx = idx });
            } ) },
            { "XCH", ( 3, (tokens, idx) =>
            {
                    if (tokens[2].StartsWith("@"))
                        ProgramData.Commands.Add(new XCH_AT { LineIdx = idx, from = ParseNumber(tokens[2].Substring(1)) });
                    else
                        ProgramData.Commands.Add(new XCH { LineIdx = idx, from = ParseNumber(tokens[2]) });
            } ) },
            { "XCHD", ( 3, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new XCHD_AT { LineIdx = idx, from = ParseNumber(tokens[2].Substring(1)) });
            } ) },
            { "SWAP", ( 1, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new SWAP { LineIdx = idx });
            } ) },
            { "PUSH", ( 2, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new PUSH  { LineIdx = idx, from = ParseNumber(tokens[1]) });
            } ) },
            { "POP", ( 2, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new POP  { LineIdx = idx, to = ParseNumber(tokens[1]) });
            } ) },
            { "ANL", ( 3, (tokens, idx) =>
            {
                    if (tokens[1] == C)
                        ProgramData.Commands.Add(new ANL_B { LineIdx = idx, address = ParseNumber(tokens[2]) });
                    else if (tokens[2].StartsWith("@"))
                        ProgramData.Commands.Add(new ANL_AT { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2].Substring(1)) });
                    else if (tokens[2].StartsWith("#"))
                        ProgramData.Commands.Add(new ANL_NUM { LineIdx = idx, to = ParseNumber(tokens[1]), num = ParseNumber(tokens[2].Substring(1)) });
                    else
                        ProgramData.Commands.Add(new ANL { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2]) });
            } ) },
            { "ORL", ( 3, (tokens, idx) =>
            {
                    if (tokens[1] == C)
                        ProgramData.Commands.Add(new ORL_B { LineIdx = idx, address = ParseNumber(tokens[2]) });
                    else if (tokens[2].StartsWith("@"))
                        ProgramData.Commands.Add(new ORL_AT { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2].Substring(1)) });
                    else if (tokens[2].StartsWith("#"))
                        ProgramData.Commands.Add(new ORL_NUM { LineIdx = idx, to = ParseNumber(tokens[1]), num = ParseNumber(tokens[2].Substring(1)) });
                    else
                        ProgramData.Commands.Add(new ORL { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2]) });
            } ) },
            { "XRL", ( 3, (tokens, idx) =>
            {
                    if (tokens[2].StartsWith("@"))
                        ProgramData.Commands.Add(new XRL_AT { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2].Substring(1)) });
                    else if (tokens[2].StartsWith("#"))
                        ProgramData.Commands.Add(new XRL_NUM { LineIdx = idx, to = ParseNumber(tokens[1]), num = ParseNumber(tokens[2].Substring(1)) });
                    else
                        ProgramData.Commands.Add(new XRL { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2]) });
            } ) },
            { "CPL", ( 2, (tokens, idx) =>
            {
                    if (tokens[1] == A)
                        ProgramData.Commands.Add(new CPL_A { LineIdx = idx });
                    else
                        ProgramData.Commands.Add(new CPL_B { LineIdx = idx, address = ParseNumber(tokens[1])});
            } ) },
            { "CLR", ( 2, (tokens, idx) =>
            {
                    if (tokens[1] == A)
                        ProgramData.Commands.Add(new CLR_A { LineIdx = idx });
                    else
                        ProgramData.Commands.Add(new CLR_B { LineIdx = idx, address = ParseNumber(tokens[1])});
            } ) },
            { "SETB", ( 2, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new SETB { LineIdx = idx, address = ParseNumber(tokens[1])});
            } ) },
            { "ADD", ( 3, (tokens, idx) =>
            {
                    if (tokens[2].StartsWith("@"))
                        ProgramData.Commands.Add(new ADD_AT { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2].Substring(1)) });
                    else if (tokens[2].StartsWith("#"))
                        ProgramData.Commands.Add(new ADD_NUM { LineIdx = idx, to = ParseNumber(tokens[1]), num = ParseNumber(tokens[2].Substring(1)) });
                    else
                        ProgramData.Commands.Add(new ADD { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2]) });
            } ) },
            { "ADDC", ( 3, (tokens, idx) =>
            {
                    if (tokens[2].StartsWith("@"))
                        ProgramData.Commands.Add(new ADDC_AT { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2].Substring(1)) });
                    else if (tokens[2].StartsWith("#"))
                        ProgramData.Commands.Add(new ADDC_NUM { LineIdx = idx, to = ParseNumber(tokens[1]), num = ParseNumber(tokens[2].Substring(1)) });
                    else
                        ProgramData.Commands.Add(new ADDC { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2]) });
            } ) },
            { "INC", ( 2, (tokens, idx) =>
            {
                    if (tokens[1].StartsWith("@"))
                        ProgramData.Commands.Add(new INC_AT { LineIdx = idx, to = ParseNumber(tokens[1]) });
                    else
                        ProgramData.Commands.Add(new INC { LineIdx = idx, to = ParseNumber(tokens[1]) });
            } ) },
            { "SUBB", ( 3, (tokens, idx) =>
            {
                    if (tokens[2].StartsWith("@"))
                        ProgramData.Commands.Add(new SUBB_AT { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2].Substring(1)) });
                    else if (tokens[2].StartsWith("#"))
                        ProgramData.Commands.Add(new SUBB_NUM { LineIdx = idx, to = ParseNumber(tokens[1]), num = ParseNumber(tokens[2].Substring(1)) });
                    else
                        ProgramData.Commands.Add(new SUBB { LineIdx = idx, to = ParseNumber(tokens[1]), from = ParseNumber(tokens[2]) });
            } ) },
            { "DEC", ( 2, (tokens, idx) =>
            {
                    if (tokens[1].StartsWith("@"))
                        ProgramData.Commands.Add(new DEC_AT { LineIdx = idx, to = ParseNumber(tokens[1]) });
                    else
                        ProgramData.Commands.Add(new DEC { LineIdx = idx, to = ParseNumber(tokens[1]) });
            } ) },
            { "MUL", ( 1, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new MUL { LineIdx = idx });
            } ) },
            { "DIV", ( 1, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new DIV { LineIdx = idx });
            } ) },
            { "RL", ( 1, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new RL { LineIdx = idx });
            } ) },
            { "RR", ( 1, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new RR { LineIdx = idx });
            } ) },
            { "RLC", ( 1, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new RLC { LineIdx = idx });
            } ) },
            { "RRC", ( 1, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new RRC { LineIdx = idx });
            } ) },
            { "LJMP", ( 2, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new JMP { LineIdx = idx, to = ProgramData.JumpPositions[tokens[1]] });
            } ) },
            { "SJMP", ( 2, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new JMP { LineIdx = idx, to = ProgramData.Commands.Count + ParseNumber(tokens[1]) });
            } ) },
            { "AJMP", ( 2, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new JMP { LineIdx = idx, to = ProgramData.JumpPositions[tokens[1]] });
            } ) },
            { "JMP", ( 2, (tokens, idx) =>
            {
                    if (tokens[1] == "@A+DPTR")
                        ProgramData.Commands.Add(new JMP_A_DPTR { LineIdx = idx });
                    else
                        ProgramData.Commands.Add(new JMP { LineIdx = idx, to = ProgramData.JumpPositions[tokens[1]] });
            } ) },
            { "JC", ( 2, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new JB { LineIdx = idx, to = ProgramData.JumpPositions[tokens[1]], address = int.Parse(C) });
            } ) },
            { "JNC", ( 2, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new JNB { LineIdx = idx, to = ProgramData.JumpPositions[tokens[1]], address = int.Parse(C) });
            } ) },
            { "JB", ( 3, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new JB { LineIdx = idx, to = ProgramData.JumpPositions[tokens[1]], address = ParseNumber(tokens[2]) });
            } ) },
            { "JNB", ( 3, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new JNB { LineIdx = idx, to = ProgramData.JumpPositions[tokens[1]], address = ParseNumber(tokens[2]) });
            } ) },
            { "JBC", ( 3, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new JBC { LineIdx = idx, to = ProgramData.JumpPositions[tokens[1]], address = ParseNumber(tokens[2]) });
            } ) },
            { "JZ", ( 3, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new JComp_NUM { LineIdx = idx, to = ParseNumber(tokens[2]), compareTo = int.Parse(A), num = 0 });
            } ) },
            { "JNZ", ( 3, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new JNComp_NUM { LineIdx = idx, to = ParseNumber(tokens[2]), compareTo = int.Parse(A), num = 1 });
            } ) },
            { "CJNE", ( 4, (tokens, idx) =>
            {
                    if (tokens[1].StartsWith("@"))
                        ProgramData.Commands.Add(new JNComp_AT { LineIdx = idx, to = ParseNumber(tokens[3]), compareTo = ParseNumber(tokens[1]), num = ParseNumber(tokens[2]) });
                    else
                        ProgramData.Commands.Add(new JNComp { LineIdx = idx, to = ParseNumber(tokens[3]), compareTo = ParseNumber(tokens[2]), toCompare = ParseNumber(tokens[1]) });
            } ) },
            { "DJNZ", ( 3, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new DJNZ { LineIdx = idx, to = ParseNumber(tokens[2]), compareTo = ParseNumber(tokens[1]) });
            } ) },
            { "LCALL", ( 2, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new CALL { LineIdx = idx, to = ProgramData.JumpPositions[tokens[1]] });
            } ) },
            { "ACALL", ( 2, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new CALL { LineIdx = idx, to = ProgramData.JumpPositions[tokens[1]] });
            } ) },
            { "CALL", ( 2, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new CALL { LineIdx = idx, to = ProgramData.JumpPositions[tokens[1]] });
            } ) },
            { "RET", ( 1, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new RET { LineIdx = idx });
            } ) },
            { "RETI", ( 1, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new RETI { LineIdx = idx });
            } ) },


            { "PRINT", ( 2, (tokens, idx) =>
            {
					if (tokens[1].Contains('\"'))
						ProgramData.Commands.Add(new PRINT_STR { LineIdx = idx, str = tokens[1].Substring(1, tokens[1].Length - 1) });
					else
						ProgramData.Commands.Add(new PRINT { LineIdx = idx, address = ParseNumber(tokens[1]) });
            } ) },
            { "CLS", ( 1, (tokens, idx) =>
            {
                    ProgramData.Commands.Add(new CLS { LineIdx = idx });
            } ) }
        };
    }
}