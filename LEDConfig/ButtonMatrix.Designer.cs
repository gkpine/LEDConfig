namespace LEDConfig
{
    partial class ButtonMatrix
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
            this.btnChangeAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChangeAll
            // 
            this.btnChangeAll.Location = new System.Drawing.Point(10, 9);
            this.btnChangeAll.Name = "btnChangeAll";
            this.btnChangeAll.Size = new System.Drawing.Size(160, 32);
            this.btnChangeAll.TabIndex = 0;
            this.btnChangeAll.Text = "Change All Colours";
            this.btnChangeAll.UseVisualStyleBackColor = true;
            this.btnChangeAll.Click += new System.EventHandler(this.btnChangeAll_Click);
            // 
            // ButtonMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btnChangeAll);
            this.Name = "ButtonMatrix";
            this.Size = new System.Drawing.Size(832, 630);
            this.Load += new System.EventHandler(this.ButtonMatrix_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnChangeAll;
    }
}
