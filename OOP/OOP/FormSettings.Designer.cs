namespace OOP
{
    partial class FormSettings
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
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.textBoxModulePath = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxImagePath = new System.Windows.Forms.TextBox();
            this.textBoxImageExt = new System.Windows.Forms.TextBox();
            this.textBoxInstrumentPath = new System.Windows.Forms.TextBox();
            this.textBoxInstrumentExt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelInstrumentPath = new System.Windows.Forms.Label();
            this.labelImageExt = new System.Windows.Forms.Label();
            this.labelImagePath = new System.Windows.Forms.Label();
            this.saveFileDialogConfig = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogConfig = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogPath = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(121, 45);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(100, 22);
            this.textBoxWidth.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height";
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(121, 73);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(100, 22);
            this.textBoxHeight.TabIndex = 3;
            // 
            // textBoxModulePath
            // 
            this.textBoxModulePath.Location = new System.Drawing.Point(121, 126);
            this.textBoxModulePath.Name = "textBoxModulePath";
            this.textBoxModulePath.ReadOnly = true;
            this.textBoxModulePath.Size = new System.Drawing.Size(236, 22);
            this.textBoxModulePath.TabIndex = 5;
            this.textBoxModulePath.Click += new System.EventHandler(this.textBoxModulePath_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(792, 28);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(117, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.loadToolStripMenuItem.Text = "Open";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // textBoxImagePath
            // 
            this.textBoxImagePath.Location = new System.Drawing.Point(472, 148);
            this.textBoxImagePath.Name = "textBoxImagePath";
            this.textBoxImagePath.ReadOnly = true;
            this.textBoxImagePath.Size = new System.Drawing.Size(314, 22);
            this.textBoxImagePath.TabIndex = 8;
            this.textBoxImagePath.Click += new System.EventHandler(this.textBoxImagePath_Click);
            // 
            // textBoxImageExt
            // 
            this.textBoxImageExt.Location = new System.Drawing.Point(472, 120);
            this.textBoxImageExt.Name = "textBoxImageExt";
            this.textBoxImageExt.Size = new System.Drawing.Size(314, 22);
            this.textBoxImageExt.TabIndex = 7;
            // 
            // textBoxInstrumentPath
            // 
            this.textBoxInstrumentPath.Location = new System.Drawing.Point(472, 73);
            this.textBoxInstrumentPath.Name = "textBoxInstrumentPath";
            this.textBoxInstrumentPath.ReadOnly = true;
            this.textBoxInstrumentPath.Size = new System.Drawing.Size(314, 22);
            this.textBoxInstrumentPath.TabIndex = 10;
            this.textBoxInstrumentPath.Click += new System.EventHandler(this.textBoxInstrumentPath_Click);
            // 
            // textBoxInstrumentExt
            // 
            this.textBoxInstrumentExt.Location = new System.Drawing.Point(472, 45);
            this.textBoxInstrumentExt.Name = "textBoxInstrumentExt";
            this.textBoxInstrumentExt.Size = new System.Drawing.Size(314, 22);
            this.textBoxInstrumentExt.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "ModulePath";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "InstrumentExt";
            // 
            // labelInstrumentPath
            // 
            this.labelInstrumentPath.AutoSize = true;
            this.labelInstrumentPath.Location = new System.Drawing.Point(363, 76);
            this.labelInstrumentPath.Name = "labelInstrumentPath";
            this.labelInstrumentPath.Size = new System.Drawing.Size(103, 17);
            this.labelInstrumentPath.TabIndex = 14;
            this.labelInstrumentPath.Text = "InstrumentPath";
            // 
            // labelImageExt
            // 
            this.labelImageExt.AutoSize = true;
            this.labelImageExt.Location = new System.Drawing.Point(391, 123);
            this.labelImageExt.Name = "labelImageExt";
            this.labelImageExt.Size = new System.Drawing.Size(65, 17);
            this.labelImageExt.TabIndex = 15;
            this.labelImageExt.Text = "ImageExt";
            // 
            // labelImagePath
            // 
            this.labelImagePath.AutoSize = true;
            this.labelImagePath.Location = new System.Drawing.Point(391, 151);
            this.labelImagePath.Name = "labelImagePath";
            this.labelImagePath.Size = new System.Drawing.Size(75, 17);
            this.labelImagePath.TabIndex = 16;
            this.labelImagePath.Text = "ImagePath";
            // 
            // openFileDialogConfig
            // 
            this.openFileDialogConfig.FileName = "openFileDialogConfig";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 176);
            this.Controls.Add(this.labelImagePath);
            this.Controls.Add(this.labelImageExt);
            this.Controls.Add(this.labelInstrumentPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxInstrumentPath);
            this.Controls.Add(this.textBoxInstrumentExt);
            this.Controls.Add(this.textBoxImagePath);
            this.Controls.Add(this.textBoxImageExt);
            this.Controls.Add(this.textBoxModulePath);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormSettings";
            this.Text = "Configuration Editor";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.TextBox textBoxModulePath;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxImagePath;
        private System.Windows.Forms.TextBox textBoxImageExt;
        private System.Windows.Forms.TextBox textBoxInstrumentPath;
        private System.Windows.Forms.TextBox textBoxInstrumentExt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelInstrumentPath;
        private System.Windows.Forms.Label labelImageExt;
        private System.Windows.Forms.Label labelImagePath;
        private System.Windows.Forms.SaveFileDialog saveFileDialogConfig;
        private System.Windows.Forms.OpenFileDialog openFileDialogConfig;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogPath;
    }
}