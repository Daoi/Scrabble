namespace Scrabble
{
    partial class Form1
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
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.pnlTiles = new System.Windows.Forms.Panel();
            this.btnHandThree = new System.Windows.Forms.Button();
            this.btnHandTwo = new System.Windows.Forms.Button();
            this.btnHandOne = new System.Windows.Forms.Button();
            this.timerDragAndDrop = new System.Windows.Forms.Timer(this.components);
            this.pnlTiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.Location = new System.Drawing.Point(12, 12);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(1078, 624);
            this.pnlBoard.TabIndex = 0;
            // 
            // pnlTiles
            // 
            this.pnlTiles.Controls.Add(this.btnHandThree);
            this.pnlTiles.Controls.Add(this.btnHandTwo);
            this.pnlTiles.Controls.Add(this.btnHandOne);
            this.pnlTiles.Location = new System.Drawing.Point(134, 642);
            this.pnlTiles.Name = "pnlTiles";
            this.pnlTiles.Size = new System.Drawing.Size(811, 60);
            this.pnlTiles.TabIndex = 1;
            // 
            // btnHandThree
            // 
            this.btnHandThree.Location = new System.Drawing.Point(97, 10);
            this.btnHandThree.Name = "btnHandThree";
            this.btnHandThree.Size = new System.Drawing.Size(40, 40);
            this.btnHandThree.TabIndex = 2;
            this.btnHandThree.Text = "E";
            this.btnHandThree.UseVisualStyleBackColor = true;
            // 
            // btnHandTwo
            // 
            this.btnHandTwo.Location = new System.Drawing.Point(55, 10);
            this.btnHandTwo.Name = "btnHandTwo";
            this.btnHandTwo.Size = new System.Drawing.Size(40, 40);
            this.btnHandTwo.TabIndex = 1;
            this.btnHandTwo.Text = "T";
            this.btnHandTwo.UseVisualStyleBackColor = true;
            // 
            // btnHandOne
            // 
            this.btnHandOne.Location = new System.Drawing.Point(13, 10);
            this.btnHandOne.Name = "btnHandOne";
            this.btnHandOne.Size = new System.Drawing.Size(40, 40);
            this.btnHandOne.TabIndex = 0;
            this.btnHandOne.Text = "A";
            this.btnHandOne.UseVisualStyleBackColor = true;
            // 
            // timerDragAndDrop
            // 
            this.timerDragAndDrop.Interval = 33;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 713);
            this.Controls.Add(this.pnlTiles);
            this.Controls.Add(this.pnlBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlTiles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Panel pnlTiles;
        private System.Windows.Forms.Button btnHandThree;
        private System.Windows.Forms.Button btnHandTwo;
        private System.Windows.Forms.Button btnHandOne;
        private System.Windows.Forms.Timer timerDragAndDrop;
    }

}

