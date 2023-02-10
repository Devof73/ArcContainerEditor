namespace ARC
{
    partial class Editor
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// Claro que si zorri.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.FileCollectionImageList = new System.Windows.Forms.ImageList(this.components);
            this.MainToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToPS3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openWorkingDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonOpenExFolder = new System.Windows.Forms.ToolStripButton();
            this.LabelSetName = new System.Windows.Forms.ToolStripLabel();
            this.NameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.ButtonSetNameOk = new System.Windows.Forms.ToolStripButton();
            this.OptionsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.replaceFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indicator = new System.Windows.Forms.ProgressBar();
            this.indicatorLabel = new System.Windows.Forms.Label();
            this.openFromPS3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.defaultIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultTIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainToolStrip.SuspendLayout();
            this.OptionsContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.HotTracking = true;
            this.treeView1.ImageIndex = 1;
            this.treeView1.ImageList = this.FileCollectionImageList;
            this.treeView1.Location = new System.Drawing.Point(3, 39);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(373, 246);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDoubleClick);
            // 
            // FileCollectionImageList
            // 
            this.FileCollectionImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FileCollectionImageList.ImageStream")));
            this.FileCollectionImageList.TransparentColor = System.Drawing.Color.White;
            this.FileCollectionImageList.Images.SetKeyName(0, "dir");
            this.FileCollectionImageList.Images.SetKeyName(1, "file");
            this.FileCollectionImageList.Images.SetKeyName(2, "fui");
            this.FileCollectionImageList.Images.SetKeyName(3, "loc");
            this.FileCollectionImageList.Images.SetKeyName(4, "png");
            // 
            // MainToolStrip
            // 
            this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.ButtonOpenExFolder,
            this.LabelSetName,
            this.NameTextBox,
            this.ButtonSetNameOk});
            this.MainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainToolStrip.Size = new System.Drawing.Size(378, 25);
            this.MainToolStrip.TabIndex = 1;
            this.MainToolStrip.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openFromPS3ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveToPS3ToolStripMenuItem,
            this.toolStripSeparator1,
            this.openWorkingDirectoryToolStripMenuItem,
            this.darkToolStripMenuItem,
            this.toolStripSeparator2,
            this.defaultIPToolStripMenuItem,
            this.defaultTIDToolStripMenuItem,
            this.clearDefaultsToolStripMenuItem});
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(38, 22);
            this.toolStripButton2.Text = "File";
            this.toolStripButton2.DropDownOpening += new System.EventHandler(this.toolStripButton2_DropDownOpening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem1.Text = "Save";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.saveToolStripMenuItem.Text = "Save As...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveToPS3ToolStripMenuItem
            // 
            this.saveToPS3ToolStripMenuItem.Name = "saveToPS3ToolStripMenuItem";
            this.saveToPS3ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.saveToPS3ToolStripMenuItem.Text = "Save to PS3";
            this.saveToPS3ToolStripMenuItem.Click += new System.EventHandler(this.saveToPS3ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // openWorkingDirectoryToolStripMenuItem
            // 
            this.openWorkingDirectoryToolStripMenuItem.Name = "openWorkingDirectoryToolStripMenuItem";
            this.openWorkingDirectoryToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.openWorkingDirectoryToolStripMenuItem.Text = "Open Working Directory";
            this.openWorkingDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openWorkingDirectoryToolStripMenuItem_Click);
            // 
            // darkToolStripMenuItem
            // 
            this.darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            this.darkToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.darkToolStripMenuItem.Text = "Dark";
            this.darkToolStripMenuItem.Click += new System.EventHandler(this.darkToolStripMenuItem_Click);
            // 
            // ButtonOpenExFolder
            // 
            this.ButtonOpenExFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonOpenExFolder.Image = ((System.Drawing.Image)(resources.GetObject("ButtonOpenExFolder.Image")));
            this.ButtonOpenExFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonOpenExFolder.Name = "ButtonOpenExFolder";
            this.ButtonOpenExFolder.Size = new System.Drawing.Size(143, 22);
            this.ButtonOpenExFolder.Text = "Open Extracted Directory";
            this.ButtonOpenExFolder.Click += new System.EventHandler(this.ButtonOpenExFolder_Click);
            // 
            // LabelSetName
            // 
            this.LabelSetName.Name = "LabelSetName";
            this.LabelSetName.Size = new System.Drawing.Size(58, 22);
            this.LabelSetName.Text = "Set Name";
            // 
            // NameTextBox
            // 
            this.NameTextBox.AutoToolTip = true;
            this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NameTextBox.MaxLength = 40;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 25);
            this.NameTextBox.ToolTipText = "Set an internal identificator name to this file.";
            // 
            // ButtonSetNameOk
            // 
            this.ButtonSetNameOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonSetNameOk.Image = global::ARC.Properties.Resources.ok_30px;
            this.ButtonSetNameOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSetNameOk.Name = "ButtonSetNameOk";
            this.ButtonSetNameOk.Size = new System.Drawing.Size(23, 22);
            this.ButtonSetNameOk.Text = "OK";
            this.ButtonSetNameOk.Click += new System.EventHandler(this.ButtonSetNameOk_Click);
            // 
            // OptionsContextMenuStrip
            // 
            this.OptionsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceFileToolStripMenuItem,
            this.extractFileToolStripMenuItem});
            this.OptionsContextMenuStrip.Name = "contextMenuStrip1";
            this.OptionsContextMenuStrip.Size = new System.Drawing.Size(146, 48);
            // 
            // replaceFileToolStripMenuItem
            // 
            this.replaceFileToolStripMenuItem.Name = "replaceFileToolStripMenuItem";
            this.replaceFileToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.replaceFileToolStripMenuItem.Text = "Replace File...";
            this.replaceFileToolStripMenuItem.Click += new System.EventHandler(this.replaceFileToolStripMenuItem_Click);
            // 
            // extractFileToolStripMenuItem
            // 
            this.extractFileToolStripMenuItem.Name = "extractFileToolStripMenuItem";
            this.extractFileToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.extractFileToolStripMenuItem.Text = "Extract File...";
            this.extractFileToolStripMenuItem.Click += new System.EventHandler(this.extractFileToolStripMenuItem_Click);
            // 
            // indicator
            // 
            this.indicator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.indicator.Location = new System.Drawing.Point(29, 25);
            this.indicator.Name = "indicator";
            this.indicator.Size = new System.Drawing.Size(347, 12);
            this.indicator.TabIndex = 2;
            this.indicator.Visible = false;
            // 
            // indicatorLabel
            // 
            this.indicatorLabel.AutoSize = true;
            this.indicatorLabel.BackColor = System.Drawing.Color.Transparent;
            this.indicatorLabel.Location = new System.Drawing.Point(4, 24);
            this.indicatorLabel.Name = "indicatorLabel";
            this.indicatorLabel.Size = new System.Drawing.Size(19, 13);
            this.indicatorLabel.TabIndex = 3;
            this.indicatorLabel.Text = "ok";
            // 
            // openFromPS3ToolStripMenuItem
            // 
            this.openFromPS3ToolStripMenuItem.Enabled = false;
            this.openFromPS3ToolStripMenuItem.Name = "openFromPS3ToolStripMenuItem";
            this.openFromPS3ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.openFromPS3ToolStripMenuItem.Text = "Open from PS3..";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
            // 
            // defaultIPToolStripMenuItem
            // 
            this.defaultIPToolStripMenuItem.Name = "defaultIPToolStripMenuItem";
            this.defaultIPToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.defaultIPToolStripMenuItem.Text = "Default IP...";
            this.defaultIPToolStripMenuItem.Click += new System.EventHandler(this.defaultIPToolStripMenuItem_Click);
            // 
            // defaultTIDToolStripMenuItem
            // 
            this.defaultTIDToolStripMenuItem.Name = "defaultTIDToolStripMenuItem";
            this.defaultTIDToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.defaultTIDToolStripMenuItem.Text = "Default TID...";
            // 
            // clearDefaultsToolStripMenuItem
            // 
            this.clearDefaultsToolStripMenuItem.Name = "clearDefaultsToolStripMenuItem";
            this.clearDefaultsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.clearDefaultsToolStripMenuItem.Text = "Clear Defaults...";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 288);
            this.Controls.Add(this.indicatorLabel);
            this.Controls.Add(this.indicator);
            this.Controls.Add(this.MainToolStrip);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(294, 309);
            this.Name = "Editor";
            this.Text = "ARC";
            this.Activated += new System.EventHandler(this.Editor_Activated);
            this.Deactivate += new System.EventHandler(this.Editor_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Editor_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
            this.OptionsContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStrip MainToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton2;
        private System.Windows.Forms.ImageList FileCollectionImageList;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip OptionsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem replaceFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractFileToolStripMenuItem;
        private System.Windows.Forms.ProgressBar indicator;
        private System.Windows.Forms.ToolStripButton ButtonOpenExFolder;
        private System.Windows.Forms.ToolStripLabel LabelSetName;
        private System.Windows.Forms.ToolStripTextBox NameTextBox;
        private System.Windows.Forms.ToolStripButton ButtonSetNameOk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openWorkingDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToPS3ToolStripMenuItem;
        private System.Windows.Forms.Label indicatorLabel;
        private System.Windows.Forms.ToolStripMenuItem openFromPS3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem defaultIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultTIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearDefaultsToolStripMenuItem;
    }
}

