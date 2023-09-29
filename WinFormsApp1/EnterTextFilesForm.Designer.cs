namespace WinFormsApp1
{
    partial class EnterTextFilesForm
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
            this.enterFileText1 = new System.Windows.Forms.TextBox();
            this.enterFileText2 = new System.Windows.Forms.TextBox();
            this.saveFileTextResult = new System.Windows.Forms.TextBox();
            this.fileButton1 = new System.Windows.Forms.Button();
            this.fileButton2 = new System.Windows.Forms.Button();
            this.fileButton3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enterFileText1
            // 
            this.enterFileText1.Location = new System.Drawing.Point(14, 16);
            this.enterFileText1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.enterFileText1.Multiline = true;
            this.enterFileText1.Name = "enterFileText1";
            this.enterFileText1.Size = new System.Drawing.Size(434, 196);
            this.enterFileText1.TabIndex = 0;
            this.enterFileText1.TextChanged += new System.EventHandler(this.enterFileText1_TextChanged);
            // 
            // enterFileText2
            // 
            this.enterFileText2.Location = new System.Drawing.Point(466, 16);
            this.enterFileText2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.enterFileText2.Multiline = true;
            this.enterFileText2.Name = "enterFileText2";
            this.enterFileText2.Size = new System.Drawing.Size(434, 196);
            this.enterFileText2.TabIndex = 1;
            this.enterFileText2.TextChanged += new System.EventHandler(this.enterFileText2_TextChanged);
            // 
            // saveFileTextResult
            // 
            this.saveFileTextResult.Location = new System.Drawing.Point(14, 233);
            this.saveFileTextResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveFileTextResult.Multiline = true;
            this.saveFileTextResult.Name = "saveFileTextResult";
            this.saveFileTextResult.Size = new System.Drawing.Size(886, 285);
            this.saveFileTextResult.TabIndex = 2;
            this.saveFileTextResult.TextChanged += new System.EventHandler(this.saveFileTextResult_TextChanged);
            // 
            // fileButton1
            // 
            this.fileButton1.Location = new System.Drawing.Point(14, 533);
            this.fileButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileButton1.Name = "fileButton1";
            this.fileButton1.Size = new System.Drawing.Size(234, 53);
            this.fileButton1.TabIndex = 3;
            this.fileButton1.Text = "EnterFile1";
            this.fileButton1.UseVisualStyleBackColor = true;
            this.fileButton1.Click += new System.EventHandler(this.fileButton1_Click);
            // 
            // fileButton2
            // 
            this.fileButton2.Location = new System.Drawing.Point(667, 533);
            this.fileButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileButton2.Name = "fileButton2";
            this.fileButton2.Size = new System.Drawing.Size(233, 53);
            this.fileButton2.TabIndex = 4;
            this.fileButton2.Text = "EnterFile2";
            this.fileButton2.UseVisualStyleBackColor = true;
            this.fileButton2.Click += new System.EventHandler(this.fileButton2_Click);
            // 
            // fileButton3
            // 
            this.fileButton3.Location = new System.Drawing.Point(322, 528);
            this.fileButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileButton3.Name = "fileButton3";
            this.fileButton3.Size = new System.Drawing.Size(282, 59);
            this.fileButton3.TabIndex = 5;
            this.fileButton3.Text = "SaveFile3";
            this.fileButton3.UseVisualStyleBackColor = true;
            this.fileButton3.Click += new System.EventHandler(this.fileButton3_Click);
            // 
            // EnterTextFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.fileButton3);
            this.Controls.Add(this.fileButton2);
            this.Controls.Add(this.fileButton1);
            this.Controls.Add(this.saveFileTextResult);
            this.Controls.Add(this.enterFileText2);
            this.Controls.Add(this.enterFileText1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EnterTextFilesForm";
            this.Text = "EnterTextFilesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox enterFileText1;
        private System.Windows.Forms.TextBox enterFileText2;
        private System.Windows.Forms.TextBox saveFileTextResult;
        private System.Windows.Forms.Button fileButton1;
        private System.Windows.Forms.Button fileButton2;
        private System.Windows.Forms.Button fileButton3;
    }
}