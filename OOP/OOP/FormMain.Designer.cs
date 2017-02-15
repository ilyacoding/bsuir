namespace OOP
{
    partial class FormMain
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
            this.panelDraw = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSelect = new System.Windows.Forms.Panel();
            this.panelColorSelect = new System.Windows.Forms.Panel();
            this.buttonColorSelect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.colorDialogSelect = new System.Windows.Forms.ColorDialog();
            this.buttonClear = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panelSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDraw
            // 
            this.panelDraw.BackColor = System.Drawing.SystemColors.Info;
            this.panelDraw.Location = new System.Drawing.Point(133, 37);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(739, 391);
            this.panelDraw.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(875, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // panelSelect
            // 
            this.panelSelect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelSelect.Controls.Add(this.buttonClear);
            this.panelSelect.Controls.Add(this.panelColorSelect);
            this.panelSelect.Controls.Add(this.buttonColorSelect);
            this.panelSelect.Controls.Add(this.button1);
            this.panelSelect.Location = new System.Drawing.Point(12, 37);
            this.panelSelect.Name = "panelSelect";
            this.panelSelect.Size = new System.Drawing.Size(115, 391);
            this.panelSelect.TabIndex = 3;
            // 
            // panelColorSelect
            // 
            this.panelColorSelect.Location = new System.Drawing.Point(3, 334);
            this.panelColorSelect.Name = "panelColorSelect";
            this.panelColorSelect.Size = new System.Drawing.Size(109, 20);
            this.panelColorSelect.TabIndex = 2;
            // 
            // buttonColorSelect
            // 
            this.buttonColorSelect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonColorSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonColorSelect.Location = new System.Drawing.Point(3, 360);
            this.buttonColorSelect.Name = "buttonColorSelect";
            this.buttonColorSelect.Size = new System.Drawing.Size(109, 28);
            this.buttonColorSelect.TabIndex = 1;
            this.buttonColorSelect.Text = "Select color";
            this.buttonColorSelect.UseVisualStyleBackColor = false;
            this.buttonColorSelect.Click += new System.EventHandler(this.buttonColorSelect_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(22, 45);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 432);
            this.Controls.Add(this.panelSelect);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelDraw);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Graphic editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelSelect.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panelDraw;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panelSelect;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialogSelect;
        private System.Windows.Forms.Button buttonColorSelect;
        private System.Windows.Forms.Panel panelColorSelect;
        private System.Windows.Forms.Button buttonClear;
    }
}

