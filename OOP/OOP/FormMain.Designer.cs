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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelColorSelect = new System.Windows.Forms.Panel();
            this.buttonColorSelect = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.colorDialogSelect = new System.Windows.Forms.ColorDialog();
            this.labelTextThickness = new System.Windows.Forms.Label();
            this.labelThickness = new System.Windows.Forms.Label();
            this.buttonThicknessMore = new System.Windows.Forms.Button();
            this.buttonThicknessLess = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelBackgroundSelect = new System.Windows.Forms.Panel();
            this.buttonBackgroundSelect = new System.Windows.Forms.Button();
            this.colorDialogBackground = new System.Windows.Forms.ColorDialog();
            this.groupBoxShape = new System.Windows.Forms.GroupBox();
            this.panelDraw = new System.Windows.Forms.Panel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listBoxShapes = new System.Windows.Forms.ListBox();
            this.buttonEditShape = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(978, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
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
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(117, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem1,
            this.forwardToolStripMenuItem,
            this.clearToolStripMenuItem1});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // backToolStripMenuItem1
            // 
            this.backToolStripMenuItem1.Name = "backToolStripMenuItem1";
            this.backToolStripMenuItem1.Size = new System.Drawing.Size(138, 26);
            this.backToolStripMenuItem1.Text = "Back";
            this.backToolStripMenuItem1.Click += new System.EventHandler(this.backToolStripMenuItem1_Click);
            // 
            // forwardToolStripMenuItem
            // 
            this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            this.forwardToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.forwardToolStripMenuItem.Text = "Forward";
            // 
            // clearToolStripMenuItem1
            // 
            this.clearToolStripMenuItem1.Name = "clearToolStripMenuItem1";
            this.clearToolStripMenuItem1.Size = new System.Drawing.Size(138, 26);
            this.clearToolStripMenuItem1.Text = "Clear";
            this.clearToolStripMenuItem1.Click += new System.EventHandler(this.clearToolStripMenuItem1_Click);
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
            // panelBackgroundSelect
            // 
            this.panelBackgroundSelect.Location = new System.Drawing.Point(118, 6);
            this.panelBackgroundSelect.Name = "panelBackgroundSelect";
            this.panelBackgroundSelect.Size = new System.Drawing.Size(109, 16);
            this.panelBackgroundSelect.TabIndex = 4;
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
            // colorDialogBackground
            // 
            this.colorDialogBackground.Color = System.Drawing.Color.White;
            // 
            // groupBoxShape
            // 
            this.groupBoxShape.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBoxShape.Location = new System.Drawing.Point(12, 34);
            this.groupBoxShape.Name = "groupBoxShape";
            this.groupBoxShape.Size = new System.Drawing.Size(112, 205);
            this.groupBoxShape.TabIndex = 4;
            this.groupBoxShape.TabStop = false;
            this.groupBoxShape.Text = "Shape";
            // 
            // panelDraw
            // 
            this.panelDraw.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelDraw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDraw.Location = new System.Drawing.Point(130, 99);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(836, 374);
            this.panelDraw.TabIndex = 8;
            this.panelDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelDraw_MouseDown);
            this.panelDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelDraw_MouseMove);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "ic";
            this.saveFileDialog.InitialDirectory = "D:\\Crypto\\GitHub\\bsuir-labs\\OOP\\images";
            // 
            // openFileDialog
            // 
            this.openFileDialog.InitialDirectory = "D:\\Crypto\\GitHub\\bsuir-labs\\OOP\\images";
            // 
            // listBoxShapes
            // 
            this.listBoxShapes.FormattingEnabled = true;
            this.listBoxShapes.ItemHeight = 16;
            this.listBoxShapes.Location = new System.Drawing.Point(12, 248);
            this.listBoxShapes.Name = "listBoxShapes";
            this.listBoxShapes.Size = new System.Drawing.Size(112, 196);
            this.listBoxShapes.TabIndex = 9;
            this.listBoxShapes.SelectedIndexChanged += new System.EventHandler(this.listBoxShapes_SelectedIndexChanged);
            // 
            // buttonEditShape
            // 
            this.buttonEditShape.Location = new System.Drawing.Point(12, 450);
            this.buttonEditShape.Name = "buttonEditShape";
            this.buttonEditShape.Size = new System.Drawing.Size(112, 23);
            this.buttonEditShape.TabIndex = 10;
            this.buttonEditShape.Text = "Edit";
            this.buttonEditShape.UseVisualStyleBackColor = true;
            this.buttonEditShape.Click += new System.EventHandler(this.buttonEditShape_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(978, 485);
            this.Controls.Add(this.buttonEditShape);
            this.Controls.Add(this.listBoxShapes);
            this.Controls.Add(this.panelDraw);
            this.Controls.Add(this.groupBoxShape);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Graphic editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialogSelect;
        private System.Windows.Forms.Button buttonColorSelect;
        private System.Windows.Forms.Panel panelColorSelect;
        private System.Windows.Forms.Button buttonThicknessLess;
        private System.Windows.Forms.Button buttonThicknessMore;
        private System.Windows.Forms.Label labelThickness;
        private System.Windows.Forms.Label labelTextThickness;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelBackgroundSelect;
        private System.Windows.Forms.Button buttonBackgroundSelect;
        private System.Windows.Forms.ColorDialog colorDialogBackground;
        private System.Windows.Forms.GroupBox groupBoxShape;
        private System.Windows.Forms.Panel panelDraw;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox listBoxShapes;
        private System.Windows.Forms.Button buttonEditShape;
    }
}

