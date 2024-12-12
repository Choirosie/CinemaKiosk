namespace kiosk_movie
{
    partial class Choice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Choice));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            btnReserve = new System.Windows.Forms.Button();
            btnCombo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(83, 103);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(460, 149);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnReserve
            // 
            btnReserve.Image = (System.Drawing.Image)resources.GetObject("btnReserve.Image");
            btnReserve.Location = new System.Drawing.Point(83, 323);
            btnReserve.Name = "btnReserve";
            btnReserve.Size = new System.Drawing.Size(227, 311);
            btnReserve.TabIndex = 1;
            btnReserve.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            btnReserve.UseVisualStyleBackColor = true;
            btnReserve.Click += btnReserve_Click;
            // 
            // btnCombo
            // 
            btnCombo.Image = (System.Drawing.Image)resources.GetObject("btnCombo.Image");
            btnCombo.Location = new System.Drawing.Point(316, 323);
            btnCombo.Name = "btnCombo";
            btnCombo.Size = new System.Drawing.Size(227, 311);
            btnCombo.TabIndex = 2;
            btnCombo.UseVisualStyleBackColor = true;
            btnCombo.Click += btnCombo_Click;
            // 
            // Choice
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(637, 773);
            Controls.Add(btnCombo);
            Controls.Add(btnReserve);
            Controls.Add(pictureBox1);
            Name = "Choice";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Choice";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.Button btnCombo;
    }
}