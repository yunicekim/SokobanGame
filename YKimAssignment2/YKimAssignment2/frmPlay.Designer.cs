namespace YKimAssignment2
{
    partial class frmPlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlay));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlGameBoard = new System.Windows.Forms.Panel();
            this.pnlMovingOperator = new System.Windows.Forms.Panel();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.pnlNumersOfMoving = new System.Windows.Forms.Panel();
            this.lblNumbersOfPush = new System.Windows.Forms.Label();
            this.lblNumbersOfMove = new System.Windows.Forms.Label();
            this.txtNumbersOfPush = new System.Windows.Forms.TextBox();
            this.txtNumbersOfMove = new System.Windows.Forms.TextBox();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip.SuspendLayout();
            this.pnlMovingOperator.SuspendLayout();
            this.pnlNumersOfMoving.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // LoadToolStripMenuItem
            // 
            this.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            this.LoadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.LoadToolStripMenuItem.Text = "Load";
            this.LoadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // pnlGameBoard
            // 
            this.pnlGameBoard.AutoSize = true;
            this.pnlGameBoard.Location = new System.Drawing.Point(0, 23);
            this.pnlGameBoard.Name = "pnlGameBoard";
            this.pnlGameBoard.Size = new System.Drawing.Size(990, 580);
            this.pnlGameBoard.TabIndex = 4;
            // 
            // pnlMovingOperator
            // 
            this.pnlMovingOperator.Controls.Add(this.btnRight);
            this.pnlMovingOperator.Controls.Add(this.btnLeft);
            this.pnlMovingOperator.Controls.Add(this.btnDown);
            this.pnlMovingOperator.Controls.Add(this.btnUp);
            this.pnlMovingOperator.Location = new System.Drawing.Point(995, 173);
            this.pnlMovingOperator.Name = "pnlMovingOperator";
            this.pnlMovingOperator.Size = new System.Drawing.Size(189, 314);
            this.pnlMovingOperator.TabIndex = 3;
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(128, 151);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(50, 50);
            this.btnRight.TabIndex = 3;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(16, 151);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(50, 50);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(72, 151);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(50, 50);
            this.btnDown.TabIndex = 1;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(72, 95);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(50, 50);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // pnlNumersOfMoving
            // 
            this.pnlNumersOfMoving.Controls.Add(this.lblNumbersOfPush);
            this.pnlNumersOfMoving.Controls.Add(this.lblNumbersOfMove);
            this.pnlNumersOfMoving.Controls.Add(this.txtNumbersOfPush);
            this.pnlNumersOfMoving.Controls.Add(this.txtNumbersOfMove);
            this.pnlNumersOfMoving.Location = new System.Drawing.Point(995, 23);
            this.pnlNumersOfMoving.Name = "pnlNumersOfMoving";
            this.pnlNumersOfMoving.Size = new System.Drawing.Size(189, 149);
            this.pnlNumersOfMoving.TabIndex = 4;
            // 
            // lblNumbersOfPush
            // 
            this.lblNumbersOfPush.AutoSize = true;
            this.lblNumbersOfPush.Location = new System.Drawing.Point(16, 82);
            this.lblNumbersOfPush.Name = "lblNumbersOfPush";
            this.lblNumbersOfPush.Size = new System.Drawing.Size(94, 13);
            this.lblNumbersOfPush.TabIndex = 3;
            this.lblNumbersOfPush.Text = "Number of Pushes";
            // 
            // lblNumbersOfMove
            // 
            this.lblNumbersOfMove.AutoSize = true;
            this.lblNumbersOfMove.Location = new System.Drawing.Point(16, 28);
            this.lblNumbersOfMove.Name = "lblNumbersOfMove";
            this.lblNumbersOfMove.Size = new System.Drawing.Size(91, 13);
            this.lblNumbersOfMove.TabIndex = 2;
            this.lblNumbersOfMove.Text = "Number of Moves";
            // 
            // txtNumbersOfPush
            // 
            this.txtNumbersOfPush.Location = new System.Drawing.Point(19, 98);
            this.txtNumbersOfPush.Name = "txtNumbersOfPush";
            this.txtNumbersOfPush.ReadOnly = true;
            this.txtNumbersOfPush.Size = new System.Drawing.Size(113, 20);
            this.txtNumbersOfPush.TabIndex = 1;
            // 
            // txtNumbersOfMove
            // 
            this.txtNumbersOfMove.Location = new System.Drawing.Point(19, 44);
            this.txtNumbersOfMove.Name = "txtNumbersOfMove";
            this.txtNumbersOfMove.ReadOnly = true;
            this.txtNumbersOfMove.Size = new System.Drawing.Size(113, 20);
            this.txtNumbersOfMove.TabIndex = 0;
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
            this.imgLst.Images.SetKeyName(5, "BoxOnDestination.bmp");
            // 
            // frmPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlNumersOfMoving);
            this.Controls.Add(this.pnlMovingOperator);
            this.Controls.Add(this.pnlGameBoard);
            this.Controls.Add(this.menuStrip);
            this.Name = "frmPlay";
            this.Text = "Play Form - Sokoban";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.pnlMovingOperator.ResumeLayout(false);
            this.pnlNumersOfMoving.ResumeLayout(false);
            this.pnlNumersOfMoving.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.Panel pnlGameBoard;
        private System.Windows.Forms.Panel pnlMovingOperator;
        private System.Windows.Forms.Panel pnlNumersOfMoving;
        private System.Windows.Forms.Label lblNumbersOfPush;
        private System.Windows.Forms.Label lblNumbersOfMove;
        private System.Windows.Forms.TextBox txtNumbersOfPush;
        private System.Windows.Forms.TextBox txtNumbersOfMove;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.ImageList imgLst;
    }
}