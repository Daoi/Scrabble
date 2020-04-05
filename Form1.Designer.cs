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
            this.btnHandSeven = new System.Windows.Forms.Button();
            this.btnHandSix = new System.Windows.Forms.Button();
            this.btnHandFive = new System.Windows.Forms.Button();
            this.btnHandFour = new System.Windows.Forms.Button();
            this.btnHandThree = new System.Windows.Forms.Button();
            this.btnHandTwo = new System.Windows.Forms.Button();
            this.btnHandOne = new System.Windows.Forms.Button();
            this.timerDragAndDrop = new System.Windows.Forms.Timer(this.components);
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.btnResetTurn = new System.Windows.Forms.Button();
            this.btnExchangeTiles = new System.Windows.Forms.Button();
            this.lblScores = new System.Windows.Forms.Label();
            this.lblPlayerOneScore = new System.Windows.Forms.Label();
            this.lblPlayerTwoScore = new System.Windows.Forms.Label();
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
            this.pnlTiles.Controls.Add(this.btnHandSeven);
            this.pnlTiles.Controls.Add(this.btnHandSix);
            this.pnlTiles.Controls.Add(this.btnHandFive);
            this.pnlTiles.Controls.Add(this.btnHandFour);
            this.pnlTiles.Controls.Add(this.btnHandThree);
            this.pnlTiles.Controls.Add(this.btnHandTwo);
            this.pnlTiles.Controls.Add(this.btnHandOne);
            this.pnlTiles.Location = new System.Drawing.Point(134, 642);
            this.pnlTiles.Name = "pnlTiles";
            this.pnlTiles.Size = new System.Drawing.Size(340, 60);
            this.pnlTiles.TabIndex = 1;
            // 
            // btnHandSeven
            // 
            this.btnHandSeven.Location = new System.Drawing.Point(289, 10);
            this.btnHandSeven.Name = "btnHandSeven";
            this.btnHandSeven.Size = new System.Drawing.Size(40, 40);
            this.btnHandSeven.TabIndex = 6;
            this.btnHandSeven.Text = "E";
            this.btnHandSeven.UseVisualStyleBackColor = true;
            // 
            // btnHandSix
            // 
            this.btnHandSix.Location = new System.Drawing.Point(243, 10);
            this.btnHandSix.Name = "btnHandSix";
            this.btnHandSix.Size = new System.Drawing.Size(40, 40);
            this.btnHandSix.TabIndex = 5;
            this.btnHandSix.Text = "E";
            this.btnHandSix.UseVisualStyleBackColor = true;
            // 
            // btnHandFive
            // 
            this.btnHandFive.Location = new System.Drawing.Point(197, 10);
            this.btnHandFive.Name = "btnHandFive";
            this.btnHandFive.Size = new System.Drawing.Size(40, 40);
            this.btnHandFive.TabIndex = 4;
            this.btnHandFive.Text = "E";
            this.btnHandFive.UseVisualStyleBackColor = true;
            // 
            // btnHandFour
            // 
            this.btnHandFour.Location = new System.Drawing.Point(151, 10);
            this.btnHandFour.Name = "btnHandFour";
            this.btnHandFour.Size = new System.Drawing.Size(40, 40);
            this.btnHandFour.TabIndex = 3;
            this.btnHandFour.Text = "E";
            this.btnHandFour.UseVisualStyleBackColor = true;
            // 
            // btnHandThree
            // 
            this.btnHandThree.Location = new System.Drawing.Point(105, 10);
            this.btnHandThree.Name = "btnHandThree";
            this.btnHandThree.Size = new System.Drawing.Size(40, 40);
            this.btnHandThree.TabIndex = 2;
            this.btnHandThree.Text = "E";
            this.btnHandThree.UseVisualStyleBackColor = true;
            // 
            // btnHandTwo
            // 
            this.btnHandTwo.Location = new System.Drawing.Point(59, 10);
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
            // btnEndTurn
            // 
            this.btnEndTurn.Location = new System.Drawing.Point(983, 652);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(75, 23);
            this.btnEndTurn.TabIndex = 2;
            this.btnEndTurn.Text = "End Turn";
            this.btnEndTurn.UseVisualStyleBackColor = true;
            // 
            // btnResetTurn
            // 
            this.btnResetTurn.Location = new System.Drawing.Point(983, 678);
            this.btnResetTurn.Name = "btnResetTurn";
            this.btnResetTurn.Size = new System.Drawing.Size(75, 23);
            this.btnResetTurn.TabIndex = 3;
            this.btnResetTurn.Text = "Reset Turn";
            this.btnResetTurn.UseVisualStyleBackColor = true;
            this.btnResetTurn.Click += new System.EventHandler(this.btnResetTurn_Click);
            // 
            // btnExchangeTiles
            // 
            this.btnExchangeTiles.Location = new System.Drawing.Point(480, 652);
            this.btnExchangeTiles.Name = "btnExchangeTiles";
            this.btnExchangeTiles.Size = new System.Drawing.Size(75, 23);
            this.btnExchangeTiles.TabIndex = 4;
            this.btnExchangeTiles.Text = "Exchange";
            this.btnExchangeTiles.UseVisualStyleBackColor = true;
            // 
            // lblScores
            // 
            this.lblScores.AutoSize = true;
            this.lblScores.Location = new System.Drawing.Point(726, 642);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(125, 26);
            this.lblScores.TabIndex = 5;
            this.lblScores.Text = "              Scores \r\nPlayer 1              Player 2";
            // 
            // lblPlayerOneScore
            // 
            this.lblPlayerOneScore.AutoSize = true;
            this.lblPlayerOneScore.Location = new System.Drawing.Point(741, 668);
            this.lblPlayerOneScore.Name = "lblPlayerOneScore";
            this.lblPlayerOneScore.Size = new System.Drawing.Size(13, 13);
            this.lblPlayerOneScore.TabIndex = 6;
            this.lblPlayerOneScore.Text = "0";
            // 
            // lblPlayerTwoScore
            // 
            this.lblPlayerTwoScore.AutoSize = true;
            this.lblPlayerTwoScore.Location = new System.Drawing.Point(821, 668);
            this.lblPlayerTwoScore.Name = "lblPlayerTwoScore";
            this.lblPlayerTwoScore.Size = new System.Drawing.Size(13, 13);
            this.lblPlayerTwoScore.TabIndex = 7;
            this.lblPlayerTwoScore.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 713);
            this.Controls.Add(this.lblPlayerTwoScore);
            this.Controls.Add(this.lblPlayerOneScore);
            this.Controls.Add(this.lblScores);
            this.Controls.Add(this.btnExchangeTiles);
            this.Controls.Add(this.btnResetTurn);
            this.Controls.Add(this.btnEndTurn);
            this.Controls.Add(this.pnlTiles);
            this.Controls.Add(this.pnlBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlTiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Panel pnlTiles;
        private System.Windows.Forms.Button btnHandThree;
        private System.Windows.Forms.Button btnHandTwo;
        private System.Windows.Forms.Button btnHandOne;
        private System.Windows.Forms.Timer timerDragAndDrop;
        private System.Windows.Forms.Button btnHandSeven;
        private System.Windows.Forms.Button btnHandSix;
        private System.Windows.Forms.Button btnHandFive;
        private System.Windows.Forms.Button btnHandFour;
        private System.Windows.Forms.Button btnEndTurn;
        private System.Windows.Forms.Button btnResetTurn;
        private System.Windows.Forms.Button btnExchangeTiles;
        private System.Windows.Forms.Label lblScores;
        private System.Windows.Forms.Label lblPlayerOneScore;
        private System.Windows.Forms.Label lblPlayerTwoScore;
    }

}

