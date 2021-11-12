
using System;
using System.Windows.Forms;

using TALOREAL;

namespace GameOfLife
{
    partial class frmConwaysGame
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
            Settings.SaveSettings();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConwaysGame));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.universeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeRandomizerSeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setRandomizerSeedToTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toroidalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.runToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hudMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.startStopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.nextToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.slowerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fasterToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelGenerations = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelInterval = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusAlive = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.graphicsPanelContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.gridContext = new System.Windows.Forms.ToolStripMenuItem();
            this.hudContext = new System.Windows.Forms.ToolStripMenuItem();
            this.countsContext = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicsPanel1 = new GameOfLife.GraphicsPanel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.changeEvolutionRulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.graphicsPanelContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.universeToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(573, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator3,
            this.changeEvolutionRulesToolStripMenuItem,
            this.toolStripSeparator2,
            this.reloadToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.customizeToolStripMenuItem.Text = "Customize Colors";
            this.customizeToolStripMenuItem.Click += new System.EventHandler(this.customizeToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.optionsToolStripMenuItem.Text = "Change Interval";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(196, 6);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.reloadToolStripMenuItem.Text = "Reload Settings";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.resetToolStripMenuItem.Text = "Reset Settings";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // universeToolStripMenuItem
            // 
            this.universeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeRandomizerSeedToolStripMenuItem,
            this.setRandomizerSeedToTimeToolStripMenuItem,
            this.randomizeToolStripMenuItem,
            this.toolStripSeparator4,
            this.resizeToolStripMenuItem,
            this.toroidalMenuItem,
            this.toolStripSeparator5,
            this.runToToolStripMenuItem});
            this.universeToolStripMenuItem.Name = "universeToolStripMenuItem";
            this.universeToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.universeToolStripMenuItem.Text = "Universe";
            // 
            // changeRandomizerSeedToolStripMenuItem
            // 
            this.changeRandomizerSeedToolStripMenuItem.Name = "changeRandomizerSeedToolStripMenuItem";
            this.changeRandomizerSeedToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.changeRandomizerSeedToolStripMenuItem.Text = "Change Randomizer Seed";
            this.changeRandomizerSeedToolStripMenuItem.Click += new System.EventHandler(this.changeRandomizerSeedToolStripMenuItem_Click);
            // 
            // setRandomizerSeedToTimeToolStripMenuItem
            // 
            this.setRandomizerSeedToTimeToolStripMenuItem.Name = "setRandomizerSeedToTimeToolStripMenuItem";
            this.setRandomizerSeedToTimeToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.setRandomizerSeedToTimeToolStripMenuItem.Text = "Set Randomizer Seed to Time";
            this.setRandomizerSeedToTimeToolStripMenuItem.Click += new System.EventHandler(this.setRandomizerSeedToTimeToolStripMenuItem_Click);
            // 
            // randomizeToolStripMenuItem
            // 
            this.randomizeToolStripMenuItem.Name = "randomizeToolStripMenuItem";
            this.randomizeToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.randomizeToolStripMenuItem.Text = "Randomize";
            this.randomizeToolStripMenuItem.Click += new System.EventHandler(this.randomizeToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(224, 6);
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.resizeToolStripMenuItem.Text = "Resize Universe";
            this.resizeToolStripMenuItem.Click += new System.EventHandler(this.resizeToolStripMenuItem_Click);
            // 
            // toroidalMenuItem
            // 
            this.toroidalMenuItem.Name = "toroidalMenuItem";
            this.toroidalMenuItem.Size = new System.Drawing.Size(227, 22);
            this.toroidalMenuItem.Text = "Toroidal";
            this.toroidalMenuItem.Click += new System.EventHandler(this.toroidalToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(224, 6);
            // 
            // runToToolStripMenuItem
            // 
            this.runToToolStripMenuItem.Name = "runToToolStripMenuItem";
            this.runToToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.runToToolStripMenuItem.Text = "Run To";
            this.runToToolStripMenuItem.Click += new System.EventHandler(this.runToToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridMenuItem,
            this.hudMenuItem,
            this.countsMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // gridMenuItem
            // 
            this.gridMenuItem.Checked = true;
            this.gridMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridMenuItem.Name = "gridMenuItem";
            this.gridMenuItem.Size = new System.Drawing.Size(165, 22);
            this.gridMenuItem.Text = "Grid";
            this.gridMenuItem.Click += new System.EventHandler(this.ChangeDisplayOption);
            // 
            // hudMenuItem
            // 
            this.hudMenuItem.Checked = true;
            this.hudMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hudMenuItem.Name = "hudMenuItem";
            this.hudMenuItem.Size = new System.Drawing.Size(165, 22);
            this.hudMenuItem.Text = "HUD";
            this.hudMenuItem.Click += new System.EventHandler(this.ChangeDisplayOption);
            // 
            // countsMenuItem
            // 
            this.countsMenuItem.Checked = true;
            this.countsMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.countsMenuItem.Name = "countsMenuItem";
            this.countsMenuItem.Size = new System.Drawing.Size(165, 22);
            this.countsMenuItem.Text = "Neighbor Counts";
            this.countsMenuItem.Click += new System.EventHandler(this.ChangeDisplayOption);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator6,
            this.startStopToolStripButton,
            this.nextToolStripButton,
            this.slowerToolStripButton,
            this.fasterToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(573, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // startStopToolStripButton
            // 
            this.startStopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startStopToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("startStopToolStripButton.Image")));
            this.startStopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startStopToolStripButton.Name = "startStopToolStripButton";
            this.startStopToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.startStopToolStripButton.Text = "&Start";
            this.startStopToolStripButton.Click += new System.EventHandler(this.startStopToolStripButton_Click);
            // 
            // nextToolStripButton
            // 
            this.nextToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nextToolStripButton.Image")));
            this.nextToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextToolStripButton.Name = "nextToolStripButton";
            this.nextToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.nextToolStripButton.Text = "&Next";
            this.nextToolStripButton.Click += new System.EventHandler(this.nextToolStripButton_Click);
            // 
            // slowerToolStripButton
            // 
            this.slowerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.slowerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("slowerToolStripButton.Image")));
            this.slowerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.slowerToolStripButton.Name = "slowerToolStripButton";
            this.slowerToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.slowerToolStripButton.Text = "&Slower";
            this.slowerToolStripButton.Click += new System.EventHandler(this.slowerToolStripButton_Click);
            // 
            // fasterToolStripButton
            // 
            this.fasterToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fasterToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("fasterToolStripButton.Image")));
            this.fasterToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fasterToolStripButton.Name = "fasterToolStripButton";
            this.fasterToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.fasterToolStripButton.Text = "&Faster";
            this.fasterToolStripButton.Click += new System.EventHandler(this.fasterToolStripButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelGenerations,
            this.toolStripStatusLabelInterval,
            this.toolStripStatusAlive,
            this.toolStripStatusSeed});
            this.statusStrip1.Location = new System.Drawing.Point(0, 323);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(573, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelGenerations
            // 
            this.toolStripStatusLabelGenerations.Name = "toolStripStatusLabelGenerations";
            this.toolStripStatusLabelGenerations.Size = new System.Drawing.Size(96, 17);
            this.toolStripStatusLabelGenerations.Text = "Generations = 0, ";
            // 
            // toolStripStatusLabelInterval
            // 
            this.toolStripStatusLabelInterval.Name = "toolStripStatusLabelInterval";
            this.toolStripStatusLabelInterval.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabelInterval.Size = new System.Drawing.Size(103, 17);
            this.toolStripStatusLabelInterval.Text = "Interval = 100 ms, ";
            // 
            // toolStripStatusAlive
            // 
            this.toolStripStatusAlive.Name = "toolStripStatusAlive";
            this.toolStripStatusAlive.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusAlive.Text = "Alive = 0, ";
            // 
            // toolStripStatusSeed
            // 
            this.toolStripStatusSeed.Name = "toolStripStatusSeed";
            this.toolStripStatusSeed.Size = new System.Drawing.Size(103, 17);
            this.toolStripStatusSeed.Text = "Random Seed = 0,";
            // 
            // graphicsPanelContextMenu
            // 
            this.graphicsPanelContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.graphicsPanelContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorsToolStripMenuItem,
            this.viewToolStripMenuItem2});
            this.graphicsPanelContextMenu.Name = "contextMenuStrip1";
            this.graphicsPanelContextMenu.Size = new System.Drawing.Size(109, 48);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.colorsToolStripMenuItem.Text = "Colors";
            this.colorsToolStripMenuItem.Click += new System.EventHandler(this.customizeToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem2
            // 
            this.viewToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridContext,
            this.hudContext,
            this.countsContext});
            this.viewToolStripMenuItem2.Name = "viewToolStripMenuItem2";
            this.viewToolStripMenuItem2.Size = new System.Drawing.Size(108, 22);
            this.viewToolStripMenuItem2.Text = "View";
            // 
            // gridContext
            // 
            this.gridContext.Checked = true;
            this.gridContext.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridContext.Name = "gridContext";
            this.gridContext.Size = new System.Drawing.Size(206, 22);
            this.gridContext.Text = "Display Grid";
            this.gridContext.Click += new System.EventHandler(this.ChangeDisplayOption);
            // 
            // hudContext
            // 
            this.hudContext.Checked = true;
            this.hudContext.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hudContext.Name = "hudContext";
            this.hudContext.Size = new System.Drawing.Size(206, 22);
            this.hudContext.Text = "Display HUD";
            this.hudContext.Click += new System.EventHandler(this.ChangeDisplayOption);
            // 
            // countsContext
            // 
            this.countsContext.Checked = true;
            this.countsContext.CheckState = System.Windows.Forms.CheckState.Checked;
            this.countsContext.Name = "countsContext";
            this.countsContext.Size = new System.Drawing.Size(206, 22);
            this.countsContext.Text = "Display Neighbor Counts";
            this.countsContext.Click += new System.EventHandler(this.ChangeDisplayOption);
            // 
            // graphicsPanel1
            // 
            this.graphicsPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.graphicsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsPanel1.Location = new System.Drawing.Point(0, 51);
            this.graphicsPanel1.Name = "graphicsPanel1";
            this.graphicsPanel1.Size = new System.Drawing.Size(573, 272);
            this.graphicsPanel1.TabIndex = 3;
            this.graphicsPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicsPanel1_Paint);
            this.graphicsPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphicsPanel1_MouseClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // changeEvolutionRulesToolStripMenuItem
            // 
            this.changeEvolutionRulesToolStripMenuItem.Name = "changeEvolutionRulesToolStripMenuItem";
            this.changeEvolutionRulesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.changeEvolutionRulesToolStripMenuItem.Text = "Change Evolution Rules";
            this.changeEvolutionRulesToolStripMenuItem.Click += new System.EventHandler(this.changeEvolutionRulesToolStripMenuItem_Click);
            // 
            // frmConwaysGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 345);
            this.Controls.Add(this.graphicsPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmConwaysGame";
            this.Text = "Conway\'s Game of Life";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.graphicsPanelContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private GraphicsPanel graphicsPanel1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelGenerations;
        private System.Windows.Forms.ToolStripButton startStopToolStripButton;
        private System.Windows.Forms.ToolStripButton nextToolStripButton;
        private System.Windows.Forms.ToolStripButton slowerToolStripButton;
        private System.Windows.Forms.ToolStripButton fasterToolStripButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInterval;
        private System.Windows.Forms.ToolStripMenuItem universeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeRandomizerSeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setRandomizerSeedToTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toroidalMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hudMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusAlive;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSeed;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private ContextMenuStrip graphicsPanelContextMenu;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem runToToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem2;
        private ToolStripMenuItem hudContext;
        private ToolStripMenuItem gridContext;
        private ToolStripMenuItem countsContext;
        private ToolStripMenuItem colorsToolStripMenuItem;
        private ToolStripMenuItem changeEvolutionRulesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
    }
}

