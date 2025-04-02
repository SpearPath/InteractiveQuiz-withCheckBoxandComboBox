namespace InteractiveQuiz
{
    partial class InteractiveQuiz
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
            this.label2 = new System.Windows.Forms.Label();
            this.bosh = new System.Windows.Forms.Button();
            this.cisco = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(224, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choose a Subject:";
            // 
            // bosh
            // 
            this.bosh.BackgroundImage = global::InteractiveQuiz.Properties.Resources.boshlogo;
            this.bosh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bosh.Location = new System.Drawing.Point(142, 219);
            this.bosh.Name = "bosh";
            this.bosh.Size = new System.Drawing.Size(133, 112);
            this.bosh.TabIndex = 2;
            this.bosh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bosh.UseVisualStyleBackColor = true;
            this.bosh.Click += new System.EventHandler(this.bosh_Click);
            // 
            // cisco
            // 
            this.cisco.BackColor = System.Drawing.Color.Transparent;
            this.cisco.BackgroundImage = global::InteractiveQuiz.Properties.Resources.ciscologo;
            this.cisco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cisco.Location = new System.Drawing.Point(412, 219);
            this.cisco.Name = "cisco";
            this.cisco.Size = new System.Drawing.Size(133, 112);
            this.cisco.TabIndex = 3;
            this.cisco.UseVisualStyleBackColor = false;
            this.cisco.Click += new System.EventHandler(this.cisco_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::InteractiveQuiz.Properties.Resources.uclm_logo;
            this.pictureBox2.Location = new System.Drawing.Point(567, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(123, 101);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::InteractiveQuiz.Properties.Resources.quizlogo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(239, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(222, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "BOSH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "CISCO";
            // 
            // InteractiveQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InteractiveQuiz.Properties.Resources.quiz_background;
            this.ClientSize = new System.Drawing.Size(689, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cisco);
            this.Controls.Add(this.bosh);
            this.Controls.Add(this.label2);
            this.Name = "InteractiveQuiz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INTERACTIVE QUIZ GAME";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bosh;
        private System.Windows.Forms.Button cisco;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}

