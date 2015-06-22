namespace PuckMan {
    partial class EndGameForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.labelWin = new System.Windows.Forms.Label();
            this.labelLost = new System.Windows.Forms.Label();
            this.buttonRepeat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelWin
            // 
            this.labelWin.AutoSize = true;
            this.labelWin.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWin.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelWin.Location = new System.Drawing.Point(199, 191);
            this.labelWin.Name = "labelWin";
            this.labelWin.Size = new System.Drawing.Size(401, 35);
            this.labelWin.TabIndex = 0;
            this.labelWin.Text = "Поздравляю, вы победили!!!";
            // 
            // labelLost
            // 
            this.labelLost.AutoSize = true;
            this.labelLost.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLost.ForeColor = System.Drawing.Color.IndianRed;
            this.labelLost.Location = new System.Drawing.Point(112, 226);
            this.labelLost.Name = "labelLost";
            this.labelLost.Size = new System.Drawing.Size(567, 35);
            this.labelLost.TabIndex = 1;
            this.labelLost.Text = "Вы проиграли, хотите попробовать ещё?";
            // 
            // buttonRepeat
            // 
            this.buttonRepeat.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRepeat.Location = new System.Drawing.Point(318, 286);
            this.buttonRepeat.Name = "buttonRepeat";
            this.buttonRepeat.Size = new System.Drawing.Size(168, 67);
            this.buttonRepeat.TabIndex = 2;
            this.buttonRepeat.Text = "Попробовать ещё";
            this.buttonRepeat.UseVisualStyleBackColor = false;
            this.buttonRepeat.Click += new System.EventHandler(this.buttonRepeat_Click);
            // 
            // EndGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.buttonRepeat);
            this.Controls.Add(this.labelLost);
            this.Controls.Add(this.labelWin);
            this.Name = "EndGameForm";
            this.Text = "EndGameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWin;
        private System.Windows.Forms.Label labelLost;
        private System.Windows.Forms.Button buttonRepeat;
    }
}