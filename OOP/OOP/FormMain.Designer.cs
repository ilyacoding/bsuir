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
            this.buttonClear = new System.Windows.Forms.Button();
            this.panelColorSelect = new System.Windows.Forms.Panel();
            this.buttonColorSelect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.colorDialogSelect = new System.Windows.Forms.ColorDialog();
            this.labelTextThickness = new System.Windows.Forms.Label();
            this.labelThickness = new System.Windows.Forms.Label();
            this.buttonThicknessMore = new System.Windows.Forms.Button();
            this.buttonThicknessLess = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonBackgroundSelect = new System.Windows.Forms.Button();
            this.panelBackgroundSelect = new System.Windows.Forms.Panel();
            this.colorDialogBackground = new System.Windows.Forms.ColorDialog();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDraw
            // 
            this.panelDraw.BackColor = System.Drawing.Color.White;
            this.panelDraw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDraw.Location = new System.Drawing.Point(12, 96);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(860, 332);
            this.panelDraw.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(879, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(19, 29);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // panelColorSelect
            // 
            this.panelColorSelect.Location = new System.Drawing.Point(3, 6);
            this.panelColorSelect.Name = "panelColorSelect";
            this.panelColorSelect.Size = new System.Drawing.Size(109, 16);
            this.panelColorSelect.TabIndex = 2;
            // 
            // buttonColorSelect
            // 
            this.buttonColorSelect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonColorSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonColorSelect.Location = new System.Drawing.Point(3, 28);
            this.buttonColorSelect.Name = "buttonColorSelect";
            this.buttonColorSelect.Size = new System.Drawing.Size(109, 28);
            this.buttonColorSelect.TabIndex = 1;
            this.buttonColorSelect.Text = "Select color";
            this.buttonColorSelect.UseVisualStyleBackColor = false;
            this.buttonColorSelect.Click += new System.EventHandler(this.buttonColorSelect_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelTextThickness
            // 
            this.labelTextThickness.AutoSize = true;
            this.labelTextThickness.Location = new System.Drawing.Point(15, 6);
            this.labelTextThickness.Name = "labelTextThickness";
            this.labelTextThickness.Size = new System.Drawing.Size(72, 17);
            this.labelTextThickness.TabIndex = 4;
            this.labelTextThickness.Text = "Thickness";
            // 
            // labelThickness
            // 
            this.labelThickness.AutoSize = true;
            this.labelThickness.Location = new System.Drawing.Point(42, 32);
            this.labelThickness.Name = "labelThickness";
            this.labelThickness.Size = new System.Drawing.Size(16, 17);
            this.labelThickness.TabIndex = 5;
            this.labelThickness.Text = "1";
            this.labelThickness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonThicknessMore
            // 
            this.buttonThicknessMore.Location = new System.Drawing.Point(71, 29);
            this.buttonThicknessMore.Name = "buttonThicknessMore";
            this.buttonThicknessMore.Size = new System.Drawing.Size(28, 23);
            this.buttonThicknessMore.TabIndex = 6;
            this.buttonThicknessMore.Text = ">";
            this.buttonThicknessMore.UseVisualStyleBackColor = true;
            this.buttonThicknessMore.Click += new System.EventHandler(this.buttonThicknessMore_Click);
            // 
            // buttonThicknessLess
            // 
            this.buttonThicknessLess.Location = new System.Drawing.Point(8, 29);
            this.buttonThicknessLess.Name = "buttonThicknessLess";
            this.buttonThicknessLess.Size = new System.Drawing.Size(28, 23);
            this.buttonThicknessLess.TabIndex = 7;
            this.buttonThicknessLess.Text = "<";
            this.buttonThicknessLess.UseVisualStyleBackColor = true;
            this.buttonThicknessLess.Click += new System.EventHandler(this.buttonThicknessLess_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Location = new System.Drawing.Point(12, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(112, 59);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.buttonThicknessLess);
            this.panel2.Controls.Add(this.labelTextThickness);
            this.panel2.Controls.Add(this.buttonThicknessMore);
            this.panel2.Controls.Add(this.labelThickness);
            this.panel2.Location = new System.Drawing.Point(130, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(107, 59);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.panelBackgroundSelect);
            this.panel3.Controls.Add(this.buttonBackgroundSelect);
            this.panel3.Controls.Add(this.panelColorSelect);
            this.panel3.Controls.Add(this.buttonColorSelect);
            this.panel3.Location = new System.Drawing.Point(246, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(233, 59);
            this.panel3.TabIndex = 6;
            // 
            // buttonBackgroundSelect
            // 
            this.buttonBackgroundSelect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonBackgroundSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBackgroundSelect.Location = new System.Drawing.Point(118, 28);
            this.buttonBackgroundSelect.Name = "buttonBackgroundSelect";
            this.buttonBackgroundSelect.Size = new System.Drawing.Size(109, 28);
            this.buttonBackgroundSelect.TabIndex = 3;
            this.buttonBackgroundSelect.Text = "Background";
            this.buttonBackgroundSelect.UseVisualStyleBackColor = false;
            this.buttonBackgroundSelect.Click += new System.EventHandler(this.buttonBackgroundSelect_Click);
            // 
            // panelBackgroundSelect
            // 
            this.panelBackgroundSelect.Location = new System.Drawing.Point(118, 6);
            this.panelBackgroundSelect.Name = "panelBackgroundSelect";
            this.panelBackgroundSelect.Size = new System.Drawing.Size(109, 16);
            this.panelBackgroundSelect.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(879, 435);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelDraw);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Graphic editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panelDraw;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialogSelect;
        private System.Windows.Forms.Button buttonColorSelect;
        private System.Windows.Forms.Panel panelColorSelect;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonThicknessLess;
        private System.Windows.Forms.Button buttonThicknessMore;
        private System.Windows.Forms.Label labelThickness;
        private System.Windows.Forms.Label labelTextThickness;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelBackgroundSelect;
        private System.Windows.Forms.Button buttonBackgroundSelect;
        private System.Windows.Forms.ColorDialog colorDialogBackground;
    }
}

