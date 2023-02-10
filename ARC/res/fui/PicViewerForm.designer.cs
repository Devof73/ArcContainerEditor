
namespace FuiEditor.Forms
{
    partial class PicViewerForm
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
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.ButtonZoomPlus = new System.Windows.Forms.Button();
            this.ButtonZoomMinus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(459, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.Location = new System.Drawing.Point(0, 247);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(459, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Dump..";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(459, 224);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button3.Location = new System.Drawing.Point(0, 224);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(459, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Reverse Image Color";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button4.Location = new System.Drawing.Point(0, 293);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(459, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Copy";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // ButtonZoomPlus
            // 
            this.ButtonZoomPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonZoomPlus.Location = new System.Drawing.Point(424, 168);
            this.ButtonZoomPlus.Name = "ButtonZoomPlus";
            this.ButtonZoomPlus.Size = new System.Drawing.Size(23, 22);
            this.ButtonZoomPlus.TabIndex = 4;
            this.ButtonZoomPlus.Text = "➕";
            this.ButtonZoomPlus.UseVisualStyleBackColor = true;
            this.ButtonZoomPlus.Click += new System.EventHandler(this.ButtonZoomPlus_Click);
            // 
            // ButtonZoomMinus
            // 
            this.ButtonZoomMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonZoomMinus.Location = new System.Drawing.Point(424, 196);
            this.ButtonZoomMinus.Name = "ButtonZoomMinus";
            this.ButtonZoomMinus.Size = new System.Drawing.Size(23, 22);
            this.ButtonZoomMinus.TabIndex = 5;
            this.ButtonZoomMinus.Text = "➖";
            this.ButtonZoomMinus.UseVisualStyleBackColor = true;
            this.ButtonZoomMinus.Click += new System.EventHandler(this.ButtonZoomMinus_Click);
            // 
            // PicViewerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(459, 316);
            this.Controls.Add(this.ButtonZoomMinus);
            this.Controls.Add(this.ButtonZoomPlus);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "PicViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PicViewerForm_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.PicViewer_ResizeEnd);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PicViewer_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button ButtonZoomPlus;
        private System.Windows.Forms.Button ButtonZoomMinus;
    }
}