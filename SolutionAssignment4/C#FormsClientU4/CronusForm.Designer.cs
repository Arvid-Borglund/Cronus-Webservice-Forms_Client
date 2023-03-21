namespace CronusFormsClient
{
    partial class CronusForm
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
            this.txtBoxInput = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtBoxData = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBoxInput
            // 
            this.txtBoxInput.Location = new System.Drawing.Point(491, 486);
            this.txtBoxInput.Name = "txtBoxInput";
            this.txtBoxInput.Size = new System.Drawing.Size(249, 26);
            this.txtBoxInput.TabIndex = 1;
            this.txtBoxInput.KeyDown += TxtBoxInput_KeyDown;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(491, 530);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(249, 41);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // txtBoxData
            // 
            this.txtBoxData.Location = new System.Drawing.Point(73, 17);
            this.txtBoxData.Multiline = true;
            this.txtBoxData.Name = "txtBoxData";
            this.txtBoxData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxData.Size = new System.Drawing.Size(1100, 450);
            this.txtBoxData.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.txtBoxData);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtBoxInput);
            this.Name = "CronusForm";
            this.Text = "CronusForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBoxInput;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtBoxData;
    }
}