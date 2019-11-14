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
using System.Linq;

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

        ContextMenu solutionContextMenu, fileContextMenu, folderContextMenu, projectContextMenu;

        public SolutionExplorerView()
        {
            InitializeComponent();

            LoadContextMenus();
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
            SolutionTree.NodeMouseClick += NodeMouseClick;

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
            dockingImageList.Images.Add("Proj", Properties.SolutionImages.Proj);
            dockingImageList.Images.Add("Sln", Properties.SolutionImages.Sln);
            dockingImageList.Images.Add("FolderOpen", Properties.SolutionImages.OpenFolder);
            dockingImageList.Images.Add("FolderClosed", Properties.SolutionImages.Folder);
            dockingImageList.Images.Add("File", Properties.SolutionImages.File);
            dockingImageList.Images.Add("ProjFile", Properties.SolutionImages.ProjFile);
            dockingImageList.Images.Add("Refresh", Properties.SolutionImages.Refresh);
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

        #endregion

        void LoadContextMenus()
        {
            SolutionTree.NodeEditorValidating += Validating;

            solutionContextMenu = new ContextMenu();
            solutionContextMenu.MenuItems.Add("Rename");
            solutionContextMenu.MenuItems.Add("Delete");
            solutionContextMenu.MenuItems.Add("Add Project", (_, __) => {
                New(NewProjectValidated, true);
            });
            solutionContextMenu.MenuItems.Add("Open in File Explorer", (_, __) => {
                System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(GetPath(SolutionTree.SelectedNode.Name)) + @"\");
            });

            solutionContextMenu.MenuItems[0].Enabled = false;
            solutionContextMenu.MenuItems[1].Enabled = false;

            projectContextMenu = new ContextMenu();
            projectContextMenu.MenuItems.Add("Rename");
            projectContextMenu.MenuItems.Add("Delete");
            projectContextMenu.MenuItems.Add("Add File", (_, __) => {
                New(NewFileValidated, false);
            });
            projectContextMenu.MenuItems.Add("Add Folder", (_, __) => {
                New(NewFolderValidated, true);
            });
            projectContextMenu.MenuItems.Add("Open in File Explorer", (_, __) => {
                System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(GetPath(SolutionTree.SelectedNode.Name)) + @"\");
            });

            projectContextMenu.MenuItems[0].Enabled = false;
            projectContextMenu.MenuItems[1].Enabled = false;

            folderContextMenu = new ContextMenu();
            folderContextMenu.MenuItems.Add("Rename", (_, __) => {
                Rename(FolderValidated);
            });
            folderContextMenu.MenuItems.Add("Delete", (_, __) => {
                if (Delete())
                    Directory.Delete(CloseFolderTabs(SolutionTree.SelectedNode.Name), true);
                Reload();
            });
            folderContextMenu.MenuItems.Add("Add File", (_, __) => {
                New(NewFileValidated, false);
            });
            folderContextMenu.MenuItems.Add("Add Folder", (_, __) => {
                New(NewFolderValidated, true);
            });
            folderContextMenu.MenuItems.Add("Open in File Explorer", (_, __) => {
                System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(GetPath(SolutionTree.SelectedNode.Name)) + @"\");
            });

            fileContextMenu = new ContextMenu();
            fileContextMenu.MenuItems.Add("Rename", (_, __) => {
                Rename(FileValidated);
            });
            fileContextMenu.MenuItems.Add("Delete", (_, __) => {
                if (Delete())
                    File.Delete(CloseTabs(SolutionTree.SelectedNode.Name));
                Reload();
            });
        }

        private void NewProjectValidated(object sender, TreeNodeAdvEditEventArgs e)
        {
            Solution.This.AddProject(e.Label);
            e.Node.Name = "Proj:" + Solution.This.Projects.Last().Path;
        }
        private void NewFolderValidated(object sender, TreeNodeAdvEditEventArgs e)
        {
            var path = Path.GetDirectoryName(GetPath(SolutionTree.SelectedNode.Parent.Name) + @"\") + @"\" + e.Label + @"\";
            Directory.CreateDirectory(path);
        }
        private void NewFileValidated(object sender, TreeNodeAdvEditEventArgs e)
        {
            var path = Path.GetDirectoryName(GetPath(SolutionTree.SelectedNode.Parent.Name) + @"\") + @"\" + e.Label;
            File.Create(path).Close();
            DockingManagerForm.This.AddCodePage(path);
        }
        private void FolderValidated(object sender, TreeNodeAdvEditEventArgs e)
        {
            var path = CloseFolderTabs(SolutionTree.SelectedNode.Name);
            Directory.Move(path, path + @"..\" + e.Label + @"\");
            RenameNode(SolutionTree.SelectedNode, path + @"..\" + e.Label + @"\");
        }
        private void FileValidated(object sender, TreeNodeAdvEditEventArgs e)
        {
            if (GetPath(SolutionTree.SelectedNode.Name).EndsWith(".proj"))
            {
                MessageBox.Show("Would overwrite Project, can't rename this file", "Failed to rename File");
                return;
            }

            var path = CloseTabs(SolutionTree.SelectedNode.Name);
            var newPath = Path.GetDirectoryName(path) + @"\" + e.Label;
            File.Move(path, newPath);
            RenameNode(SolutionTree.SelectedNode, newPath);
        }

        new private void Validating(object sender, TreeNodeAdvCancelableEditEventArgs e)
        {
            if (e.Label.Length == 0)
            {
                e.Cancel = true;
                MessageBox.Show("The label cannot be blank", "Node Label Edit");
                e.ContinueEditing = false;
            }
        }

        bool Delete()
        {
            return MessageBox.Show("Are you sure you want to delete this?", "Delete?", MessageBoxButtons.OKCancel) == DialogResult.OK;
        }

        void New(TreeNodeAdvEditEventHandler handler, bool folder)
        {
            if (folder)
                SolutionTree.SelectedNode = CreateFolder("", SolutionTree.SelectedNode);
            else
            {
                TreeNodeAdv newNode = Create("", 4);
                SolutionTree.SelectedNode.Nodes.Add(newNode);
                SolutionTree.SelectedNode = newNode;
            }

            SolutionTree.LabelEdit = true;
            if (!SolutionTree.IsEditing)
                SolutionTree.BeginEdit();
            SolutionTree.NodeEditorValidated += handler;
            SolutionTree.NodeEditorValidated += (_, __) => {
                SolutionTree.LabelEdit = false;
                SolutionTree.NodeEditorValidated -= handler;
            };
        }

        void Rename(TreeNodeAdvEditEventHandler handler)
        {
            SolutionTree.LabelEdit = true;
            if (!SolutionTree.IsEditing)
                SolutionTree.BeginEdit();
            SolutionTree.NodeEditorValidated += handler;
            SolutionTree.NodeEditorValidated += (_,__) => {
                SolutionTree.LabelEdit = false;
                SolutionTree.NodeEditorValidated -= handler;
            };
        }

        string GetPath(string val)
        {
            if (val == "Solution")
                return Solution.This.Directory;
            if (val.StartsWith("Proj"))
                return Path.GetDirectoryName(val.Substring(val.IndexOf(':') + 1));

            return val.Substring(val.IndexOf(':') + 1);
        }

        string RenameNode(TreeNodeAdv node, string path)
        {
            return node.Name = node.Name.Substring(0, node.Name.IndexOf(':') + 1) + path;
        }

        string CloseFolderTabs(string path)
        {
            path = GetPath(path) + @"\";
            foreach (TabPageAdv page in DockingManagerForm.This.CodeTab.TabPages)
                if (Path.GetDirectoryName(page.Name) == Path.GetDirectoryName(path))
                    DockingManagerForm.This.CodeTab.TabPages.Remove(page);
            return path;
        }

        string CloseTabs(string path)
        {
            path = GetPath(path);
            foreach (TabPageAdv page in DockingManagerForm.This.CodeTab.TabPages)
                if (page.Name == path)
                    DockingManagerForm.This.CodeTab.TabPages.Remove(page);
            return path;
        }

        private void NodeMouseClick(object sender, TreeViewAdvMouseClickEventArgs e)
        {
            if (e.Mousebutton != MouseButtons.Right)
                return;

            var pos = new Point(e.X, e.Y);

            if (e.Node.Name.StartsWith("Proj"))
                projectContextMenu.Show(SolutionTree, pos);

            if (e.Node.Name.StartsWith("Solution"))
                solutionContextMenu.Show(SolutionTree, pos);

            if (e.Node.Name.StartsWith("Folder"))
                folderContextMenu.Show(SolutionTree, pos);

            if (e.Node.Name.StartsWith("File"))
                fileContextMenu.Show(SolutionTree, pos);
        }

        private void Reload()
        {
            LoadSolution(Solution.This.Path);
        }

        private void Reload(object sender, TreeViewAdvMouseClickEventArgs e)
        {
            if (e.Node.Name.StartsWith("Reload"))
                Reload();
        }

        private void Open(object sender, TreeViewAdvMouseClickEventArgs e)
        {
            Reload(sender, e);

            if (File.Exists(GetPath(e.Node.Name)))
                DockingManagerForm.This.AddCodePage(GetPath(e.Node.Name));
        }

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
            Node.Name = "File:" + text;

            return Node;
        }

        TreeNodeAdv CreateFolder(string text, TreeNodeAdv addTo)
        {
            TreeNodeAdv Node = Create("", 3);
            Node.ClosedImgIndex = 3;
            Node.OpenImgIndex = 2;
            Node.Name = "Folder:" + text;
            if (text == "")
                Node.Text = text;
            else
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
                    addTo.Nodes.Add(Create(f, 4));
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

            TreeNodeAdv SolutionNode = Create("Solution \'" + Solution.This.Name + "\' (" + Solution.This.Projects.Count + " Projects)", 1);
            SolutionNode.Name = "Solution";

            TreeNodeAdv ReloadNode = Create("Reload Folders", 6);
            ReloadNode.Name = "Reload:" + path;

            SolutionTree.Nodes.Add(ReloadNode);
            SolutionTree.Nodes.Add(SolutionNode);

            foreach (Project.Project project in Solution.This.Projects)
            {
                TreeNodeAdv ProjectNode = Create(project.Name, 0);
                ProjectNode.Expanded = true;
                ProjectNode.Name = "Proj:" + project.Path;

                DirSearch(project.Directory, ProjectNode);

                SolutionTree.Nodes.Add(ProjectNode);
            }
        }
    }
}
