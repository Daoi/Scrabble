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
            this.timerDragAndDrop = new System.Windows.Forms.Timer(this.components);
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.btnResetTurn = new System.Windows.Forms.Button();
            this.btnExchangeTiles = new System.Windows.Forms.Button();
            this.lblScores = new System.Windows.Forms.Label();
            this.lblPlayerOneScore = new System.Windows.Forms.Label();
            this.lblPlayerTwoScore = new System.Windows.Forms.Label();
            this.lblCurrentPlayersTurn = new System.Windows.Forms.Label();
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
            this.pnlTiles.Location = new System.Drawing.Point(134, 642);
            this.pnlTiles.Name = "pnlTiles";
            this.pnlTiles.Size = new System.Drawing.Size(340, 60);
            this.pnlTiles.TabIndex = 1;
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
            this.btnEndTurn.Click += new System.EventHandler(this.btnEndTurn_Click);
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
            // lblCurrentPlayersTurn
            // 
            this.lblCurrentPlayersTurn.AutoSize = true;
            this.lblCurrentPlayersTurn.Location = new System.Drawing.Point(13, 652);
            this.lblCurrentPlayersTurn.Name = "lblCurrentPlayersTurn";
            this.lblCurrentPlayersTurn.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentPlayersTurn.TabIndex = 8;
            this.lblCurrentPlayersTurn.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 713);
            this.Controls.Add(this.lblCurrentPlayersTurn);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Panel pnlTiles;
        private System.Windows.Forms.Timer timerDragAndDrop;
        private System.Windows.Forms.Button btnEndTurn;
        private System.Windows.Forms.Button btnResetTurn;
        private System.Windows.Forms.Button btnExchangeTiles;
        private System.Windows.Forms.Label lblScores;
        private System.Windows.Forms.Label lblPlayerOneScore;
        private System.Windows.Forms.Label lblPlayerTwoScore;
        private System.Windows.Forms.Label lblCurrentPlayersTurn;
    }

}

