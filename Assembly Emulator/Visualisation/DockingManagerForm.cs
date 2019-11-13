#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Edit;
using Syncfusion.Windows.Forms.Edit.Enums;
using Syncfusion.Windows.Forms.Edit.Implementation.Config;
using Syncfusion.Windows.Forms.Edit.Interfaces;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.XPMenus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace Assembly_Emulator
{
    public partial class DockingManagerForm : MetroForm
    {
        static public DockingManagerForm This { get; set; }
        
        #region Constructor
        public DockingManagerForm(string path)
        {
            This = this;
            InitialSolutionPath = path;

            InitializeComponent();

            DockingManager.SetAsMDIChild(CodeDockingPanel, true);
            KeyDown += keyDown;
            FormClosed += ClosedForm;
            KeyPreview = true;

            AddHeaderItem();
            AddToolsItem();
            AddItemsUnderFile();
            AddItemsUnderEdit();
            AddItemsUnderView();
            AddItemsUnderProject();
        }

        #endregion

        #region Variables
        History<(TabPageAdv, Point)> History = new History<(TabPageAdv, Point)>();
        List<string> CommandNames = new List<string>
        { 
            "MOV", "MOVX", "MOVC", "XCH", "XCHD", "SWAP", "PUSH", "POP", "ANL", "ORL", "XRL", 
            "CPL", "CLR", "SETB", "ADD", "ADDC", "INC", "SUBB", "DEC", "MUL", "DIV", "RL", "RR",
            "RLC", "RRC", "LJMP", "SJMP", "AJMP", "JMP", "JC", "JNC", "JB", "JNB", "JBC", "JZ",
            "JNZ", "CJNE", "DJNZ", "LCALL", "ACALL", "CALL", "RET", "RETI", "PRINT", "CLS"
        };

        SolutionExplorerView SolutionExplorerPanel = null;
        AssemblyProgram AssemblyProgram = null;

        Panel DisplayPanel = null, DebugPanel = null;
        string InitialSolutionPath;

        BarItem CreateBarItem(string name, int imgIdx, ImageList imgList = null, EventHandler click = null)
        {
            BarItem item = new BarItem();

            item.CategoryIndex = 1;
            item.ShowToolTipInPopUp = false;
            item.SizeToFit = true;
            item.Text = name;
            item.ImageIndex = imgIdx;

            if (imgList != null)
                item.ImageList = imgList;
            if (click != null)
                item.Click += click;

            return item;
        }

        ParentBarItem CreateParentBarItem(string name)
        {
            ParentBarItem item = new ParentBarItem();

            item.MetroColor = Color.FromArgb(253, 244, 191);
            item.CategoryIndex = 0;
            item.ShowToolTipInPopUp = false;
            item.SizeToFit = true;
            item.Text = name.ToUpper();
            item.WrapLength = 20;
            item.CustomTextFont = new Font("Microsoft Sans Serif", 9.0F);

            return item;
        }

        #endregion

        #region Add Items To Header

        ParentBarItem FileItem, EditItem, ViewItem, ProjectItem;

        private void AddHeaderItem()
        {
            Bar Header = new Bar(BarManager, "Header");
            Header.Caption = "Header";
            Header.DrawBackground += bar1_DrawBackground;
            Header.BarStyle = BarStyle.AllowQuickCustomizing | BarStyle.IsMainMenu | BarStyle.RotateWhenVertical | BarStyle.Visible | BarStyle.UseWholeRow;

            FileItem = CreateParentBarItem("File");
            EditItem = CreateParentBarItem("Edit");
            ViewItem = CreateParentBarItem("View");
            ProjectItem = CreateParentBarItem("Project");
            
            Header.Items.AddRange(new BarItem[] {
                FileItem,
                EditItem,
                ViewItem,
                ProjectItem
            });

            BarManager.Bars.Add(Header);
            BarManager.Categories.Add("Header");

            BarManager.Items.AddRange(Header.Items);
        }

        #endregion

        #region Add Items To Bars

        BarItem PauseItem, BreakItem, RestartItem, StepItem, StartItem, backItem, undoItem, nextItem, redoItem;

        private void AddToolsItem()
        {
            backItem = CreateBarItem("Navigate Backward (Ctrl+-)", 0, imageList2, BackClick);
            nextItem = CreateBarItem("Navigate Forward (Ctrl+Shift+-)", 1, imageList2, NextClick);

            StartItem = CreateBarItem("Start (F5)", 8, imageList2, Start);
            StartItem.PaintStyle = PaintStyle.ImageAndText;

            undoItem = CreateBarItem("Undo (Ctrl+Z)", 6, imageList2, Undo_Click);
            redoItem = CreateBarItem("Redo (Ctrl+Y)", 7, imageList2, Redo_Click);

            PauseItem = CreateBarItem("Pause (F10)", 8, imageList2, PauseClick);
            BreakItem = CreateBarItem("Break (Shift+F5)", 8, imageList2, BreakClick);
            RestartItem = CreateBarItem("Restart (Crtl+Shift+F5)", 8, imageList2, RestartClick);
            StepItem = CreateBarItem("Step (F11)", 8, imageList2, StepClick);

            PauseItem.Visible = BreakItem.Visible = RestartItem.Visible = StepItem.Visible = false;

            Bar ToolsBar = new Bar(BarManager, "Tools");
            ToolsBar.Caption = "Tools";

            ToolsBar.Items.AddRange(new BarItem[] {
            backItem,
            nextItem,
            CreateBarItem("Open File (Ctrl+O)", 3, imageList2, OpenFile),
            CreateBarItem("Save (Ctrl+S)", 4, imageList2, SaveFile),
            CreateBarItem("Save All (Ctrl+Shift+S)", 5, imageList2, SaveAllFiles),
            CreateBarItem("Find in Files (Ctrl+Shift+F)", 11, imageList2, FindFile),
            undoItem,
            redoItem,
            StartItem,
            CreateBarItem("Comment out the selected lines", 14, imageList2, CommentLine),
            CreateBarItem("Uncomment out the selected lines", 15, imageList2, UncommentLine),
            PauseItem,
            BreakItem,
            RestartItem,
            StepItem
            });
            ToolsBar.SeparatorIndices.AddRange(new int[] { 2, 6, 8, 9, 11 });

            BarManager.Bars.Add(ToolsBar);
            BarManager.Categories.Add("Tools");
            BarManager.Items.AddRange(ToolsBar.Items);
        }

        #endregion

        #region Items under FilebarItem

        public void AddItemsUnderFile()
        {
            FileItem.Items.AddRange(new BarItem[]{
                CreateBarItem("New                  (Ctrl+N)", 96, imageList1, NewFile),
                CreateBarItem("Open                 (Ctrl+O)", 3, imageList2, OpenFile),
                CreateBarItem("Save                 (Ctrl+S)", 4, imageList2, SaveFile),
                CreateBarItem("Save All            (Ctrl+Shift+S)", 5, imageList2, SaveAllFiles),
                CreateBarItem("Exit                   (Alt+F4)", 0, null, (_, __) => { Close(); })
            });

            FileItem.MetroBackColor = ColorTranslator.FromHtml("#eaf0ff");
            
            BarManager.Items.AddRange(FileItem.Items);
        }

        #endregion

        #region Items under EditbarItem

        BarItem undo, redo;

        public void AddItemsUnderEdit()
        {
            undo = CreateBarItem("Undo  (Crtl + Z)", 6, imageList2, Undo_Click);
            redo = CreateBarItem("Redo  (Crtl + Y)", 7, imageList2, Redo_Click);

            EditItem.Items.AddRange(new BarItem[]{
                undo,
                redo,
                CreateBarItem("Cut     (Crtl + X)", 39, imageList4, Cut_Click),
                CreateBarItem("Copy  (Crtl + C)", 35, imageList4, Copy_Click),
                CreateBarItem("Paste (Crtl + V)", 36, imageList4, Paste_Click)
            });

            BarManager.Items.AddRange(EditItem.Items);

            EditItem.MetroBackColor = ColorTranslator.FromHtml("#eaf0ff");
        }

        #endregion

        #region Items under View barItem

        public void AddItemsUnderView()
        {
            ViewItem.Items.Add(CreateBarItem("Debug Window", 0, null, (s, e) => { AddDebugWindow(); }));
            ViewItem.Items.Add(CreateBarItem("Display Window", 0, null, (s, e) => { AddDisplayWindow(); }));
            ViewItem.Items.Add(CreateBarItem("Solution Window", 0, null, (s, e) => { AddSolutionExplorer(Project.Solution.This.Path); }));
            ViewItem.Items.Add(CreateBarItem("Output Window", 0, null, (s, e) => { AddOutputWindow(); }));
            ViewItem.Items.Add(CreateBarItem("Find Window", 0, null, (s, e) => { AddFindWindow(); }));
            ViewItem.Items.Add(CreateBarItem("Immediate Window", 0, null, (s, e) => { AddImmediateWindow(); }));

            BarManager.Items.AddRange(ViewItem.Items);

            ViewItem.MetroBackColor = ColorTranslator.FromHtml("#eaf0ff");
        }

        #endregion

        #region Items under Project barItem

        public void AddItemsUnderProject()
        {
            ProjectItem.Items.Add(CreateBarItem("New Solution", 0, null, NewSolution));
            ProjectItem.Items.Add(CreateBarItem("Open Solution", 0, null, OpenSolution));
            ProjectItem.Items.Add(CreateBarItem("Add Project", 0, null, AddProject));

            BarManager.Items.AddRange(ProjectItem.Items);

            ProjectItem.MetroBackColor = ColorTranslator.FromHtml("#eaf0ff");
        }

        #endregion

        #region Display Window

        Dictionary<string, Label> OutputLabels;
        Label currentlyExecutingCodeLabel;

        public TextBox CodeOutputBox;
        TextBox OutputTextBox, Find, RAMTextBox;
        ComboBox OutputType;

        Panel ImmediatePanel, FindPanel, OutputPanel, SegmentPanel;

        void AddDebugWindow()
        {
            DebugPanel = AddPage("Debug Window", this, DockingStyle.Left);

            currentlyExecutingCodeLabel = new Label();
            currentlyExecutingCodeLabel.Location = new Point(20, 220);
            currentlyExecutingCodeLabel.Size = new Size(330, 30);
            currentlyExecutingCodeLabel.Font = new Font("Microsoft Sans Serif", 10.25F);

            OutputLabels = new Dictionary<string, Label>
            {
                { "A", new Label { Location = new Point(150, 150), Size = new Size(120, 20) } }
            };

            for (int i = 0; i < 8; i++)
                OutputLabels.Add("R" + i, new Label
                {
                    Location = new Point(20, 50 + i * 20),
                    Size = new Size(120, 20)
                });

            for (int i = 0; i < 4; i++)
                OutputLabels.Add("P" + i, new Label
                {
                    Location = new Point(150, 50 + i * 20),
                    Size = new Size(120, 20)
                });

            RAMTextBox = new TextBox();
            RAMTextBox.Enabled = false;
            RAMTextBox.Multiline = true;
            RAMTextBox.WordWrap = true;
            RAMTextBox.Size = new Size(300, 200);
            RAMTextBox.Location = new Point(20, 260);

            DebugPanel.Controls.Add(RAMTextBox);
            DebugPanel.Controls.Add(currentlyExecutingCodeLabel);
            DebugPanel.Controls.AddRange(OutputLabels.Values.ToArray());
        }
        void AddDisplayWindow()
        {
            DisplayPanel = AddPage("Display", this, DockingStyle.Left);
            DisplayPanel.TabIndex = 5;

            SegmentPanel = new Panel();
            SegmentPanel.Size = new Size(300, 100);
            SegmentPanel.Location = new Point(0, 250);
            SegmentPanel.Paint += OnPaint;
            typeof(Panel).InvokeMember("DoubleBuffered", 
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, SegmentPanel, new object[] { true });

            new FlowLayout(DisplayPanel.Container);

            CodeOutputBox = new TextBox();
            CodeOutputBox.Enabled = false;
            CodeOutputBox.Multiline = true;
            CodeOutputBox.WordWrap = true;
            CodeOutputBox.ScrollBars = ScrollBars.Horizontal;
            CodeOutputBox.Size = new Size(300, 200);
            CodeOutputBox.Location = new Point(10, 35);

            Label label = new Label();
            label.Text = "Code Output:";
            label.Location = new Point(10, 10);
            label.Font = new Font("Microsoft Sans Serif", 10.25F);

            DisplayPanel.Controls.Add(SegmentPanel);
            DisplayPanel.Controls.Add(label);
            DisplayPanel.Controls.Add(CodeOutputBox);
        }

        void AddSolutionExplorer(string path = null)
        {
            SolutionExplorerPanel = new SolutionExplorerView();
            if (path != null)
                SolutionExplorerPanel.LoadSolution(path);

            DockingManager.SetEnableDocking(SolutionExplorerPanel, true);
            DockingManager.SetDockLabel(SolutionExplorerPanel, "Solution Explorer");
            DockingManager.DockControl(SolutionExplorerPanel, this, DockingStyle.Right, 250);
        }
        void AddOutputWindow()
        {
            OutputPanel = AddPage("Output", this, DockingStyle.Bottom);

            OutputTextBox = new TextBox();
            OutputType = new ComboBox();

            OutputTextBox.BackColor = Color.WhiteSmoke;
            OutputTextBox.Dock = DockStyle.Fill;
            OutputTextBox.Multiline = true;
            OutputTextBox.TabIndex = 4;
            OutputTextBox.WordWrap = false;
            OutputTextBox.ScrollBars = ScrollBars.Both;

            OutputType.BackColor = Color.FromArgb(17, 158, 218);
            OutputType.Dock = DockStyle.Top;
            OutputType.TabIndex = 3;
            OutputType.Text = "Debug";
            OutputType.Items.Add("Debug");
            OutputType.Items.Add("Release");

            OutputPanel.Controls.Add(OutputTextBox);
            OutputPanel.Controls.Add(OutputType);
            OutputPanel.TabIndex = 12;
        }
        void AddFindWindow()
        {
            FindPanel = AddPage("Find Symbol Results", this, DockingStyle.Bottom);

            Find = new TextBox();

            Find.BackColor = Color.WhiteSmoke;
            Find.Dock = DockStyle.Fill;
            Find.Multiline = true;
            Find.TabIndex = 1;

            FindPanel.Controls.Add(Find);
            FindPanel.TabIndex = 9;
        }
        void AddImmediateWindow()
        {
            ImmediatePanel = AddPage("Immediate", this, DockingStyle.Bottom);
            ImmediatePanel.Controls.Add(dwTaskListView);
            ImmediatePanel.Controls.Add(errorlistToolBar);
            ImmediatePanel.TabIndex = 6;
        }

        #endregion

        #region Events
        void DockingManagerForm_Load(object sender, EventArgs e)
        {
            AddSolutionExplorer(InitialSolutionPath);

            AddOutputWindow();
            AddFindWindow();
            AddImmediateWindow();
            
            AddDebugWindow();
            AddDisplayWindow();

            Output();
            CanBackNextChange();

            DockingManager.DockControl(DebugPanel, DisplayPanel, DockingStyle.Tabbed, 350);
            DockingManager.SetTabPosition(DisplayPanel, 0);

            DockingManager.DockControl(OutputPanel, this, DockingStyle.Bottom, 150);
            DockingManager.DockControl(FindPanel, OutputPanel, DockingStyle.Tabbed, 150);
            DockingManager.DockControl(ImmediatePanel, OutputPanel, DockingStyle.Tabbed, 150);
            DockingManager.SetTabPosition(OutputPanel, 0);

            AddCodePage(@"C:\Users\Braun\Desktop\Test Solution\Test Solution\Program.as"); // TODO remove
        }

        void bar1_DrawBackground(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(219, 223, 249)), e.ClipRectangle);
        }

        private Panel AddPage(string title, Control parent, DockingStyle docking, string dockAbility = "Left, Right, Vertical")
        {
            Panel panel = new Panel();
            CaptionButtonsCollection captionButtons = new CaptionButtonsCollection();

            DockingManager.SetEnableDocking(panel, true);
            DockingManager.SetDockLabel(panel, title);
            DockingManager.SetDockAbility(panel, dockAbility);
            DockingManager.SetOuterDockAbility(panel, dockAbility);
            captionButtons.MergeWith(DockingManager.CaptionButtons, false);
            DockingManager.SetCustomCaptionButtons(panel, captionButtons);
            parent.Visible = true;
            panel.Visible = true;
            DockingManager.DockControl(panel, parent, docking, 350);

            return panel;
        }

        public void AddCodePage(string path)
        {
            string fileName = Path.GetFileName(path);

            for (int i = 0; i < CodeTab.TabCount; i++)
                if (CodeTab.TabPages[i].Text == fileName)
                {
                    CodeTab.SelectedIndex = i;
                    return;
                }

            EditControl tb = new EditControl();
            tb.AllowZoom = true;
            tb.ChangedLinesMarkingLineColor = Color.FromArgb(255, 238, 98);
            tb.ContextChoiceBorderColor = Color.FromArgb(233, 160, 50);
            tb.Dock = DockStyle.Fill;
            tb.IndicatorMarginBackColor = Color.Empty;
            tb.Margin = new Padding(6);
            tb.MarkerAreaWidth = 20;
            tb.ScrollVisualStyle = ScrollBarCustomDrawStyles.Metro;
            tb.SelectionTextColor = Color.FromArgb(173, 214, 255);
            tb.ShowHorizontalSplitters = false;
            tb.ShowOutliningCollapsers = false;
            tb.ShowSelectionMargin = false;
            tb.ShowVerticalSplitters = false;
            tb.Size = new Size(508, 310);
            tb.StatusBarSettings.CoordsPanel.Width = 298;
            tb.StatusBarSettings.EncodingPanel.Width = 198;
            tb.StatusBarSettings.FileNamePanel.Width = 198;
            tb.StatusBarSettings.InsertPanel.Width = 64;
            tb.StatusBarSettings.StatusPanel.Width = 138;
            tb.StatusBarSettings.TextPanel.Width = 426;
            tb.TabIndex = 20;
            tb.MarkChangedLines = true;
            tb.AutoIndentMode = AutoIndentMode.Block;
            tb.EnableSmartInBlockIndent = true;
            tb.HighlightCurrentLine = true;
            tb.CurrentLineHighlightColor = Color.Orange;
            tb.SelectOnLineNumberClick = true;
            tb.FileName = fileName;
            tb.FilterAutoCompleteItems = true;
            tb.ContextChoiceOpen += ContextChoiceOpen;
            tb.ContextChoiceClose += ContextChoiceClose;
            tb.ContextChoiceSelectedTextInsert += ContextChoiceSelectedTextInsert;

            LoadEditControl(tb, path);

            try
            {
                TabPageAdv page = new TabPageAdv(fileName + " ");
                page.Name = path;
                page.Controls.Add(tb);
                page.Location = new Point(0, 30);
                page.Margin = new Padding(6);
                page.Size = new Size(508, 310);
                page.TabForeColor = SystemColors.InfoText;
                page.TabIndex = 1;

                tb.TextChanged += (_, __) =>
                {
                    CanUndoRedoChange(tb);

                    if (!tb.CanUndo)
                        page.Text = page.Text.TrimEnd('*');
                    else if (!page.Text.EndsWith("*"))
                        page.Text += "*";
                };
                tb.CursorPositionChanged += (_, __) =>
                {
                    if (addToHistory)
                        History.Add((page, tb.CurrentPosition));
                    CodeTab.SelectedTab = page;
                    addToHistory = true;
                    CanBackNextChange();
                };

                CodeTab.TabPages.Add(page);
                CodeTab.SelectedTab = page;
                CanUndoRedoChange(false, false);
            }
            catch (Exception)
            {
                AddOutput("Failed to Add Tab Page: " + path);
            }
        }
        bool addToHistory = true;

        void LoadEditControl(EditControl tb, string path)
        {

            if (!File.Exists(path))
            {
                AddOutput("File doesn't exist : " + path);
                return;
            }

            try
            {
                var ext = Path.GetExtension(path);

                if (ext == ".as" || ext == ".ae")
                    AddConfig(tb, File.ReadAllLines(path));
                else
                {
                    var lng = tb.Configurator.GetLanguage(Path.GetExtension(path).Substring(1));
                    if (lng != null)
                        tb.ApplyConfiguration(lng);
                }
            }
            catch (Exception)
            {
                AddOutput("Failed to Add Configuration : " + Path.GetExtension(path));
                return;
            }

            try
            {
                tb.LoadFile(path);
                tb.ShowIndentationGuidelines = true;
                tb.OnlyHighlightMatchingBraces = true;
            }
            catch (Exception)
            {
                try
                {
                    if (tb.Text == "")
                        tb.Text = File.ReadAllText(path);
                    tb.FlushChanges();
                }
                catch (Exception)
                {
                    AddOutput("Failed to load File: " + path);
                    return;
                }
            }
        }

        void ContextChoiceOpen(IContextChoiceController controller)
        {
            foreach (var name in CommandNames)
                if (name.StartsWith(controller.Dropper.Text.ToUpper()))
                    controller.Items.Add(name);

            foreach (var kv in ProgramData.Constants)
                if (kv.Key.StartsWith(controller.Dropper.Text.ToUpper()))
                    controller.Items.Add(kv.Key);

            foreach (var kv in ProgramData.JumpPositions)
                if (kv.Key.StartsWith(controller.Dropper.Text.ToUpper()))
                    controller.Items.Add(kv.Key);
        }
        void ContextChoiceClose(IContextChoiceController controller, DialogResult result)
        {
            controller.Items.Clear();
        }
        void ContextChoiceSelectedTextInsert(IContextChoiceController controller, ContextChoiceTextInsertEventArgs e)
        {
            e.InsertText = e.InsertText.Replace(controller.Dropper.Text.ToUpper(), "");

            if (controller.Dropper.Text.Length > 0 && char.IsLower(controller.Dropper.Text[0]))
                    e.InsertText = e.InsertText.ToLower();
        }

        void AddConfig(EditControl control, string[] text)
        {
            ProgramData.Init();
            new Parser().Create(text);

            var lng = control.Configurator.CreateLanguageConfiguration("Assembly");
            control.ApplyConfiguration(lng);

            control.Language.StartComment = ";";
            control.Language.CaseInsensitive = true;
            control.Language.Extensions.Add("as");
            control.Language.Extensions.Add("ae");

            var JumpLoc = control.Language.Add("JumpLoc");
            var Variable = control.Language.Add("Variable");
            var Operator = control.Language.Add("Operator");
            var KeyWord = control.Language.Add("KeyWord");
            var Comment = control.Language.Add("Comment");

            JumpLoc.Font = new Font("Consolas", 10);
            JumpLoc.FontColor = Color.Red;

            Variable.Font = new Font("Consolas", 10);
            Variable.FontColor = Color.LightSkyBlue;

            Operator.Font = new Font("Consolas", 10);
            Operator.FontColor = Color.Black;

            KeyWord.Font = new Font("Consolas", 10);
            KeyWord.FontColor = Color.Blue;

            Comment.Font = new Font("Consolas", 10);
            Comment.FontColor = Color.Gray;
            Comment.BackColor = Color.LightGray;

            var CommentLexem = new ConfigLexem(";", "\n", FormatType.Custom, true);

            CommentLexem.DropContextChoiceList = false;
            CommentLexem.FormatName = "Comment";
            control.Language.Lexems.Add(CommentLexem);
            
            AddLexem(",", "Operator", control);
            AddLexem(":", "Operator", control);
            AddLexem("@", "Operator", control);
            AddLexem("#", "Operator", control);

            foreach (var kv in ProgramData.Constants)
                AddLexem(kv.Key, "Variable", control);

            foreach (var kv in ProgramData.JumpPositions)
                AddLexem(kv.Key, "JumpLoc", control);
            
            foreach (var kv in ProgramData.Orgs)
                AddLexem(kv.Key, "JumpLoc", control);

            foreach (var name in CommandNames)
                AddLexem(name, "KeyWord", control);

            control.Language.ResetCaches();
        }

        void AddLexem(string begin, string keyword, EditControl control)
        {
            if (control.Language.Lexems.ToArray().Any(x => (x as ConfigLexem).BeginBlock == begin))
                return;

            for (int i = 1; i < begin.Length; i++)
                AddLexem(String.Join("", begin.Take(i)), "", control);

            var lexem = new ConfigLexem(begin, "", keyword != "" ? FormatType.Custom : FormatType.Text, false);

            lexem.DropContextChoiceList = true;
            lexem.FormatName = keyword;
            control.Language.Lexems.Add(lexem);
        }

        public void MarkLine(int line)
        {
            var tb = CodeTab.SelectedTab.Controls[0] as EditControl;

            var format = tb.RegisterBackColorFormat(Color.FromArgb(50, 255, 0, 0), Color.FromArgb(50, 255, 0, 0), System.Drawing.Drawing2D.HatchStyle.Percent50, true);
            tb.SetLineBackColor(line + 1, true, format);
        }

        public void UnMarkLine(int line)
        {
            (CodeTab.SelectedTab.Controls[0] as EditControl).RemoveLineBackColor(line + 1);
        }

        public void AddError(string err)
        {
            ListViewItem item = new ListViewItem(
                new string[] { dwTaskListView.Items.Count.ToString(), ">", err },
                -1, Color.Red, SystemColors.Window, Font);

            item.Checked = true;
            item.StateImageIndex = 1;
            dwTaskListView.Items.Add(item);

            CanRun = false;
            DockingManager.ActivateControl(ImmediatePanel);
        }

        public void AddWarning(string err)
        {
            ListViewItem item = new ListViewItem(
                new string[] { dwTaskListView.Items.Count.ToString(), "", err }, 
                -1, Color.Gold, SystemColors.Window, Font);

            item.Checked = true;
            item.StateImageIndex = 1;
            dwTaskListView.Items.Add(item);
        }

        public void AddFind(string err)
        {
            Find.AppendText(err + "\r\n");
        }

        public void AddOutput(string err)
        {
            OutputTextBox.AppendText(err + "\r\n");
        }

        public void ClrError()
        {
            dwTaskListView.Items.Clear();
        }

        public void ClrOutput()
        {
            OutputTextBox.ResetText();
        }

        #endregion

        #region Clicks

        public bool CanRun, CanStep, Cancel, Restart;

        private async void Start(object sender, EventArgs e)
        {
            if (AssemblyProgram != null)
            {
                PauseItem.Enabled = true;
                StepItem.Enabled = false;
                StartItem.Enabled = false;
                CanRun = true;
                return;
            }

            SaveAllFiles(null, null);

            StartItem.Enabled = false;
            StartItem.Text = "Continue";
            StartItem.Tooltip = "Continue (F5)";
            ClrOutput();
            ClrError();
            AddOutput("Starting Compilation...");

            CanStep = false;
            CanRun = true;
            Cancel = false;
            Restart = false;
            StepItem.Enabled = false;
            Stopwatch sw = Stopwatch.StartNew();

            AssemblyProgram = new AssemblyProgram((CodeTab.SelectedTab.Controls[0] as EditControl).Lines);

            AddOutput("Compilation took: " + sw.Elapsed.TotalSeconds + "s");

            if (CanRun)
            {
                PauseItem.Visible = BreakItem.Visible = RestartItem.Visible = StepItem.Visible = true;

                AddOutput("Compilation Suceeded! Now running Program.");
                sw.Restart();

                await AssemblyProgram.Run();

                PauseItem.Visible = BreakItem.Visible = RestartItem.Visible = StepItem.Visible = false;

                AddOutput("Program Finished in " + sw.Elapsed.TotalSeconds + "s.");
            }
            else
                AddOutput("Compilation Error! Can't run Program.");
            AssemblyProgram = null;

            StartItem.Text = "Start";
            StartItem.Tooltip = "Start (F5)";
            StartItem.Enabled = true;
        }

        public void Output()
        {
            if (ProgramData.Commands != null && ProgramData.Commands.Count > ProgramData.ProgramCounter)
                currentlyExecutingCodeLabel.Text = "Currently Executing Code: " + ProgramData.Commands[ProgramData.ProgramCounter].Desc();
            else
                currentlyExecutingCodeLabel.Text = "Currently Executing Code: None";

            foreach (var it in OutputLabels)
                if (ProgramData.RAM != null)
                    it.Value.Text = it.Key + " : " + Convert.ToString(ProgramData.RAM.Byte(Settings.Constants[it.Key]), 2).PadLeft(8, '0') + "b";
                else
                    it.Value.Text = it.Key + " : 00000000b";

            if (CodeOutputBox.TextLength > 5000)
                CodeOutputBox.Text = CodeOutputBox.Text.Substring(CodeOutputBox.TextLength - 4500);

            if (ProgramData.RAM != null)
                RAMTextBox.Text = BitConverter.ToString(ProgramData.RAM.data.Take(300).ToArray());
            else
                RAMTextBox.Text = "No RAM loaded";

            SegmentPanel.Refresh();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);

            int x = 20, y = 20, w = 3, h = 25;
            string b1 = "P3.4", b2 = "P3.5", p1 = "P2", p2 = "P0";

            if (ProgramData.RAM != null)
            {
                byte display = (ProgramData.RAM.Bit(Settings.Constants[b2]) == 0) ? (byte)0 : ProgramData.RAM.Byte(Settings.Constants[p1]);

                SegmentDisplay.DrawSegments(e.Graphics, Color.Black, display, x + 40 * 0, y, w, h);

                display = (ProgramData.RAM.Bit(Settings.Constants[b1]) == 0) ? (byte)0 : ProgramData.RAM.Byte(Settings.Constants[p1]);

                SegmentDisplay.DrawSegments(e.Graphics, Color.Black, display, x + 40 * 1, y, w, h);

                display = (ProgramData.RAM.Bit(Settings.Constants[b2]) == 0) ? (byte)0 : ProgramData.RAM.Byte(Settings.Constants[p2]);

                SegmentDisplay.DrawSegments(e.Graphics, Color.Black, display, x + 40 * 2, y, w, h);

                display = (ProgramData.RAM.Bit(Settings.Constants[b1]) == 0) ? (byte)0 : ProgramData.RAM.Byte(Settings.Constants[p2]);

                SegmentDisplay.DrawSegments(e.Graphics, Color.Black, display, x + 40 * 3, y, w, h);
            }
            else
                for (int i = 0; i < 4; i++)
                    SegmentDisplay.DrawSegments(e.Graphics, Color.Black, 0, x + 40 * i, y, w, h);
        }

        private void SaveAllFiles(object sender, EventArgs e)
        {
            foreach (TabPageAdv tab in CodeTab.TabPages)
                SaveEditControl(tab);
        }

        private void SaveFile(object sender, EventArgs e)
        {
            SaveEditControl(CodeTab.SelectedTab);
        }

        void SaveEditControl(TabPageAdv tab)
        {
            if (tab != null && tab.Controls.Count > 0)
            {
                try
                {
                    (tab.Controls[0] as EditControl).SaveFile(tab.Name, Syncfusion.IO.NewLineStyle.Windows);
                }
                catch (Exception)
                {
                    AddOutput("Saving to file failed : " + tab.Name);
                }
                tab.Text = tab.Text.TrimEnd('*');
            }
        }

        private string InitialDirectory()
        {
            if (Project.Solution.This != null)
                return Project.Solution.This.Directory;
            else
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();

            FD.InitialDirectory = InitialDirectory();
            FD.Filter = "All Files (*.*)|*.*|Assembly Files (*.as)|*.as";
            FD.RestoreDirectory = true;

            if (FD.ShowDialog() == DialogResult.OK)
                AddCodePage(FD.FileName);
        }

        private void NewFile(object sender, EventArgs e)
        {
            SaveFileDialog FD = new SaveFileDialog();

            FD.InitialDirectory = InitialDirectory();
            FD.Filter = "All Files (*.*)|*.*|Assembly Files (*.as)|*.as";
            FD.RestoreDirectory = true;

            if (FD.ShowDialog() == DialogResult.OK)
            {
                File.Create(FD.FileName).Close();
                AddCodePage(FD.FileName);
                if (Project.Solution.This != null)
                    SolutionExplorerPanel.LoadSolution(Project.Solution.This.Path);
            }
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            if (CodeTab.SelectedTab != null && CodeTab.SelectedTab.Controls.Count > 0)
                (CodeTab.SelectedTab.Controls[0] as EditControl).Copy();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            if (CodeTab.SelectedTab != null && CodeTab.SelectedTab.Controls.Count > 0)
                (CodeTab.SelectedTab.Controls[0] as EditControl).Paste();
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            if (CodeTab.SelectedTab != null && CodeTab.SelectedTab.Controls.Count > 0)
                (CodeTab.SelectedTab.Controls[0] as EditControl).Cut();
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            if (CodeTab.SelectedTab != null && CodeTab.SelectedTab.Controls.Count > 0)
                (CodeTab.SelectedTab.Controls[0] as EditControl).Redo();
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            if (CodeTab.SelectedTab != null && CodeTab.SelectedTab.Controls.Count > 0)
                (CodeTab.SelectedTab.Controls[0] as EditControl).Undo();
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
                NewFile(null, null);

            if (e.Control && e.KeyCode == Keys.O)
                OpenFile(null, null);

            if (e.Control && e.Shift && e.KeyCode == Keys.F)
                FindFile(null, null);

            if (e.Control && e.KeyCode == Keys.S)
            {
                if (e.Shift)
                    SaveAllFiles(null, null);
                else
                    SaveFile(null, null);
            }

            if (e.KeyCode == Keys.F5)
            {
                if (e.Shift)
                {
                    if (e.Control)
                        RestartClick(null, null);
                    else
                        BreakClick(null, null);
                }
                else
                    Start(null, null);
            }

            if (e.KeyCode == Keys.F10)
                PauseClick(null, null);

            if (e.KeyCode == Keys.F11)
                StepClick(null, null);

            if (AssemblyProgram != null)
                AssemblyProgram.Input(e);
        }

        private void UncommentLine(object sender, EventArgs e)
        {
            if (CodeTab.SelectedTab != null && CodeTab.SelectedTab.Controls.Count > 0)
                (CodeTab.SelectedTab.Controls[0] as EditControl).UncommentSelection();
        }

        private void CommentLine(object sender, EventArgs e)
        {
            if (CodeTab.SelectedTab != null && CodeTab.SelectedTab.Controls.Count > 0)
                (CodeTab.SelectedTab.Controls[0] as EditControl).CommentSelection();
        }

        private void FindFile(object sender, EventArgs e)
        {
            Find.Clear();
            DockingManager.ActivateControl(FindPanel);
            new Visualisation.FindDialog();
        }

        private void CanUndoRedoChange(EditControl tb)
        {
            CanUndoRedoChange(tb.CanUndo, tb.CanRedo);
        }
        private void CanUndoRedoChange(bool u, bool r)
        {
            undo.Enabled = undoItem.Enabled = u;
            redo.Enabled = redoItem.Enabled = r;
            undo.ImageIndex = undoItem.ImageIndex = u ? 8 : 6; // TODO Icons
            redo.ImageIndex = redoItem.ImageIndex = r ? 9 : 7;
        }

        private void CanBackNextChange()
        {
            nextItem.Enabled = History.CanNext;
            backItem.Enabled = History.CanBack;
            nextItem.ImageIndex = History.CanNext ? 4 : 7; // TODO Icons
            backItem.ImageIndex = History.CanBack ? 5 : 8;
        }

        private void NextClick(object sender, EventArgs e)
        {
            var h = History.Next;
            var tb = (h.Item1.Controls[0] as EditControl);

            addToHistory = false;
            tb.CurrentPosition = h.Item2;
            CanBackNextChange();
        }

        private void BackClick(object sender, EventArgs e)
        {
            var h = History.Back;
            var tb = (h.Item1.Controls[0] as EditControl);

            addToHistory = false;
            tb.CurrentPosition = h.Item2;
            CanBackNextChange();
        }

        private void NewSolution(object sender, EventArgs e)
        {
            SaveFileDialog FD = new SaveFileDialog();

            FD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            FD.RestoreDirectory = true;

            if (FD.ShowDialog() == DialogResult.OK)
                SolutionExplorerPanel.LoadSolution(Project.Solution.CreateNewSolution(Path.GetFileNameWithoutExtension(FD.FileName), Path.GetDirectoryName(FD.FileName)));
        }

        private void OpenSolution(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();

            FD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            FD.RestoreDirectory = true;

            if (FD.ShowDialog() == DialogResult.OK)
                SolutionExplorerPanel.LoadSolution(FD.FileName);
        }

        private void AddProject(object sender, EventArgs e)
        {
            if (Project.Solution.This == null)
            {
                AddOutput("Can't add Project to any loaded Solution.");
                return;
            }

            SaveFileDialog FD = new SaveFileDialog();

            FD.InitialDirectory = Project.Solution.This.Directory;
            FD.RestoreDirectory = true;

            if (FD.ShowDialog() == DialogResult.OK)
            {
                Project.Solution.AddProject(
                    Path.GetFileNameWithoutExtension(FD.FileName),
                    Project.Solution.This.Directory,
                    Project.Solution.This.Path);
                SolutionExplorerPanel.LoadSolution(Project.Solution.This.Path);
            }
        }

        private void StepClick(object sender, EventArgs e)
        {
            CanStep = true;
        }

        private void RestartClick(object sender, EventArgs e)
        {
            Restart = true;
        }

        private void BreakClick(object sender, EventArgs e)
        {
            Cancel = true;
        }

        private void PauseClick(object sender, EventArgs e)
        {
            CanRun = false;
            PauseItem.Enabled = false;
            StepItem.Enabled = true;
            StartItem.Enabled = true;
        }

        private void ClosedForm(object sender, FormClosedEventArgs e)
        {
            CanRun = false;
            System.Threading.Thread.Sleep(50);
        }

        #endregion
    }
}
