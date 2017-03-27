﻿namespace OOP
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
            this.shapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listBoxShapes = new System.Windows.Forms.ListBox();
            this.panelEditShapes = new System.Windows.Forms.Panel();
            this.buttonUnSelect = new System.Windows.Forms.Button();
            this.buttonMoveShape = new System.Windows.Forms.Button();
            this.buttonEditShape = new System.Windows.Forms.Button();
            this.pictureBoxDraw = new System.Windows.Forms.PictureBox();
            this.groupBoxInstruments = new System.Windows.Forms.GroupBox();
            this.layerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateStaticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelEditShapes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDraw)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.shapesToolStripMenuItem,
            this.instrumentToolStripMenuItem,
            this.layerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
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
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // backToolStripMenuItem1
            // 
            this.backToolStripMenuItem1.Name = "backToolStripMenuItem1";
            this.backToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.backToolStripMenuItem1.Text = "Back";
            this.backToolStripMenuItem1.Click += new System.EventHandler(this.backToolStripMenuItem1_Click);
            // 
            // forwardToolStripMenuItem
            // 
            this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            this.forwardToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.forwardToolStripMenuItem.Text = "Forward";
            // 
            // clearToolStripMenuItem1
            // 
            this.clearToolStripMenuItem1.Name = "clearToolStripMenuItem1";
            this.clearToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.clearToolStripMenuItem1.Text = "Clear";
            this.clearToolStripMenuItem1.Click += new System.EventHandler(this.clearToolStripMenuItem1_Click);
            // 
            // shapesToolStripMenuItem
            // 
            this.shapesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem});
            this.shapesToolStripMenuItem.Name = "shapesToolStripMenuItem";
            this.shapesToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.shapesToolStripMenuItem.Text = "Shapes";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // instrumentToolStripMenuItem
            // 
            this.instrumentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.loadToolStripMenuItem1});
            this.instrumentToolStripMenuItem.Name = "instrumentToolStripMenuItem";
            this.instrumentToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.instrumentToolStripMenuItem.Text = "Instrument";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem1.Text = "Load";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // panelColorSelect
            // 
            this.panelColorSelect.Location = new System.Drawing.Point(2, 5);
            this.panelColorSelect.Margin = new System.Windows.Forms.Padding(2);
            this.panelColorSelect.Name = "panelColorSelect";
            this.panelColorSelect.Size = new System.Drawing.Size(82, 13);
            this.panelColorSelect.TabIndex = 2;
            // 
            // buttonColorSelect
            // 
            this.buttonColorSelect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonColorSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonColorSelect.Location = new System.Drawing.Point(2, 23);
            this.buttonColorSelect.Margin = new System.Windows.Forms.Padding(2);
            this.buttonColorSelect.Name = "buttonColorSelect";
            this.buttonColorSelect.Size = new System.Drawing.Size(82, 23);
            this.buttonColorSelect.TabIndex = 1;
            this.buttonColorSelect.Text = "Select color";
            this.buttonColorSelect.UseVisualStyleBackColor = false;
            this.buttonColorSelect.Click += new System.EventHandler(this.buttonColorSelect_Click);
            // 
            // labelTextThickness
            // 
            this.labelTextThickness.AutoSize = true;
            this.labelTextThickness.Location = new System.Drawing.Point(11, 5);
            this.labelTextThickness.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTextThickness.Name = "labelTextThickness";
            this.labelTextThickness.Size = new System.Drawing.Size(56, 13);
            this.labelTextThickness.TabIndex = 4;
            this.labelTextThickness.Text = "Thickness";
            // 
            // labelThickness
            // 
            this.labelThickness.AutoSize = true;
            this.labelThickness.Location = new System.Drawing.Point(32, 26);
            this.labelThickness.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelThickness.Name = "labelThickness";
            this.labelThickness.Size = new System.Drawing.Size(13, 13);
            this.labelThickness.TabIndex = 5;
            this.labelThickness.Text = "1";
            this.labelThickness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonThicknessMore
            // 
            this.buttonThicknessMore.Location = new System.Drawing.Point(53, 24);
            this.buttonThicknessMore.Margin = new System.Windows.Forms.Padding(2);
            this.buttonThicknessMore.Name = "buttonThicknessMore";
            this.buttonThicknessMore.Size = new System.Drawing.Size(21, 19);
            this.buttonThicknessMore.TabIndex = 6;
            this.buttonThicknessMore.Text = ">";
            this.buttonThicknessMore.UseVisualStyleBackColor = true;
            this.buttonThicknessMore.Click += new System.EventHandler(this.buttonThicknessMore_Click);
            // 
            // buttonThicknessLess
            // 
            this.buttonThicknessLess.Location = new System.Drawing.Point(6, 24);
            this.buttonThicknessLess.Margin = new System.Windows.Forms.Padding(2);
            this.buttonThicknessLess.Name = "buttonThicknessLess";
            this.buttonThicknessLess.Size = new System.Drawing.Size(21, 19);
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
            this.panel2.Location = new System.Drawing.Point(98, 28);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(80, 48);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.panelBackgroundSelect);
            this.panel3.Controls.Add(this.buttonBackgroundSelect);
            this.panel3.Controls.Add(this.panelColorSelect);
            this.panel3.Controls.Add(this.buttonColorSelect);
            this.panel3.Location = new System.Drawing.Point(184, 28);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(175, 48);
            this.panel3.TabIndex = 6;
            // 
            // panelBackgroundSelect
            // 
            this.panelBackgroundSelect.Location = new System.Drawing.Point(88, 5);
            this.panelBackgroundSelect.Margin = new System.Windows.Forms.Padding(2);
            this.panelBackgroundSelect.Name = "panelBackgroundSelect";
            this.panelBackgroundSelect.Size = new System.Drawing.Size(82, 13);
            this.panelBackgroundSelect.TabIndex = 4;
            // 
            // buttonBackgroundSelect
            // 
            this.buttonBackgroundSelect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonBackgroundSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBackgroundSelect.Location = new System.Drawing.Point(88, 23);
            this.buttonBackgroundSelect.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBackgroundSelect.Name = "buttonBackgroundSelect";
            this.buttonBackgroundSelect.Size = new System.Drawing.Size(82, 23);
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
            this.groupBoxShape.Location = new System.Drawing.Point(9, 28);
            this.groupBoxShape.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxShape.Name = "groupBoxShape";
            this.groupBoxShape.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxShape.Size = new System.Drawing.Size(84, 167);
            this.groupBoxShape.TabIndex = 4;
            this.groupBoxShape.TabStop = false;
            this.groupBoxShape.Text = "Shape";
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
            this.listBoxShapes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listBoxShapes.FormattingEnabled = true;
            this.listBoxShapes.Location = new System.Drawing.Point(9, 344);
            this.listBoxShapes.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxShapes.Name = "listBoxShapes";
            this.listBoxShapes.Size = new System.Drawing.Size(85, 56);
            this.listBoxShapes.TabIndex = 9;
            this.listBoxShapes.SelectedIndexChanged += new System.EventHandler(this.listBoxShapes_SelectedIndexChanged);
            // 
            // panelEditShapes
            // 
            this.panelEditShapes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelEditShapes.Controls.Add(this.buttonUnSelect);
            this.panelEditShapes.Controls.Add(this.buttonMoveShape);
            this.panelEditShapes.Controls.Add(this.buttonEditShape);
            this.panelEditShapes.Location = new System.Drawing.Point(364, 28);
            this.panelEditShapes.Margin = new System.Windows.Forms.Padding(2);
            this.panelEditShapes.Name = "panelEditShapes";
            this.panelEditShapes.Size = new System.Drawing.Size(148, 48);
            this.panelEditShapes.TabIndex = 11;
            // 
            // buttonUnSelect
            // 
            this.buttonUnSelect.Location = new System.Drawing.Point(71, 2);
            this.buttonUnSelect.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUnSelect.Name = "buttonUnSelect";
            this.buttonUnSelect.Size = new System.Drawing.Size(72, 42);
            this.buttonUnSelect.TabIndex = 12;
            this.buttonUnSelect.Text = "End edit";
            this.buttonUnSelect.UseVisualStyleBackColor = true;
            this.buttonUnSelect.Click += new System.EventHandler(this.buttonUnSelect_Click);
            // 
            // buttonMoveShape
            // 
            this.buttonMoveShape.Location = new System.Drawing.Point(10, 2);
            this.buttonMoveShape.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMoveShape.Name = "buttonMoveShape";
            this.buttonMoveShape.Size = new System.Drawing.Size(56, 19);
            this.buttonMoveShape.TabIndex = 1;
            this.buttonMoveShape.Text = "Move";
            this.buttonMoveShape.UseVisualStyleBackColor = true;
            this.buttonMoveShape.Click += new System.EventHandler(this.buttonMoveShape_Click);
            // 
            // buttonEditShape
            // 
            this.buttonEditShape.Location = new System.Drawing.Point(10, 26);
            this.buttonEditShape.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEditShape.Name = "buttonEditShape";
            this.buttonEditShape.Size = new System.Drawing.Size(56, 19);
            this.buttonEditShape.TabIndex = 0;
            this.buttonEditShape.Text = "Edit";
            this.buttonEditShape.UseVisualStyleBackColor = true;
            this.buttonEditShape.Click += new System.EventHandler(this.buttonEditShape_Click);
            // 
            // pictureBoxDraw
            // 
            this.pictureBoxDraw.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBoxDraw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxDraw.Location = new System.Drawing.Point(98, 80);
            this.pictureBoxDraw.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxDraw.Name = "pictureBoxDraw";
            this.pictureBoxDraw.Size = new System.Drawing.Size(628, 320);
            this.pictureBoxDraw.TabIndex = 12;
            this.pictureBoxDraw.TabStop = false;
            this.pictureBoxDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDraw_MouseDown);
            this.pictureBoxDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDraw_MouseMove);
            // 
            // groupBoxInstruments
            // 
            this.groupBoxInstruments.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBoxInstruments.Location = new System.Drawing.Point(9, 199);
            this.groupBoxInstruments.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxInstruments.Name = "groupBoxInstruments";
            this.groupBoxInstruments.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxInstruments.Size = new System.Drawing.Size(84, 141);
            this.groupBoxInstruments.TabIndex = 13;
            this.groupBoxInstruments.TabStop = false;
            this.groupBoxInstruments.Text = "Instruments";
            // 
            // layerToolStripMenuItem
            // 
            this.layerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateStaticToolStripMenuItem});
            this.layerToolStripMenuItem.Name = "layerToolStripMenuItem";
            this.layerToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.layerToolStripMenuItem.Text = "Layer";
            // 
            // updateStaticToolStripMenuItem
            // 
            this.updateStaticToolStripMenuItem.Name = "updateStaticToolStripMenuItem";
            this.updateStaticToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.updateStaticToolStripMenuItem.Text = "UpdateStatic";
            this.updateStaticToolStripMenuItem.Click += new System.EventHandler(this.updateStaticToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(734, 405);
            this.Controls.Add(this.groupBoxInstruments);
            this.Controls.Add(this.listBoxShapes);
            this.Controls.Add(this.pictureBoxDraw);
            this.Controls.Add(this.panelEditShapes);
            this.Controls.Add(this.groupBoxShape);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "Graphic editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelEditShapes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDraw)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox listBoxShapes;
        private System.Windows.Forms.Panel panelEditShapes;
        private System.Windows.Forms.Button buttonMoveShape;
        private System.Windows.Forms.Button buttonEditShape;
        private System.Windows.Forms.Button buttonUnSelect;
        private System.Windows.Forms.PictureBox pictureBoxDraw;
        private System.Windows.Forms.ToolStripMenuItem shapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instrumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBoxInstruments;
        private System.Windows.Forms.ToolStripMenuItem layerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateStaticToolStripMenuItem;
    }
}

