#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Forms.Tools;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockingManagerForm));
            this.DockingManager = new Syncfusion.Windows.Forms.Tools.DockingManager(this.components);
            this.dwTaskListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorlistToolBar = new Syncfusion.Windows.Forms.Tools.XPMenus.XPToolBar();
            this.Errors = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.Warnings = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.Messages = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.BarManager = new Syncfusion.Windows.Forms.Tools.XPMenus.MainFrameBarManager(this);
            this.CodeDockingPanel = new Syncfusion.Windows.Forms.Tools.DockingClientPanel();
            this.CodeTab = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.SplashControl = new Syncfusion.Windows.Forms.Tools.SplashControl();
            this.SplashPanel = new Syncfusion.Windows.Forms.Tools.SplashPanel();
            ((System.ComponentModel.ISupportInitialize)(this.DockingManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            this.CodeDockingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CodeTab)).BeginInit();
            this.SuspendLayout();
            // 
            // DockingManager
            // 
            this.DockingManager.ActiveCaptionForeGround = System.Drawing.Color.RosyBrown;
            this.DockingManager.AnimateAutoHiddenWindow = true;
            this.DockingManager.AutoHideTabForeColor = System.Drawing.Color.Empty;
            this.DockingManager.AutoHideTabHeight = 25;
            this.DockingManager.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.DockingManager.CloseTabOnMiddleClick = false;
            this.DockingManager.DockBehavior = Syncfusion.Windows.Forms.Tools.DockBehavior.VS2010;
            this.DockingManager.DockLayoutStream = ((System.IO.MemoryStream)(resources.GetObject("DockingManager.DockLayoutStream")));
            this.DockingManager.DockTabPadX = 0F;
            this.DockingManager.DragProviderStyle = Syncfusion.Windows.Forms.Tools.DragProviderStyle.VS2010;
            this.DockingManager.HostControl = this;
            this.DockingManager.InActiveCaptionBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212))))));
            this.DockingManager.MetroButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DockingManager.MetroCaptionColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.DockingManager.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.DockingManager.MetroInactiveCaptionColor = System.Drawing.Color.White;
            this.DockingManager.MetroSplitterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(159)))), ((int)(((byte)(183)))));
            this.DockingManager.ReduceFlickeringInRtl = false;
            this.DockingManager.ShowMetroCaptionDottedLines = false;
            this.DockingManager.ThemeName = "VS2010";
            this.DockingManager.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.VS2010;
            this.DockingManager.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"));
            this.DockingManager.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"));
            this.DockingManager.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"));
            this.DockingManager.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"));
            this.DockingManager.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"));

            LoadImageList();


            // 
            // dwTaskListView
            // 
            this.dwTaskListView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dwTaskListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dwTaskListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.dwTaskListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwTaskListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dwTaskListView.FullRowSelect = true;
            this.dwTaskListView.GridLines = true;
            this.dwTaskListView.HideSelection = false;
            this.dwTaskListView.Location = new System.Drawing.Point(0, 23);
            this.dwTaskListView.MultiSelect = false;
            this.dwTaskListView.Name = "dwTaskListView";
            this.dwTaskListView.Size = new System.Drawing.Size(877, 17);
            this.dwTaskListView.TabIndex = 29;
            this.dwTaskListView.UseCompatibleStateImageBehavior = false;
            this.dwTaskListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "!";
            this.columnHeader1.Width = 20;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 22;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 1000;
            // 
            // errorlistToolBar
            // 
            this.errorlistToolBar.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.errorlistToolBar.Bar.BarName = "";
            this.errorlistToolBar.Bar.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.Errors,
            this.Warnings,
            this.Messages});
            this.errorlistToolBar.Bar.Manager = null;
            this.errorlistToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.errorlistToolBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorlistToolBar.Location = new System.Drawing.Point(0, 0);
            this.errorlistToolBar.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.errorlistToolBar.Name = "errorlistToolBar";
            this.errorlistToolBar.Size = new System.Drawing.Size(877, 23);
            this.errorlistToolBar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.errorlistToolBar.TabIndex = 1;
            // 
            // Errors
            // 
            this.Errors.BarName = "Errors";
            this.Errors.Checked = true;
            this.Errors.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Errors.ID = "Errors";
            this.Errors.ShowToolTipInPopUp = false;
            this.Errors.SizeToFit = true;
            this.Errors.Text = "Errors";
            // 
            // Warnings
            // 
            this.Warnings.BarName = "Warnings";
            this.Warnings.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Warnings.ID = "Warnings";
            this.Warnings.ShowToolTipInPopUp = false;
            this.Warnings.SizeToFit = true;
            this.Warnings.Text = "Warnings";
            // 
            // Messages
            // 
            this.Messages.BarName = "Messages";
            this.Messages.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Messages.ID = "Messages";
            this.Messages.ShowToolTipInPopUp = false;
            this.Messages.SizeToFit = true;
            this.Messages.Text = "Messages";

            // 
            // BarManager
            // 
            this.BarManager.BarPositionInfo = ((System.IO.MemoryStream)(resources.GetObject("BarManager.BarPositionInfo")));
            this.BarManager.CurrentBaseFormType = "Syncfusion.Windows.Forms.MetroForm";
            this.BarManager.EnableMenuMerge = true;
            this.BarManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarManager.Form = this;
            this.BarManager.MetroBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.BarManager.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(244)))), ((int)(((byte)(191)))));
            this.BarManager.ResetCustomization = false;
            this.BarManager.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.BarManager.ThemeName = "Metro";
            this.BarManager.UseBackwardCompatiblity = false;
            // 
            // CodeDockingPanel
            // 
            this.CodeDockingPanel.Controls.Add(this.CodeTab);
            this.CodeDockingPanel.Location = new System.Drawing.Point(356, 79);
            this.CodeDockingPanel.Name = "CodeDockingPanel";
            this.CodeDockingPanel.Size = new System.Drawing.Size(254, 177);
            this.CodeDockingPanel.TabIndex = 20;
            // 
            // CodeTab
            // 
            this.CodeTab.ActiveTabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeTab.ActiveTabForeColor = System.Drawing.Color.Empty;
            this.CodeTab.BeforeTouchSize = new System.Drawing.Size(254, 177);
            this.CodeTab.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CodeTab.CloseButtonForeColor = System.Drawing.Color.Empty;
            this.CodeTab.CloseButtonHoverForeColor = System.Drawing.Color.Black;
            this.CodeTab.CloseButtonPressedForeColor = System.Drawing.Color.Black;
            this.CodeTab.CloseTabOnMiddleClick = false;
            this.CodeTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeTab.FocusOnTabClick = false;
            this.CodeTab.HotTrack = true;
            this.CodeTab.InActiveTabForeColor = System.Drawing.Color.Empty;
            this.CodeTab.ItemSize = new System.Drawing.Size(77, 26);
            this.CodeTab.Location = new System.Drawing.Point(0, 0);
            this.CodeTab.Name = "CodeTab";
            this.CodeTab.SeparatorColor = System.Drawing.SystemColors.ControlDark;
            this.CodeTab.ShowCloseButtonForActiveTabOnly = true;
            this.CodeTab.ShowCloseButtonHighLightBackColor = true;
            this.CodeTab.ShowSeparator = false;
            this.CodeTab.ShowTabCloseButton = true;
            this.CodeTab.Size = new System.Drawing.Size(254, 177);
            this.CodeTab.TabIndex = 0;
            this.CodeTab.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererVS2010);
            this.CodeTab.ThemeName = "TabRendererVS2010";

            // 
            // splashControl1
            // 
            this.SplashControl.AutoMode = false;
            this.SplashControl.CustomSplashPanel = this.SplashPanel;
            this.SplashControl.HideHostForm = true;
            this.SplashControl.HostForm = this;
            this.SplashControl.UseCustomSplashPanel = true;
            this.SplashControl.TimerInterval = 1500;
            // 
            // splashPanel1
            // 
            this.SplashPanel.AnimationDirection = Syncfusion.Windows.Forms.Tools.AnimationDirection.Default;
            this.SplashPanel.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.None, System.Drawing.Color.White, System.Drawing.SystemColors.HighlightText);
            this.SplashPanel.BackgroundImage = Properties.Images.SplashScreen;
            this.SplashPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SplashPanel.BeforeTouchSize = Properties.Images.SplashScreen.Size;
            this.SplashPanel.BorderType = Syncfusion.Windows.Forms.Tools.SplashBorderType.None;
            this.SplashPanel.DiscreetLocation = new System.Drawing.Point(0, 0);
            this.SplashPanel.Location = new System.Drawing.Point(218, 320);
            this.SplashPanel.MarqueeDirection = Syncfusion.Windows.Forms.Tools.SplashPanelMarqueeDirection.LeftToRight;
            this.SplashPanel.MarqueePosition = Syncfusion.Windows.Forms.Tools.MarqueePosition.BottomLeft;
            this.SplashPanel.Size = Properties.Images.SplashScreen.Size;
            this.SplashPanel.TabIndex = 25;
            this.SplashPanel.Text = "SplashPanel";
            
            // 
            // DockingManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.BorderThickness = 12;
            this.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.CaptionBarHeight = 30;
            this.CaptionButtonColor = System.Drawing.Color.Black;
            this.CaptionButtonHoverColor = System.Drawing.Color.Black;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(879, 476);
            this.Controls.Add(this.CodeDockingPanel);
            this.Icon = Properties.Images.Icon;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.Name = "DockingManagerForm";
            this.Text = "Haul Studio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.DockingManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            this.CodeDockingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CodeTab)).EndInit();
            this.ResumeLayout(false);

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

        private System.Windows.Forms.ImageList ImageList;

        private SplashPanel SplashPanel;
        private SplashControl SplashControl;
    }
}

