namespace Summative_1
{
    partial class WinScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinScreen));
            this.diaLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // diaLabel
            // 
            this.diaLabel.AutoSize = true;
            this.diaLabel.BackColor = System.Drawing.Color.Transparent;
            this.diaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diaLabel.Location = new System.Drawing.Point(204, 85);
            this.diaLabel.Name = "diaLabel";
            this.diaLabel.Size = new System.Drawing.Size(0, 147);
            this.diaLabel.TabIndex = 0;
            this.diaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playButton
            // 
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.playButton.Location = new System.Drawing.Point(215, 354);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(220, 80);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "Play Again";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.exitButton.Location = new System.Drawing.Point(537, 354);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(220, 80);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.scoreLabel.Location = new System.Drawing.Point(339, 291);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(29, 42);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = " ";
            // 
            // WinScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.diaLabel);
            this.DoubleBuffered = true;
            this.Name = "WinScreen";
            this.Size = new System.Drawing.Size(1000, 600);
            this.Load += new System.EventHandler(this.WinScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label diaLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label scoreLabel;
    }
}
