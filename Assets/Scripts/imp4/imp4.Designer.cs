namespace imp4
{
    partial class imp4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox ();
            this.pictureBox2 = new System.Windows.Forms.PictureBox ();
            this.button1 = new System.Windows.Forms.Button ();
            //this.button2 = new System.Windows.Forms.Button ();
            this.button3 = new System.Windows.Forms.Button ();
            this.dOpen = new System.Windows.Forms.OpenFileDialog ();
            this.textBox1 = new System.Windows.Forms.TextBox ();
            this.label1 = new System.Windows.Forms.Label ();
            ( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).BeginInit ();
            ( (System.ComponentModel.ISupportInitialize)( this.pictureBox2 ) ).BeginInit ();
            this.SuspendLayout ();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point (12, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size (350, 453);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point (542, 49);
            this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(350, 453);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point (12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size (75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Show Original";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler (this.button1_Click);
            // 
            // button2
            // 
            //this.button2.Location = new System.Drawing.Point (406, 110);
            //this.button2.Name = "button2";
            //this.button2.Size = new System.Drawing.Size (75, 23);
            //this.button2.TabIndex = 3;
            //this.button2.Text = "Sobel";
            //this.button2.UseVisualStyleBackColor = true;
            //this.button2.Click += new System.EventHandler (this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point (406, 265);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size (75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Canny";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler (this.button3_Click);
            // 
            // dOpen
            // 
            this.dOpen.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point (433, 239);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size (75, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "80";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point (373, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size (54, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Threshold";
            // 
            // imp4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size (950, 662);
            this.Controls.Add (this.label1);
            this.Controls.Add (this.textBox1);
            this.Controls.Add (this.button3);
            //this.Controls.Add (this.button2);
            this.Controls.Add (this.button1);
            this.Controls.Add (this.pictureBox2);
            this.Controls.Add (this.pictureBox1);
            this.Name = "imp4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imp4";
            ( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).EndInit ();
            ( (System.ComponentModel.ISupportInitialize)( this.pictureBox2 ) ).EndInit ();
            this.ResumeLayout (false);
            this.PerformLayout ();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        //private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog dOpen;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

