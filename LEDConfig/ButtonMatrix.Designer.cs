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
            this.lblInvalid = new System.Windows.Forms.Label();
            this.btnClearColours = new System.Windows.Forms.Button();
            this.btnIndiv = new System.Windows.Forms.Button();
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
            // lblInvalid
            // 
            this.lblInvalid.AutoSize = true;
            this.lblInvalid.Location = new System.Drawing.Point(10, 67);
            this.lblInvalid.Name = "lblInvalid";
            this.lblInvalid.Size = new System.Drawing.Size(81, 15);
            this.lblInvalid.TabIndex = 1;
            this.lblInvalid.Text = "Invalid layout.";
            // 
            // btnClearColours
            // 
            this.btnClearColours.Location = new System.Drawing.Point(176, 9);
            this.btnClearColours.Name = "btnClearColours";
            this.btnClearColours.Size = new System.Drawing.Size(160, 32);
            this.btnClearColours.TabIndex = 2;
            this.btnClearColours.Text = "Clear All Colours";
            this.btnClearColours.UseVisualStyleBackColor = true;
            this.btnClearColours.Click += new System.EventHandler(this.btnClearColours_Click);
            // 
            // btnIndiv
            // 
            this.btnIndiv.Location = new System.Drawing.Point(342, 9);
            this.btnIndiv.Name = "btnIndiv";
            this.btnIndiv.Size = new System.Drawing.Size(160, 32);
            this.btnIndiv.TabIndex = 3;
            this.btnIndiv.Text = "Individual LED Colour";
            this.btnIndiv.UseVisualStyleBackColor = true;
            this.btnIndiv.Click += new System.EventHandler(this.btnIndiv_Click);
            // 
            // ButtonMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btnIndiv);
            this.Controls.Add(this.btnClearColours);
            this.Controls.Add(this.lblInvalid);
            this.Controls.Add(this.btnChangeAll);
            this.Name = "ButtonMatrix";
            this.Size = new System.Drawing.Size(832, 630);
            this.Load += new System.EventHandler(this.ButtonMatrix_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnChangeAll;
        private Label lblInvalid;
        private Button btnClearColours;
        private Button btnIndiv;
    }
}
