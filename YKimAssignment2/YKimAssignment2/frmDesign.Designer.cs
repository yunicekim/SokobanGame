namespace YKimAssignment2
{
    partial class frmDesign
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesign));
            this.pnlInput = new System.Windows.Forms.Panel();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblColumns = new System.Windows.Forms.Label();
            this.lblRows = new System.Windows.Forms.Label();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlToolBox = new System.Windows.Forms.Panel();
            this.rdoDestination = new System.Windows.Forms.RadioButton();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.rdoBox = new System.Windows.Forms.RadioButton();
            this.rdoWall = new System.Windows.Forms.RadioButton();
            this.rdoHero = new System.Windows.Forms.RadioButton();
            this.rdoNone = new System.Windows.Forms.RadioButton();
            this.lblToolBox = new System.Windows.Forms.Label();
            this.pnlGameBoard = new System.Windows.Forms.Panel();
            this.pnlInput.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.pnlToolBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.btnGenerate);
            this.pnlInput.Controls.Add(this.lblColumns);
            this.pnlInput.Controls.Add(this.lblRows);
            this.pnlInput.Controls.Add(this.txtColumns);
            this.pnlInput.Controls.Add(this.txtRows);
            this.pnlInput.Location = new System.Drawing.Point(0, 21);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(804, 64);
            this.pnlInput.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(378, 17);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(60, 28);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Location = new System.Drawing.Point(220, 25);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(47, 13);
            this.lblColumns.TabIndex = 8;
            this.lblColumns.Text = "Columns";
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(65, 25);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(34, 13);
            this.lblRows.TabIndex = 7;
            this.lblRows.Text = "Rows";
            // 
            // txtColumns
            // 
            this.txtColumns.Location = new System.Drawing.Point(269, 22);
            this.txtColumns.Name = "txtColumns";
            this.txtColumns.Size = new System.Drawing.Size(84, 20);
            this.txtColumns.TabIndex = 6;
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(105, 22);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(84, 20);
            this.txtRows.TabIndex = 5;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // pnlToolBox
            // 
            this.pnlToolBox.Controls.Add(this.rdoDestination);
            this.pnlToolBox.Controls.Add(this.rdoBox);
            this.pnlToolBox.Controls.Add(this.rdoWall);
            this.pnlToolBox.Controls.Add(this.rdoHero);
            this.pnlToolBox.Controls.Add(this.rdoNone);
            this.pnlToolBox.Controls.Add(this.lblToolBox);
            this.pnlToolBox.Location = new System.Drawing.Point(0, 85);
            this.pnlToolBox.Name = "pnlToolBox";
            this.pnlToolBox.Size = new System.Drawing.Size(189, 400);
            this.pnlToolBox.TabIndex = 2;
            // 
            // rdoDestination
            // 
            this.rdoDestination.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoDestination.BackColor = System.Drawing.Color.Silver;
            this.rdoDestination.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rdoDestination.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdoDestination.ImageIndex = 4;
            this.rdoDestination.ImageList = this.imgLst;
            this.rdoDestination.Location = new System.Drawing.Point(29, 321);
            this.rdoDestination.Name = "rdoDestination";
            this.rdoDestination.Size = new System.Drawing.Size(130, 50);
            this.rdoDestination.TabIndex = 11;
            this.rdoDestination.Text = "Destination";
            this.rdoDestination.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoDestination.UseVisualStyleBackColor = false;
            this.rdoDestination.CheckedChanged += new System.EventHandler(this.Tool_CheckedChanged);
            // 
            // imgLst
            // 
            this.imgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst.ImageStream")));
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst.Images.SetKeyName(0, "None.bmp");
            this.imgLst.Images.SetKeyName(1, "Hero.bmp");
            this.imgLst.Images.SetKeyName(2, "Wall.bmp");
            this.imgLst.Images.SetKeyName(3, "Box.bmp");
            this.imgLst.Images.SetKeyName(4, "Destination.bmp");
            // 
            // rdoBox
            // 
            this.rdoBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBox.BackColor = System.Drawing.Color.Silver;
            this.rdoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rdoBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdoBox.ImageIndex = 3;
            this.rdoBox.ImageList = this.imgLst;
            this.rdoBox.Location = new System.Drawing.Point(29, 253);
            this.rdoBox.Name = "rdoBox";
            this.rdoBox.Size = new System.Drawing.Size(130, 50);
            this.rdoBox.TabIndex = 10;
            this.rdoBox.Text = "Box";
            this.rdoBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoBox.UseVisualStyleBackColor = false;
            this.rdoBox.CheckedChanged += new System.EventHandler(this.Tool_CheckedChanged);
            // 
            // rdoWall
            // 
            this.rdoWall.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoWall.BackColor = System.Drawing.Color.Silver;
            this.rdoWall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rdoWall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdoWall.ImageIndex = 2;
            this.rdoWall.ImageList = this.imgLst;
            this.rdoWall.Location = new System.Drawing.Point(29, 181);
            this.rdoWall.Name = "rdoWall";
            this.rdoWall.Size = new System.Drawing.Size(130, 50);
            this.rdoWall.TabIndex = 9;
            this.rdoWall.Text = "Wall";
            this.rdoWall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoWall.UseVisualStyleBackColor = false;
            this.rdoWall.CheckedChanged += new System.EventHandler(this.Tool_CheckedChanged);
            // 
            // rdoHero
            // 
            this.rdoHero.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoHero.BackColor = System.Drawing.Color.Silver;
            this.rdoHero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rdoHero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdoHero.ImageIndex = 1;
            this.rdoHero.ImageList = this.imgLst;
            this.rdoHero.Location = new System.Drawing.Point(29, 110);
            this.rdoHero.Name = "rdoHero";
            this.rdoHero.Size = new System.Drawing.Size(130, 50);
            this.rdoHero.TabIndex = 8;
            this.rdoHero.Text = "Hero";
            this.rdoHero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoHero.UseVisualStyleBackColor = false;
            this.rdoHero.CheckedChanged += new System.EventHandler(this.Tool_CheckedChanged);
            // 
            // rdoNone
            // 
            this.rdoNone.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoNone.BackColor = System.Drawing.Color.Silver;
            this.rdoNone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rdoNone.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoNone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdoNone.ImageIndex = 0;
            this.rdoNone.ImageList = this.imgLst;
            this.rdoNone.Location = new System.Drawing.Point(29, 38);
            this.rdoNone.Name = "rdoNone";
            this.rdoNone.Size = new System.Drawing.Size(130, 50);
            this.rdoNone.TabIndex = 7;
            this.rdoNone.Text = "None";
            this.rdoNone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoNone.UseVisualStyleBackColor = false;
            this.rdoNone.CheckedChanged += new System.EventHandler(this.Tool_CheckedChanged);
            // 
            // lblToolBox
            // 
            this.lblToolBox.AutoSize = true;
            this.lblToolBox.Location = new System.Drawing.Point(66, 7);
            this.lblToolBox.Name = "lblToolBox";
            this.lblToolBox.Size = new System.Drawing.Size(49, 13);
            this.lblToolBox.TabIndex = 6;
            this.lblToolBox.Text = "Tool Box";
            // 
            // pnlGameBoard
            // 
            this.pnlGameBoard.Location = new System.Drawing.Point(190, 86);
            this.pnlGameBoard.Name = "pnlGameBoard";
            this.pnlGameBoard.Size = new System.Drawing.Size(990, 570);
            this.pnlGameBoard.TabIndex = 3;
            // 
            // frmDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlGameBoard);
            this.Controls.Add(this.pnlToolBox);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmDesign";
            this.Text = "frmDesign";
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.pnlToolBox.ResumeLayout(false);
            this.pnlToolBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.Panel pnlToolBox;
        private System.Windows.Forms.Panel pnlGameBoard;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.TextBox txtColumns;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.RadioButton rdoDestination;
        private System.Windows.Forms.RadioButton rdoBox;
        private System.Windows.Forms.RadioButton rdoWall;
        private System.Windows.Forms.RadioButton rdoHero;
        private System.Windows.Forms.RadioButton rdoNone;
        private System.Windows.Forms.Label lblToolBox;
        private System.Windows.Forms.ImageList imgLst;
    }
}