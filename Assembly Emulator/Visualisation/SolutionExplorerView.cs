#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using System.IO;
using Assembly_Emulator.Project;

namespace Assembly_Emulator
{
    /// <summary>
    /// Summary description for SolutionExplorer.
    /// </summary>
    public class SolutionExplorerView : Control
    {
        private Panel panelSolutionExplorer;
        private ImageList dockingImageList;
        protected Syncfusion.Windows.Forms.ScrollersFrame scrollersFrame1;
        private Syncfusion.Windows.Forms.Tools.TreeViewAdv SolutionTree;
        private IContainer components;

        public SolutionExplorerView()
        {
            // call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            // TODO: Add any initialization after the InitForm call

        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of method with the code editor.
        /// </summary>
        /// 

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Syncfusion.Windows.Forms.MetroColorTable metroColorTable1 = new Syncfusion.Windows.Forms.MetroColorTable();
            panelSolutionExplorer = new System.Windows.Forms.Panel();
            SolutionTree = new Syncfusion.Windows.Forms.Tools.TreeViewAdv();
            dockingImageList = new System.Windows.Forms.ImageList(components);
            scrollersFrame1 = new Syncfusion.Windows.Forms.ScrollersFrame(components);
            panelSolutionExplorer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(SolutionTree)).BeginInit();
            SuspendLayout();
            // 
            // panelSolutionExplorer
            // 
            panelSolutionExplorer.Controls.Add(SolutionTree);
            panelSolutionExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            panelSolutionExplorer.Location = new System.Drawing.Point(0, 0);
            panelSolutionExplorer.Name = "panelSolutionExplorer";
            panelSolutionExplorer.Size = new System.Drawing.Size(192, 395);
            panelSolutionExplorer.TabIndex = 0;
            // 
            // treeViewAdv1
            // 
            SolutionTree.BackColor = System.Drawing.Color.White;
            SolutionTree.BeforeTouchSize = new System.Drawing.Size(192, 395);
            SolutionTree.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            SolutionTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            SolutionTree.Dock = System.Windows.Forms.DockStyle.Fill;
            SolutionTree.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SolutionTree.FullRowSelect = true;
            // 
            // 
            // 
            SolutionTree.NodeMouseClick += Reload;
            SolutionTree.NodeMouseDoubleClick += Open;

            SolutionTree.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            SolutionTree.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            SolutionTree.HelpTextControl.Name = "helpText";
            SolutionTree.HelpTextControl.Size = new System.Drawing.Size(49, 15);
            SolutionTree.HelpTextControl.TabIndex = 0;
            SolutionTree.HelpTextControl.Text = "help text";
            SolutionTree.InactiveSelectedNodeForeColor = System.Drawing.SystemColors.ControlText;
            SolutionTree.ItemHeight = 20;
            SolutionTree.LeftImageList = dockingImageList;
            SolutionTree.Location = new System.Drawing.Point(0, 0);
            SolutionTree.MetroColor = System.Drawing.SystemColors.Highlight;
            SolutionTree.Name = "treeViewAdv1";

            SolutionTree.StateImageList = dockingImageList;
            SolutionTree.SelectedNodeForeColor = System.Drawing.SystemColors.HighlightText;
            SolutionTree.ShowFocusRect = false;
            SolutionTree.ShowLines = false;
            SolutionTree.ShowRootLines = false;
            SolutionTree.Size = new System.Drawing.Size(192, 395);
            SolutionTree.Style = Syncfusion.Windows.Forms.Tools.TreeStyle.Metro;
            SolutionTree.TabIndex = 3;
            SolutionTree.Text = "treeViewAdv1";
            // 
            // 
            // 
            SolutionTree.ToolTipControl.BackColor = System.Drawing.SystemColors.Info;
            SolutionTree.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            SolutionTree.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            SolutionTree.ToolTipControl.Name = "toolTip";
            SolutionTree.ToolTipControl.Size = new System.Drawing.Size(41, 15);
            SolutionTree.ToolTipControl.TabIndex = 1;
            SolutionTree.ToolTipControl.Text = "toolTip";
            // 
            // dockingImageList
            // 
            dockingImageList.TransparentColor = System.Drawing.Color.Transparent;
            dockingImageList.Images.Add("01.png", Properties.Images._011);
            dockingImageList.Images.Add("02.png", Properties.Images._021);
            dockingImageList.Images.Add("03.png", Properties.Images._031);
            dockingImageList.Images.Add("05.png", Properties.Images._051);
            dockingImageList.Images.Add("10.png", Properties.Images._101);
            dockingImageList.Images.Add("Refresh.png", Properties.Images.Refresh1);
            // 
            // scrollersFrame1
            // 
            scrollersFrame1.CustomRender = null;
            scrollersFrame1.MetroColorScheme = Syncfusion.Windows.Forms.MetroColorScheme.Managed;
            scrollersFrame1.MetroThumbSize = new System.Drawing.Size(0, 0);
            metroColorTable1.ArrowChecked = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            metroColorTable1.ArrowInActive = System.Drawing.Color.White;
            metroColorTable1.ArrowNormal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            metroColorTable1.ArrowNormalBackGround = System.Drawing.Color.Empty;
            metroColorTable1.ArrowPushed = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(90)))));
            metroColorTable1.ArrowPushedBackGround = System.Drawing.Color.Empty;
            metroColorTable1.ScrollerBackground = System.Drawing.Color.White;
            metroColorTable1.ThumbChecked = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            metroColorTable1.ThumbInActive = System.Drawing.Color.White;
            metroColorTable1.ThumbNormal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            metroColorTable1.ThumbPushed = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(90)))));
            metroColorTable1.ThumbPushedBorder = System.Drawing.Color.Empty;
            scrollersFrame1.ScrollMetroColorTable = metroColorTable1;
            scrollersFrame1.ShowMetroArrowButton = true;
            scrollersFrame1.SizeGripperVisibility = Syncfusion.Windows.Forms.SizeGripperVisibility.Auto;
            scrollersFrame1.VisualStyle = Syncfusion.Windows.Forms.ScrollBarCustomDrawStyles.Metro;
            // 
            // SolutionExplorerView
            // 
            Controls.Add(panelSolutionExplorer);
            Name = "SolutionExplorerView";
            Size = new System.Drawing.Size(192, 395);
            panelSolutionExplorer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(SolutionTree)).EndInit();
            ResumeLayout(false);

        }

        private void Reload(object sender, TreeViewAdvMouseClickEventArgs e)
        {
            if (e.Node.Name.StartsWith("Reload"))
                LoadSolution(e.Node.Name.Substring(e.Node.Name.IndexOf(':') + 1));
        }

        private void Open(object sender, TreeViewAdvMouseClickEventArgs e)
        {
            Reload(sender, e);

            if (File.Exists(e.Node.Name))
                DockingManagerForm.This.AddCodePage(e.Node.Name);
        }

        #endregion

        TreeNodeAdv Create(string text, int imageInx)
        {
            if (text.EndsWith(".proj"))
                imageInx = 5;

            TreeNodeAdv Node = new TreeNodeAdv();
            Node.ChildStyle.EnsureDefaultOptionedChild = true;
            Node.EnsureDefaultOptionedChild = true;
            Node.MultiLine = true;
            Node.PlusMinusSize = new Size(9, 9);
            Node.ShowLine = true;
            Node.Text = Path.GetFileName(text);
            Node.NoChildrenImgIndex = imageInx;
            Node.ClosedImgIndex = imageInx;
            Node.OpenImgIndex = imageInx;
            Node.Name = text;

            return Node;
        }

        TreeNodeAdv CreateFolder(string text, TreeNodeAdv addTo)
        {
            TreeNodeAdv Node = Create("", 0);
            Node.ClosedImgIndex = 3;
            Node.OpenImgIndex = 2;
            Node.Name = text;
            Node.Text = new FileInfo(text).Name;

            addTo.Nodes.Add(Node);

            return Node;
        }

        void DirSearch(string sDir, TreeNodeAdv addTo)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                    DirSearch(d, CreateFolder(d, addTo));

                foreach (string f in Directory.GetFiles(sDir))
                    addTo.Nodes.Add(Create(f, 1)); // TODO Correct Index based on file name

            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        public void LoadSolution(string path)
        {
            new Solution(path);
            SolutionTree.Nodes.Clear();

            TreeNodeAdv SolutionNode = Create("Solution \'" + Solution.This.Name + "\' (" + Solution.This.Projects.Count + " Projects)", 0);

            TreeNodeAdv ReloadNode = Create("Reload Folders", 5);
            ReloadNode.Name = "Reload:" + path;

            SolutionTree.Nodes.Add(ReloadNode);
            SolutionTree.Nodes.Add(SolutionNode);

            foreach (Project.Project project in Solution.This.Projects)
            {
                TreeNodeAdv ProjectNode = Create(project.Name, 4);
                ProjectNode.Expanded = true;

                DirSearch(Path.GetDirectoryName(project.Path), ProjectNode);

                SolutionTree.Nodes.Add(ProjectNode);
            }
        }
    }
}
