namespace LEDConfig
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonMatrix = new LEDConfig.ButtonMatrix();
            this.panMatrix = new System.Windows.Forms.Panel();
            this.panControls = new System.Windows.Forms.Panel();
            this.panMatrix.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonMatrix
            // 
            this.buttonMatrix.AutoSize = true;
            this.buttonMatrix.LEDCount = 252;
            this.buttonMatrix.Location = new System.Drawing.Point(0, 0);
            this.buttonMatrix.Name = "buttonMatrix";
            this.buttonMatrix.Rows = 12;
            this.buttonMatrix.Size = new System.Drawing.Size(813, 555);
            this.buttonMatrix.TabIndex = 0;
            // 
            // panMatrix
            // 
            this.panMatrix.AutoScroll = true;
            this.panMatrix.Controls.Add(this.buttonMatrix);
            this.panMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMatrix.Location = new System.Drawing.Point(0, 0);
            this.panMatrix.Name = "panMatrix";
            this.panMatrix.Size = new System.Drawing.Size(865, 569);
            this.panMatrix.TabIndex = 1;
            // 
            // panControls
            // 
            this.panControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.panControls.Location = new System.Drawing.Point(865, 0);
            this.panControls.Name = "panControls";
            this.panControls.Size = new System.Drawing.Size(200, 569);
            this.panControls.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 569);
            this.Controls.Add(this.panMatrix);
            this.Controls.Add(this.panControls);
            this.Name = "Form1";
            this.Text = "LEDConfig";
            this.panMatrix.ResumeLayout(false);
            this.panMatrix.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonMatrix buttonMatrix;
        private Panel panMatrix;
        private Panel panControls;
    }
}