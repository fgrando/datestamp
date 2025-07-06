namespace dstamp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxFormat = new System.Windows.Forms.TextBox();
            this.labelTimestamp = new System.Windows.Forms.Label();
            this.labelformat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFormat
            // 
            this.textBoxFormat.Location = new System.Drawing.Point(57, 112);
            this.textBoxFormat.Name = "textBoxFormat";
            this.textBoxFormat.Size = new System.Drawing.Size(293, 20);
            this.textBoxFormat.TabIndex = 4;
            this.textBoxFormat.Text = "yyy.MM.dd_HH.mm.ss";
            // 
            // labelTimestamp
            // 
            this.labelTimestamp.AutoSize = true;
            this.labelTimestamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimestamp.Location = new System.Drawing.Point(10, 31);
            this.labelTimestamp.Name = "labelTimestamp";
            this.labelTimestamp.Size = new System.Drawing.Size(131, 31);
            this.labelTimestamp.TabIndex = 6;
            this.labelTimestamp.Text = "1.2.3-4:5";
            // 
            // labelformat
            // 
            this.labelformat.AutoSize = true;
            this.labelformat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelformat.Location = new System.Drawing.Point(12, 115);
            this.labelformat.Name = "labelformat";
            this.labelformat.Size = new System.Drawing.Size(39, 13);
            this.labelformat.TabIndex = 7;
            this.labelformat.Text = "format:";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 144);
            this.Controls.Add(this.labelformat);
            this.Controls.Add(this.labelTimestamp);
            this.Controls.Add(this.textBoxFormat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "datestamp";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.form_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.form_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxFormat;
        private System.Windows.Forms.Label labelTimestamp;
        private System.Windows.Forms.Label labelformat;
    }
}

