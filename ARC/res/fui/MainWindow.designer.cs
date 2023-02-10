namespace FuiEditor.Forms
{
    partial class MainWindow
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.fileStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileStripMenuSeparatorOpenSave = new System.Windows.Forms.ToolStripSeparator();
            this.fileSaveStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveAsStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveAllImagesStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileStripMenuSeparatorSaveExit = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.statusLabel = new System.Windows.Forms.Label();
            this.imageMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.invertColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSaveStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.imageReplaceStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.imageEditAttributeStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.imageBulkMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageBulkSave = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PicPreview = new System.Windows.Forms.PictureBox();
            this.PreviewLoadingIndicator = new System.Windows.Forms.ProgressBar();
            this.ButtonStopPreview = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LabelSelectedIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelTotalEntries = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelSelImgSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.ImgLoadingIndicator = new System.Windows.Forms.ProgressBar();
            this.darkModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListView = new FuiEditor.Forms.ChangableMenuListView();
            this.menuStrip.SuspendLayout();
            this.imageMenuStrip.SuspendLayout();
            this.imageBulkMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPreview)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileStripMenu
            // 
            this.fileStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOpenStripMenu,
            this.fileStripMenuSeparatorOpenSave,
            this.fileSaveStripMenu,
            this.fileSaveAsStripMenu,
            this.darkModeToolStripMenuItem,
            this.fileSaveAllImagesStripMenu,
            this.fileStripMenuSeparatorSaveExit,
            this.fileExitStripMenu});
            this.fileStripMenu.Name = "fileStripMenu";
            resources.ApplyResources(this.fileStripMenu, "fileStripMenu");
            // 
            // fileOpenStripMenu
            // 
            this.fileOpenStripMenu.Name = "fileOpenStripMenu";
            resources.ApplyResources(this.fileOpenStripMenu, "fileOpenStripMenu");
            this.fileOpenStripMenu.Click += new System.EventHandler(this.OnClickFileOpen);
            // 
            // fileStripMenuSeparatorOpenSave
            // 
            this.fileStripMenuSeparatorOpenSave.Name = "fileStripMenuSeparatorOpenSave";
            resources.ApplyResources(this.fileStripMenuSeparatorOpenSave, "fileStripMenuSeparatorOpenSave");
            // 
            // fileSaveStripMenu
            // 
            resources.ApplyResources(this.fileSaveStripMenu, "fileSaveStripMenu");
            this.fileSaveStripMenu.Name = "fileSaveStripMenu";
            this.fileSaveStripMenu.Click += new System.EventHandler(this.OnClickFileSave);
            // 
            // fileSaveAsStripMenu
            // 
            resources.ApplyResources(this.fileSaveAsStripMenu, "fileSaveAsStripMenu");
            this.fileSaveAsStripMenu.Name = "fileSaveAsStripMenu";
            this.fileSaveAsStripMenu.Click += new System.EventHandler(this.OnClickFileSaveAs);
            // 
            // fileSaveAllImagesStripMenu
            // 
            resources.ApplyResources(this.fileSaveAllImagesStripMenu, "fileSaveAllImagesStripMenu");
            this.fileSaveAllImagesStripMenu.Name = "fileSaveAllImagesStripMenu";
            this.fileSaveAllImagesStripMenu.Click += new System.EventHandler(this.OnClickFileSaveAllImages);
            // 
            // fileStripMenuSeparatorSaveExit
            // 
            this.fileStripMenuSeparatorSaveExit.Name = "fileStripMenuSeparatorSaveExit";
            resources.ApplyResources(this.fileStripMenuSeparatorSaveExit, "fileStripMenuSeparatorSaveExit");
            // 
            // fileExitStripMenu
            // 
            this.fileExitStripMenu.Name = "fileExitStripMenu";
            resources.ApplyResources(this.fileExitStripMenu, "fileExitStripMenu");
            this.fileExitStripMenu.Click += new System.EventHandler(this.OnClickFileExit);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileStripMenu});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // statusLabel
            // 
            resources.ApplyResources(this.statusLabel, "statusLabel");
            this.statusLabel.Name = "statusLabel";
            // 
            // imageMenuStrip
            // 
            this.imageMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invertColorToolStripMenuItem,
            this.imageSaveStripMenu,
            this.imageReplaceStripMenu,
            this.imageEditAttributeStripMenu});
            this.imageMenuStrip.Name = "contextMenuStrip1";
            resources.ApplyResources(this.imageMenuStrip, "imageMenuStrip");
            // 
            // invertColorToolStripMenuItem
            // 
            this.invertColorToolStripMenuItem.Name = "invertColorToolStripMenuItem";
            resources.ApplyResources(this.invertColorToolStripMenuItem, "invertColorToolStripMenuItem");
            this.invertColorToolStripMenuItem.Click += new System.EventHandler(this.invertColorToolStripMenuItem_Click);
            // 
            // imageSaveStripMenu
            // 
            this.imageSaveStripMenu.Name = "imageSaveStripMenu";
            resources.ApplyResources(this.imageSaveStripMenu, "imageSaveStripMenu");
            this.imageSaveStripMenu.Click += new System.EventHandler(this.OnClickImageSave);
            // 
            // imageReplaceStripMenu
            // 
            this.imageReplaceStripMenu.Name = "imageReplaceStripMenu";
            resources.ApplyResources(this.imageReplaceStripMenu, "imageReplaceStripMenu");
            this.imageReplaceStripMenu.Click += new System.EventHandler(this.OnClickImageReplace);
            // 
            // imageEditAttributeStripMenu
            // 
            this.imageEditAttributeStripMenu.Name = "imageEditAttributeStripMenu";
            resources.ApplyResources(this.imageEditAttributeStripMenu, "imageEditAttributeStripMenu");
            this.imageEditAttributeStripMenu.Click += new System.EventHandler(this.OnClickImageEditAttribute);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            resources.ApplyResources(this.imageList, "imageList");
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageBulkMenuStrip
            // 
            this.imageBulkMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageBulkSave});
            this.imageBulkMenuStrip.Name = "imageBulkMenuStrip";
            resources.ApplyResources(this.imageBulkMenuStrip, "imageBulkMenuStrip");
            // 
            // imageBulkSave
            // 
            this.imageBulkSave.Name = "imageBulkSave";
            resources.ApplyResources(this.imageBulkSave, "imageBulkSave");
            this.imageBulkSave.Click += new System.EventHandler(this.OnClickImagesSave);
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.imageListView);
            this.splitContainer1.Panel1.Controls.Add(this.ImgLoadingIndicator);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PicPreview);
            this.splitContainer1.Panel2.Controls.Add(this.PreviewLoadingIndicator);
            this.splitContainer1.Panel2.Controls.Add(this.ButtonStopPreview);
            // 
            // PicPreview
            // 
            resources.ApplyResources(this.PicPreview, "PicPreview");
            this.PicPreview.Name = "PicPreview";
            this.PicPreview.TabStop = false;
            // 
            // PreviewLoadingIndicator
            // 
            resources.ApplyResources(this.PreviewLoadingIndicator, "PreviewLoadingIndicator");
            this.PreviewLoadingIndicator.MarqueeAnimationSpeed = 10;
            this.PreviewLoadingIndicator.Name = "PreviewLoadingIndicator";
            this.PreviewLoadingIndicator.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.PreviewLoadingIndicator.Value = 1;
            // 
            // ButtonStopPreview
            // 
            resources.ApplyResources(this.ButtonStopPreview, "ButtonStopPreview");
            this.ButtonStopPreview.Name = "ButtonStopPreview";
            this.ButtonStopPreview.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelSelectedIndex,
            this.LabelTotalEntries,
            this.LabelSelImgSize});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // LabelSelectedIndex
            // 
            this.LabelSelectedIndex.Name = "LabelSelectedIndex";
            resources.ApplyResources(this.LabelSelectedIndex, "LabelSelectedIndex");
            // 
            // LabelTotalEntries
            // 
            this.LabelTotalEntries.Name = "LabelTotalEntries";
            resources.ApplyResources(this.LabelTotalEntries, "LabelTotalEntries");
            // 
            // LabelSelImgSize
            // 
            this.LabelSelImgSize.Name = "LabelSelImgSize";
            resources.ApplyResources(this.LabelSelImgSize, "LabelSelImgSize");
            // 
            // ImgLoadingIndicator
            // 
            resources.ApplyResources(this.ImgLoadingIndicator, "ImgLoadingIndicator");
            this.ImgLoadingIndicator.MarqueeAnimationSpeed = 10;
            this.ImgLoadingIndicator.Name = "ImgLoadingIndicator";
            this.ImgLoadingIndicator.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ImgLoadingIndicator.Value = 50;
            // 
            // darkModeToolStripMenuItem
            // 
            this.darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            resources.ApplyResources(this.darkModeToolStripMenuItem, "darkModeToolStripMenuItem");
            this.darkModeToolStripMenuItem.Click += new System.EventHandler(this.darkModeToolStripMenuItem_Click);
            // 
            // imageListView
            // 
            this.imageListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.imageListView, "imageListView");
            this.imageListView.HideSelection = false;
            this.imageListView.LargeImageList = this.imageList;
            this.imageListView.MultiSelectedContextMenuStrip = this.imageBulkMenuStrip;
            this.imageListView.Name = "imageListView";
            this.imageListView.SingleSelectedContextMenuStrip = this.imageMenuStrip;
            this.imageListView.SmallImageList = this.imageList;
            this.imageListView.StateImageList = this.imageList;
            this.imageListView.TileSize = new System.Drawing.Size(100, 100);
            this.imageListView.UseCompatibleStateImageBehavior = false;
            this.imageListView.SelectedIndexChanged += new System.EventHandler(this.imageListView_SelectedIndexChanged);
            this.imageListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imageListView_MouseDoubleClick);
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.imageMenuStrip.ResumeLayout(false);
            this.imageBulkMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicPreview)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripMenuItem fileStripMenu;
        private System.Windows.Forms.ToolStripMenuItem fileOpenStripMenu;
        private System.Windows.Forms.ToolStripMenuItem fileSaveStripMenu;
        private System.Windows.Forms.ToolStripMenuItem fileSaveAsStripMenu;
        private System.Windows.Forms.ToolStripMenuItem fileExitStripMenu;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Label statusLabel;
        private ChangableMenuListView imageListView;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip imageMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem imageReplaceStripMenu;
        private System.Windows.Forms.ToolStripMenuItem imageSaveStripMenu;
        private System.Windows.Forms.ToolStripSeparator fileStripMenuSeparatorOpenSave;
        private System.Windows.Forms.ToolStripMenuItem fileSaveAllImagesStripMenu;
        private System.Windows.Forms.ToolStripSeparator fileStripMenuSeparatorSaveExit;
        private System.Windows.Forms.ContextMenuStrip imageBulkMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem imageBulkSave;
        private System.Windows.Forms.ToolStripMenuItem imageEditAttributeStripMenu;
        private System.Windows.Forms.ToolStripMenuItem invertColorToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox PicPreview;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LabelSelectedIndex;
        private System.Windows.Forms.ToolStripStatusLabel LabelTotalEntries;
        private System.Windows.Forms.ToolStripStatusLabel LabelSelImgSize;
        private System.Windows.Forms.ProgressBar PreviewLoadingIndicator;
        private System.Windows.Forms.Button ButtonStopPreview;
        private System.Windows.Forms.ProgressBar ImgLoadingIndicator;
        private System.Windows.Forms.ToolStripMenuItem darkModeToolStripMenuItem;
    }
}

