#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Drawing;

namespace Assembly_Emulator
{
    partial class DockingManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockingManagerForm));
            Syncfusion.Windows.Forms.Tools.CaptionButtonsCollection ccbImmediatePanel = new Syncfusion.Windows.Forms.Tools.CaptionButtonsCollection();
            Syncfusion.Windows.Forms.Tools.CaptionButtonsCollection ccbFindPanel = new Syncfusion.Windows.Forms.Tools.CaptionButtonsCollection();
            Syncfusion.Windows.Forms.Tools.CaptionButtonsCollection ccbOutputPanel = new Syncfusion.Windows.Forms.Tools.CaptionButtonsCollection();
            DockingManager = new Syncfusion.Windows.Forms.Tools.DockingManager(components);
            dwTaskListView = new System.Windows.Forms.ListView();
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            errorlistToolBar = new Syncfusion.Windows.Forms.Tools.XPMenus.XPToolBar();
            Errors = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            Warnings = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            Messages = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            imageList1 = new System.Windows.Forms.ImageList(components);
            BarManager = new Syncfusion.Windows.Forms.Tools.XPMenus.MainFrameBarManager(this);
            CodeDockingPanel = new Syncfusion.Windows.Forms.Tools.DockingClientPanel();
            CodeTab = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            imageList2 = new System.Windows.Forms.ImageList(components);
            imageList3 = new System.Windows.Forms.ImageList(components);
            imageList4 = new System.Windows.Forms.ImageList(components);
            ((System.ComponentModel.ISupportInitialize)(DockingManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(BarManager)).BeginInit();
            CodeDockingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(CodeTab)).BeginInit();
            SuspendLayout();
            // 
            // DockingManager
            // 
            DockingManager.ActiveCaptionForeGround = System.Drawing.Color.RosyBrown;
            DockingManager.AnimateAutoHiddenWindow = true;
            DockingManager.AutoHideTabForeColor = System.Drawing.Color.Empty;
            DockingManager.AutoHideTabHeight = 25;
            DockingManager.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            DockingManager.CloseTabOnMiddleClick = false;
            DockingManager.DockBehavior = Syncfusion.Windows.Forms.Tools.DockBehavior.VS2010;
            DockingManager.DockLayoutStream = ((System.IO.MemoryStream)(resources.GetObject("DockingManager.DockLayoutStream")));
            DockingManager.DockTabPadX = 0F;
            DockingManager.DragProviderStyle = Syncfusion.Windows.Forms.Tools.DragProviderStyle.VS2010;
            DockingManager.HostControl = this;
            DockingManager.InActiveCaptionBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212))))));
            DockingManager.MetroButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            DockingManager.MetroCaptionColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            DockingManager.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            DockingManager.MetroInactiveCaptionColor = System.Drawing.Color.White;
            DockingManager.MetroSplitterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(159)))), ((int)(((byte)(183)))));
            DockingManager.ReduceFlickeringInRtl = false;
            DockingManager.ShowMetroCaptionDottedLines = false;
            DockingManager.ThemeName = "VS2010";
            DockingManager.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.VS2010;
            DockingManager.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"));
            DockingManager.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"));
            DockingManager.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"));
            DockingManager.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"));
            DockingManager.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"));
            // 
            // dwTaskListView
            // 
            dwTaskListView.BackColor = System.Drawing.Color.WhiteSmoke;
            dwTaskListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dwTaskListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1,
            columnHeader2,
            columnHeader3});
            dwTaskListView.Dock = System.Windows.Forms.DockStyle.Fill;
            dwTaskListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dwTaskListView.FullRowSelect = true;
            dwTaskListView.GridLines = true;
            dwTaskListView.HideSelection = false;
            dwTaskListView.Location = new System.Drawing.Point(0, 23);
            dwTaskListView.MultiSelect = false;
            dwTaskListView.Name = "dwTaskListView";
            dwTaskListView.Size = new System.Drawing.Size(877, 17);
            dwTaskListView.TabIndex = 29;
            dwTaskListView.UseCompatibleStateImageBehavior = false;
            dwTaskListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "!";
            columnHeader1.Width = 20;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "";
            columnHeader2.Width = 22;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Description";
            columnHeader3.Width = 1000;
            // 
            // errorlistToolBar
            // 
            errorlistToolBar.BackColor = System.Drawing.Color.White;
            errorlistToolBar.Bar.BarName = "";
            errorlistToolBar.Bar.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            Errors,
            Warnings,
            Messages});
            errorlistToolBar.Bar.Manager = null;
            errorlistToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            errorlistToolBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            errorlistToolBar.Location = new System.Drawing.Point(0, 0);
            errorlistToolBar.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            errorlistToolBar.Name = "errorlistToolBar";
            errorlistToolBar.Size = new System.Drawing.Size(877, 23);
            errorlistToolBar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            errorlistToolBar.TabIndex = 1;
            // 
            // Errors
            // 
            Errors.BarName = "Errors";
            Errors.Checked = true;
            Errors.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            Errors.ID = "Errors";
            Errors.ShowToolTipInPopUp = false;
            Errors.SizeToFit = true;
            Errors.Text = "Errors";
            // 
            // Warnings
            // 
            Warnings.BarName = "Warnings";
            Warnings.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            Warnings.ID = "Warnings";
            Warnings.ShowToolTipInPopUp = false;
            Warnings.SizeToFit = true;
            Warnings.Text = "Warnings";
            // 
            // Messages
            // 
            Messages.BarName = "Messages";
            Messages.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            Messages.ID = "Messages";
            Messages.ShowToolTipInPopUp = false;
            Messages.SizeToFit = true;
            Messages.Text = "Messages";
            // 
            // imageList1
            // 
            imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            imageList1.TransparentColor = System.Drawing.Color.Transparent;
            imageList1.Images.SetKeyName(0, "1.png");
            imageList1.Images.SetKeyName(1, "2.png");
            imageList1.Images.SetKeyName(2, "3.png");
            imageList1.Images.SetKeyName(3, "4.png");
            imageList1.Images.SetKeyName(4, "5.png");
            imageList1.Images.SetKeyName(5, "6.png");
            imageList1.Images.SetKeyName(6, "7.png");
            imageList1.Images.SetKeyName(7, "8.png");
            imageList1.Images.SetKeyName(8, "9.png");
            imageList1.Images.SetKeyName(9, "10.png");
            imageList1.Images.SetKeyName(10, "11.png");
            imageList1.Images.SetKeyName(11, "12.png");
            imageList1.Images.SetKeyName(12, "13.png");
            imageList1.Images.SetKeyName(13, "14.png");
            imageList1.Images.SetKeyName(14, "15.png");
            // 
            // BarManager
            // 
            BarManager.BarPositionInfo = ((System.IO.MemoryStream)(resources.GetObject("BarManager.BarPositionInfo")));
            BarManager.CurrentBaseFormType = "Syncfusion.Windows.Forms.MetroForm";
            BarManager.EnableMenuMerge = true;
            BarManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            BarManager.Form = this;
            BarManager.MetroBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            BarManager.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(244)))), ((int)(((byte)(191)))));
            BarManager.ResetCustomization = false;
            BarManager.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            BarManager.ThemeName = "Metro";
            BarManager.UseBackwardCompatiblity = false;
           
            // 
            // dockingClientPanel1
            // 
            CodeDockingPanel.Controls.Add(CodeTab);
            CodeDockingPanel.Location = new System.Drawing.Point(356, 79);
            CodeDockingPanel.Name = "dockingClientPanel1";
            CodeDockingPanel.Size = new System.Drawing.Size(254, 177);
            CodeDockingPanel.TabIndex = 20;
            // 
            // CodeTab
            // 
            CodeTab.ActiveTabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CodeTab.ActiveTabForeColor = System.Drawing.Color.Empty;
            CodeTab.BeforeTouchSize = new System.Drawing.Size(254, 177);
            CodeTab.BorderStyle = System.Windows.Forms.BorderStyle.None;
            CodeTab.CloseButtonForeColor = System.Drawing.Color.Empty;
            CodeTab.CloseButtonHoverForeColor = System.Drawing.Color.Black;
            CodeTab.CloseButtonPressedForeColor = System.Drawing.Color.Black;
            CodeTab.CloseTabOnMiddleClick = false;
            CodeTab.Dock = System.Windows.Forms.DockStyle.Fill;
            CodeTab.FocusOnTabClick = false;
            CodeTab.HotTrack = true;
            CodeTab.InActiveTabForeColor = System.Drawing.Color.Empty;
            CodeTab.ItemSize = new System.Drawing.Size(77, 26);
            CodeTab.Location = new System.Drawing.Point(0, 0);
            CodeTab.Name = "CodeTab";
            CodeTab.SeparatorColor = System.Drawing.SystemColors.ControlDark;
            CodeTab.ShowCloseButtonForActiveTabOnly = true;
            CodeTab.ShowCloseButtonHighLightBackColor = true;
            CodeTab.ShowSeparator = false;
            CodeTab.ShowTabCloseButton = true;
            CodeTab.Size = new System.Drawing.Size(254, 177);
            CodeTab.TabIndex = 0;
            CodeTab.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererVS2010);
            CodeTab.ThemeName = "TabRendererVS2010";
            // 
            // imageList2
            // 
            imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            imageList2.TransparentColor = System.Drawing.Color.Transparent;
            imageList2.Images.SetKeyName(0, "1.png");
            imageList2.Images.SetKeyName(1, "2.png");
            imageList2.Images.SetKeyName(2, "3.png");
            imageList2.Images.SetKeyName(3, "4.png");
            imageList2.Images.SetKeyName(4, "5.png");
            imageList2.Images.SetKeyName(5, "6.png");
            imageList2.Images.SetKeyName(6, "7.png");
            imageList2.Images.SetKeyName(7, "8.png");
            imageList2.Images.SetKeyName(8, "9.png");
            imageList2.Images.SetKeyName(9, "10.png");
            imageList2.Images.SetKeyName(10, "11.png");
            imageList2.Images.SetKeyName(11, "12.png");
            imageList2.Images.SetKeyName(12, "13.png");
            imageList2.Images.SetKeyName(13, "14.png");
            imageList2.Images.SetKeyName(14, "15.png");
            imageList2.Images.SetKeyName(15, "16.png");
            imageList2.Images.SetKeyName(16, "17.png");
            imageList2.Images.SetKeyName(17, "18.png");
            imageList2.Images.SetKeyName(18, "19.png");
            imageList2.Images.SetKeyName(19, "20.png");
            imageList2.Images.SetKeyName(20, "21.png");
            // 
            // imageList3
            // 
            imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            imageList3.TransparentColor = System.Drawing.Color.Transparent;
            imageList3.Images.SetKeyName(0, "Window-New.png");
            imageList3.Images.SetKeyName(1, "");
            imageList3.Images.SetKeyName(2, "02.png");
            imageList3.Images.SetKeyName(3, "");
            imageList3.Images.SetKeyName(4, "");
            imageList3.Images.SetKeyName(5, "01.png");
            imageList3.Images.SetKeyName(6, "");
            imageList3.Images.SetKeyName(7, "");
            imageList3.Images.SetKeyName(8, "");
            imageList3.Images.SetKeyName(9, "");
            imageList3.Images.SetKeyName(10, "");
            imageList3.Images.SetKeyName(11, "");
            imageList3.Images.SetKeyName(12, "Cut.png");
            imageList3.Images.SetKeyName(13, "");
            imageList3.Images.SetKeyName(14, "");
            imageList3.Images.SetKeyName(15, "");
            imageList3.Images.SetKeyName(16, "");
            imageList3.Images.SetKeyName(17, "FindAll.png");
            imageList3.Images.SetKeyName(18, "Play.png");
            imageList3.Images.SetKeyName(19, "");
            imageList3.Images.SetKeyName(20, "");
            imageList3.Images.SetKeyName(21, "");
            imageList3.Images.SetKeyName(22, "");
            imageList3.Images.SetKeyName(23, "");
            imageList3.Images.SetKeyName(24, "");
            imageList3.Images.SetKeyName(25, "");
            imageList3.Images.SetKeyName(26, "");
            imageList3.Images.SetKeyName(27, "Properties.png");
            imageList3.Images.SetKeyName(28, "Redo.png");
            imageList3.Images.SetKeyName(29, "05.png");
            imageList3.Images.SetKeyName(30, "04.png");
            imageList3.Images.SetKeyName(31, "06.png");
            imageList3.Images.SetKeyName(32, "Undo.png");
            imageList3.Images.SetKeyName(33, "Tools.png");
            imageList3.Images.SetKeyName(34, "");
            imageList3.Images.SetKeyName(35, "");
            imageList3.Images.SetKeyName(36, "");
            imageList3.Images.SetKeyName(37, "");
            imageList3.Images.SetKeyName(38, "");
            imageList3.Images.SetKeyName(39, "");
            imageList3.Images.SetKeyName(40, "");
            imageList3.Images.SetKeyName(41, "");
            imageList3.Images.SetKeyName(42, "");
            imageList3.Images.SetKeyName(43, "");
            imageList3.Images.SetKeyName(44, "");
            imageList3.Images.SetKeyName(45, "");
            imageList3.Images.SetKeyName(46, "03.png");
            imageList3.Images.SetKeyName(47, "AddToWatch.png");
            imageList3.Images.SetKeyName(48, "Cut.png");
            imageList3.Images.SetKeyName(49, "");
            imageList3.Images.SetKeyName(50, "");
            imageList3.Images.SetKeyName(51, "");
            imageList3.Images.SetKeyName(52, "");
            imageList3.Images.SetKeyName(53, "");
            imageList3.Images.SetKeyName(54, "");
            imageList3.Images.SetKeyName(55, "");
            imageList3.Images.SetKeyName(56, "AddItem.png");
            imageList3.Images.SetKeyName(57, "");
            imageList3.Images.SetKeyName(58, "");
            imageList3.Images.SetKeyName(59, "");
            imageList3.Images.SetKeyName(60, "");
            imageList3.Images.SetKeyName(61, "");
            imageList3.Images.SetKeyName(62, "07.png");
            imageList3.Images.SetKeyName(63, "New Search Folder.png");
            imageList3.Images.SetKeyName(64, "");
            imageList3.Images.SetKeyName(65, "");
            imageList3.Images.SetKeyName(66, "");
            imageList3.Images.SetKeyName(67, "");
            imageList3.Images.SetKeyName(68, "");
            imageList3.Images.SetKeyName(69, "");
            imageList3.Images.SetKeyName(70, "");
            imageList3.Images.SetKeyName(71, "");
            imageList3.Images.SetKeyName(72, "");
            imageList3.Images.SetKeyName(73, "");
            imageList3.Images.SetKeyName(74, "");
            imageList3.Images.SetKeyName(75, "");
            imageList3.Images.SetKeyName(76, "");
            imageList3.Images.SetKeyName(77, "");
            imageList3.Images.SetKeyName(78, "");
            imageList3.Images.SetKeyName(79, "");
            imageList3.Images.SetKeyName(80, "Play.png");
            imageList3.Images.SetKeyName(81, "");
            imageList3.Images.SetKeyName(82, "");
            imageList3.Images.SetKeyName(83, "");
            imageList3.Images.SetKeyName(84, "");
            imageList3.Images.SetKeyName(85, "");
            imageList3.Images.SetKeyName(86, "");
            imageList3.Images.SetKeyName(87, "");
            imageList3.Images.SetKeyName(88, "");
            imageList3.Images.SetKeyName(89, "");
            imageList3.Images.SetKeyName(90, "News View.png");
            imageList3.Images.SetKeyName(91, "");
            imageList3.Images.SetKeyName(92, "panels_new3_close.ico");
            imageList3.Images.SetKeyName(93, "Next.png");
            imageList3.Images.SetKeyName(94, "1.png");
            imageList3.Images.SetKeyName(95, "2.png");
            imageList3.Images.SetKeyName(96, "3-corrected.png");
            imageList3.Images.SetKeyName(97, "4.png");
            imageList3.Images.SetKeyName(98, "5.png");
            imageList3.Images.SetKeyName(99, "6.png");
            imageList3.Images.SetKeyName(100, "11.png");
            imageList3.Images.SetKeyName(101, "12.png");
            imageList3.Images.SetKeyName(102, "bookmark.png");
            imageList3.Images.SetKeyName(103, "bookmark_left.png");
            imageList3.Images.SetKeyName(104, "bookmark_right.png");
            imageList3.Images.SetKeyName(105, "combo icon.png");
            imageList3.Images.SetKeyName(106, "connect.png");
            imageList3.Images.SetKeyName(107, "down.png");
            imageList3.Images.SetKeyName(108, "left undo.png");
            imageList3.Images.SetKeyName(109, "m1.png");
            imageList3.Images.SetKeyName(110, "msg  unread.png");
            imageList3.Images.SetKeyName(111, "msg.png");
            imageList3.Images.SetKeyName(112, "right undo.png");
            imageList3.Images.SetKeyName(113, "run.png");
            imageList3.Images.SetKeyName(114, "sub.png");
            imageList3.Images.SetKeyName(115, "unmark.png");
            // 
            // imageList4
            // 
            imageList4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList4.ImageStream")));
            imageList4.TransparentColor = System.Drawing.Color.Transparent;
            imageList4.Images.SetKeyName(0, "");
            imageList4.Images.SetKeyName(1, "13.png");
            imageList4.Images.SetKeyName(2, "Next.png");
            imageList4.Images.SetKeyName(3, "");
            imageList4.Images.SetKeyName(4, "15.png");
            imageList4.Images.SetKeyName(5, "Before.png");
            imageList4.Images.SetKeyName(6, "");
            imageList4.Images.SetKeyName(7, "14.png");
            imageList4.Images.SetKeyName(8, "16.png");
            imageList4.Images.SetKeyName(9, "");
            imageList4.Images.SetKeyName(10, "11.png");
            imageList4.Images.SetKeyName(11, "Copy.png");
            imageList4.Images.SetKeyName(12, "");
            imageList4.Images.SetKeyName(13, "");
            imageList4.Images.SetKeyName(14, "");
            imageList4.Images.SetKeyName(15, "");
            imageList4.Images.SetKeyName(16, "");
            imageList4.Images.SetKeyName(17, "");
            imageList4.Images.SetKeyName(18, "10.png");
            imageList4.Images.SetKeyName(19, "PreviousBookMark.png");
            imageList4.Images.SetKeyName(20, "NextBookMark.png");
            imageList4.Images.SetKeyName(21, "");
            imageList4.Images.SetKeyName(22, "");
            imageList4.Images.SetKeyName(23, "");
            imageList4.Images.SetKeyName(24, "10.png");
            imageList4.Images.SetKeyName(25, "Paste.png");
            imageList4.Images.SetKeyName(26, "");
            imageList4.Images.SetKeyName(27, "09.png");
            imageList4.Images.SetKeyName(28, "");
            imageList4.Images.SetKeyName(29, "");
            imageList4.Images.SetKeyName(30, "");
            imageList4.Images.SetKeyName(31, "");
            imageList4.Images.SetKeyName(32, "");
            imageList4.Images.SetKeyName(33, "12.png");
            imageList4.Images.SetKeyName(34, "08.png");
            imageList4.Images.SetKeyName(35, "Copy.png");
            imageList4.Images.SetKeyName(36, "");
            imageList4.Images.SetKeyName(37, "10.png");
            imageList4.Images.SetKeyName(38, "10.png");
            imageList4.Images.SetKeyName(39, "Cut.png");
            // 
            // DockingManagerForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            BorderThickness = 12;
            CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left;
            CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            CaptionBarHeight = 30;
            CaptionButtonColor = System.Drawing.Color.Black;
            CaptionButtonHoverColor = System.Drawing.Color.Black;
            CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ClientSize = new System.Drawing.Size(879, 476);
            Controls.Add(CodeDockingPanel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            Icon = ((System.Drawing.Icon)(resources.GetObject("$Icon")));
            MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            Name = "DockingManagerForm";
            Text = "Assembly IDE";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += new System.EventHandler(DockingManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(DockingManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(BarManager)).EndInit();
            CodeDockingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(CodeTab)).EndInit();
            ResumeLayout(false);

        }

        #endregion

        public Syncfusion.Windows.Forms.Tools.XPMenus.MainFrameBarManager BarManager;
        private Syncfusion.Windows.Forms.Tools.DockingManager DockingManager;
        
        private Syncfusion.Windows.Forms.Tools.DockingClientPanel CodeDockingPanel;
        public Syncfusion.Windows.Forms.Tools.TabControlAdv CodeTab;
        
        private System.Windows.Forms.ListView dwTaskListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        public Syncfusion.Windows.Forms.Tools.XPMenus.XPToolBar errorlistToolBar;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem Errors;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem Warnings;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem Messages;

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        internal System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.ImageList imageList4;
    }
}

