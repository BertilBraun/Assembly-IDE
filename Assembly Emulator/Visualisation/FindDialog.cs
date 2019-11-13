using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assembly_Emulator.Visualisation
{
    class FindDialog : Form
    {
        CheckBox matchCase, matchWholeWord, useRegex;

        public FindDialog()
        {
            Width = 330;
            Height = 160;
            Text = "Find in all Files";

            var textLabel = new Label() { Left = 10, Top = 10, Text = "Search Term :", Width = 90 };
            var inputBox = new TextBox() { Left = 100, Top = 10, Width = 200 };
            var search = new Button() { Text = "Find All", Left = 200, Width = 100, Top = 40 };

            matchCase = new CheckBox();
            matchCase.Location = new Point(10, 40);
            matchCase.Size = new Size(180, 20);
            matchCase.Text = "Match Case";

            matchWholeWord = new CheckBox();
            matchWholeWord.Location = new Point(10, 60);
            matchWholeWord.Size = new Size(180, 20);
            matchWholeWord.Text = "Match Whole Word";

            useRegex = new CheckBox();
            useRegex.Location = new Point(10, 80);
            useRegex.Size = new Size(180, 20);
            useRegex.Text = "Use Regular Expressions";

            search.Click += (_, __) => {
                if (Project.Solution.This != null)
                    DirSearch(Project.Solution.This.Directory, inputBox.Text);
                else
                    foreach (TabPageAdv p in DockingManagerForm.This.CodeTab.TabPages)
                        Find(p.Name, inputBox.Text);
            };

            Controls.Add(matchCase);
            Controls.Add(matchWholeWord);
            Controls.Add(useRegex);
            Controls.Add(search);
            Controls.Add(textLabel);
            Controls.Add(inputBox);
            ShowDialog();
        }

        void Find(string path, string st)
        {
            if (useRegex.Checked)
            {
                Regex regex;
                if (matchWholeWord.Checked && !matchCase.Checked)
                    regex = new Regex("\\b" + st + "\\b", RegexOptions.IgnoreCase);
                else if (matchWholeWord.Checked)
                    regex = new Regex("\\b" + st + "\\b");
                else if (!matchCase.Checked)
                    regex = new Regex(st, RegexOptions.IgnoreCase);
                else
                    regex = new Regex(st);

                try
                {
                    File.ReadAllLines(path).WithIndex()
                    .Where(kv => regex.IsMatch(kv.item)).ToList()
                    .ForEach(kv => DockingManagerForm.This.AddFind("File " + Path.GetFileName(path) + " Line " + kv.index + " : " + kv.item));
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    var lines = File.ReadAllLines(path).WithIndex();

                    if (!matchCase.Checked)
                        st = st.ToUpper();

                    if (matchWholeWord.Checked && !matchCase.Checked)
                        lines = lines.Where(kv => MatchesWholeWord(kv.item.ToUpper(), st));
                    else if (matchWholeWord.Checked)
                        lines = lines.Where(kv => MatchesWholeWord(kv.item, st));
                    else if (!matchCase.Checked)
                        lines = lines.Where(kv => kv.item.ToUpper().Contains(st));
                    else
                        lines = lines.Where(kv => kv.item.Contains(st));

                    lines.ToList().ForEach(kv => DockingManagerForm.This.AddFind("File " + Path.GetFileName(path) + " Line " + kv.index + " : " + kv.item));
                }
                catch (Exception) { }
            }
         }

        bool MatchesWholeWord(string item, string st)
        {
            var idx = item.IndexOf(st);

            if (idx == -1)
                return false;
            
            if (idx == 0 || char.IsLetterOrDigit(item[idx - 1]))
                if (idx + st.Length < item.Length || char.IsLetterOrDigit(item[idx + st.Length]))
                    return true;
            return false;
        }

        void DirSearch(string sDir, string st)
        {
            try
            {
                Directory.GetDirectories(sDir).ToList().ForEach(d => DirSearch(d, st));
                Directory.GetFiles(sDir).ToList().ForEach(f => Find(f, st));
            }
            catch (Exception) { }
        }
    }
}
