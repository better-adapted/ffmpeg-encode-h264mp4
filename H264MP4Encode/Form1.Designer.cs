namespace H264MP4Encode
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
            this.button1 = new System.Windows.Forms.Button();
            this.btInc = new System.Windows.Forms.Button();
            this.btDec = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "Encode to H264 (mp4 container)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btInc
            // 
            this.btInc.Location = new System.Drawing.Point(113, 115);
            this.btInc.Name = "btInc";
            this.btInc.Size = new System.Drawing.Size(75, 23);
            this.btInc.TabIndex = 1;
            this.btInc.Text = "Inc";
            this.btInc.UseVisualStyleBackColor = true;
            this.btInc.Click += new System.EventHandler(this.btInc_Click);
            // 
            // btDec
            // 
            this.btDec.Location = new System.Drawing.Point(113, 144);
            this.btDec.Name = "btDec";
            this.btDec.Size = new System.Drawing.Size(75, 23);
            this.btDec.TabIndex = 2;
            this.btDec.Text = "Dec";
            this.btDec.UseVisualStyleBackColor = true;
            this.btDec.Click += new System.EventHandler(this.btDec_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 285);
            this.Controls.Add(this.btDec);
            this.Controls.Add(this.btInc);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btInc;
        private System.Windows.Forms.Button btDec;
    }
}

