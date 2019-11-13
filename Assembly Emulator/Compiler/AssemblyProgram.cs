using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assembly_Emulator
{
    class ProgramData
    {
        public static void Reset()
        {
            ProgramCounter = 0;
            RAM = new Memory(4 * 1024);
            ROM = new Memory(4 * 1024);
            Stack = new Queue<int>();
        }
        public static void Init()
        {
            Reset();
            Commands = new List<Command>();
            Orgs = new Dictionary<string, int>();
            JumpPositions = new Dictionary<string, int>();
            Constants = new Dictionary<string, int>(Settings.Constants);
        }

        static public int ProgramCounter;

        static public Memory RAM, ROM;
        static public Queue<int> Stack;
        static public List<Command> Commands;
        static public Dictionary<string, int> Orgs, JumpPositions;
        static public Dictionary<string, int> Constants;
    }

    class AssemblyProgram
    {
        public AssemblyProgram(string path) : 
            this(GetContent(path))
        {
        }
        public AssemblyProgram(string[] content)
        {
            ProgramData.Init();
            new Parser().Create(content);
        }

        public async Task<bool> Run()
        {
            Command lastCommand = null;
            for (uint i = 0; ProgramData.ProgramCounter < ProgramData.Commands.Count; i++)
            {
                if (DockingManagerForm.This.Restart)
                {
                    ProgramData.Reset();
                    DockingManagerForm.This.Restart = false;
                }
                if (DockingManagerForm.This.Cancel)
                {
                    DockingManagerForm.This.Cancel = false;
                    return false;
                }
                if (DockingManagerForm.This.CanStep || DockingManagerForm.This.CanRun)
                {
                    ProgramData.Commands[ProgramData.ProgramCounter++].Run();
                    DockingManagerForm.This.Output();

                    if (!DockingManagerForm.This.CanRun)
                    {
                        DockingManagerForm.This.MarkLine(ProgramData.Commands[ProgramData.ProgramCounter].LineIdx);
                        DockingManagerForm.This.UnMarkLine(lastCommand.LineIdx);
                    }

                    lastCommand = ProgramData.Commands[ProgramData.ProgramCounter];
                    DockingManagerForm.This.CanStep = false;
                }

                if (i % 10 == 0) await Task.Delay(1);
            }
            return true;
        }

        public void Input(KeyEventArgs e)
        {
            ProgramData.RAM.Bit(Settings.Constants["P1.0"], e.KeyValue == '0');
            ProgramData.RAM.Bit(Settings.Constants["P1.1"], e.KeyValue == '1');
            ProgramData.RAM.Bit(Settings.Constants["P1.2"], e.KeyValue == '2');
            ProgramData.RAM.Bit(Settings.Constants["P1.3"], e.KeyValue == '3');
            ProgramData.RAM.Bit(Settings.Constants["P1.4"], e.KeyValue == '4');
            ProgramData.RAM.Bit(Settings.Constants["P1.5"], e.KeyValue == '5');
            ProgramData.RAM.Bit(Settings.Constants["P1.6"], e.KeyValue == '6');
            ProgramData.RAM.Bit(Settings.Constants["P1.7"], e.KeyValue == '7');

            ProgramData.RAM.Bit(Settings.Constants["P3.2"], e.KeyValue == 'P');
            ProgramData.RAM.Bit(Settings.Constants["P3.3"], e.KeyValue == 'O');

            if (ProgramData.RAM.Bit(Settings.Constants["EA"]) != 0)
            {
                Action<string> inter = (string s) =>
                {
                    if (ProgramData.Orgs.ContainsKey(s))
                    {
                        ProgramData.Stack.Enqueue(ProgramData.ProgramCounter);
                        ProgramData.ProgramCounter = ProgramData.Orgs[s];
                    }
                };
                Func<string, string, bool> set = (string f, string s) => {
                    return  ProgramData.RAM.Bit(Settings.Constants[f]) != 0 &&
                            ProgramData.RAM.Bit(Settings.Constants[s]) != 0;
                };
                Action<string, string, string> timer = (string f, string s, string org) => {
                    if (ProgramData.RAM.Byte(Settings.Constants[f]) == 255)
                    {
                        if (ProgramData.RAM.Byte(Settings.Constants[s]) == 255)
                            inter(org);
                        new INC { to = Settings.Constants[s] }.Run();
                    }
                    new INC { to = Settings.Constants[f] }.Run();
                };

                if (e.KeyValue == 'P' && set("EX0", "IT0"))
                    inter("0003H"); // Interrupt 0
                if (e.KeyValue == 'O' && set("EX1", "IT1"))
                    inter("0013H"); // Interrupt 1

                if (set("ET0", "TR0"))
                    timer("TL0", "TH0", "000BH"); // Interrupt T0

                if (set("ET1", "TR1"))
                    timer("TL1", "TH1", "001BH"); // Interrupt T1
            }
        }

        void Output()
        {
            Action<string, int, int> segment = (string s, int x, int y) => {

                var data = Convert.ToString(ProgramData.RAM.Byte(Settings.Constants[s]), 2).PadLeft(8, '0');

                Action<char, int, int> p = (char o, int x1, int y1) => {
                    Console.SetCursorPosition(x + x1, y + y1);
                    Console.Write(o);
                };

                p('+', 0, 0);
                p('+', 2, 0);
                p('+', 0, 2);
                p('+', 2, 2);
                p('+', 0, 4);
                p('+', 2, 4);

                if (data[0] == '1') p('.', 3, 4); else p(' ', 3, 4);
                if (data[1] == '1') p('-', 1, 2); else p(' ', 1, 2);
                if (data[2] == '1') p('|', 0, 1); else p(' ', 0, 1);
                if (data[3] == '1') p('|', 0, 3); else p(' ', 0, 3);
                if (data[4] == '1') p('-', 1, 4); else p(' ', 1, 4);
                if (data[5] == '1') p('|', 2, 3); else p(' ', 2, 3);
                if (data[6] == '1') p('|', 2, 1); else p(' ', 2, 1);
                if (data[7] == '1') p('-', 1, 0); else p(' ', 1, 0);
            };

            segment("P0", 5, 10);
            segment("P2", 15, 10);
        }

        static string[] GetContent(string path)
        {
            try
            {
                if (!File.Exists(path)) File.Create(path).Close();
                return File.ReadAllLines(path);
            }
            catch (Exception)
            {
                DockingManagerForm.This.AddError("Can't load File: " + path);
                return new string[] { };
            }
        }

    }
}
