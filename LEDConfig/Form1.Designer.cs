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
            this.txtNumLeds = new System.Windows.Forms.TextBox();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.txtVarName = new System.Windows.Forms.TextBox();
            this.txtCodeGen = new System.Windows.Forms.TextBox();
            this.panMatrix.SuspendLayout();
            this.panControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonMatrix
            // 
            this.buttonMatrix.AutoSize = true;
            this.buttonMatrix.LEDCount = 1;
            this.buttonMatrix.Location = new System.Drawing.Point(0, 0);
            this.buttonMatrix.Name = "buttonMatrix";
            this.buttonMatrix.Rows = 1;
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
            this.panMatrix.Size = new System.Drawing.Size(854, 566);
            this.panMatrix.TabIndex = 1;
            // 
            // panControls
            // 
            this.panControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panControls.Controls.Add(this.txtCodeGen);
            this.panControls.Controls.Add(this.txtVarName);
            this.panControls.Controls.Add(this.btnBuild);
            this.panControls.Controls.Add(this.txtRows);
            this.panControls.Controls.Add(this.txtNumLeds);
            this.panControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.panControls.Location = new System.Drawing.Point(854, 0);
            this.panControls.Name = "panControls";
            this.panControls.Size = new System.Drawing.Size(200, 566);
            this.panControls.TabIndex = 2;
            // 
            // txtNumLeds
            // 
            this.txtNumLeds.Location = new System.Drawing.Point(5, 3);
            this.txtNumLeds.Name = "txtNumLeds";
            this.txtNumLeds.PlaceholderText = "# of LEDs";
            this.txtNumLeds.Size = new System.Drawing.Size(182, 23);
            this.txtNumLeds.TabIndex = 0;
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(5, 32);
            this.txtRows.Name = "txtRows";
            this.txtRows.PlaceholderText = "# of Rows";
            this.txtRows.Size = new System.Drawing.Size(182, 23);
            this.txtRows.TabIndex = 1;
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(5, 61);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(75, 23);
            this.btnBuild.TabIndex = 2;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            // 
            // txtVarName
            // 
            this.txtVarName.Location = new System.Drawing.Point(5, 116);
            this.txtVarName.Name = "txtVarName";
            this.txtVarName.PlaceholderText = "LED Variable Name";
            this.txtVarName.Size = new System.Drawing.Size(182, 23);
            this.txtVarName.TabIndex = 3;
            // 
            // txtCodeGen
            // 
            this.txtCodeGen.Location = new System.Drawing.Point(5, 145);
            this.txtCodeGen.Multiline = true;
            this.txtCodeGen.Name = "txtCodeGen";
            this.txtCodeGen.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCodeGen.Size = new System.Drawing.Size(182, 411);
            this.txtCodeGen.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 566);
            this.Controls.Add(this.panMatrix);
            this.Controls.Add(this.panControls);
            this.Name = "Form1";
            this.Text = "LEDConfig";
            this.panMatrix.ResumeLayout(false);
            this.panMatrix.PerformLayout();
            this.panControls.ResumeLayout(false);
            this.panControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonMatrix buttonMatrix;
        private Panel panMatrix;
        private Panel panControls;
        private TextBox txtCodeGen;
        private TextBox txtVarName;
        private Button btnBuild;
        private TextBox txtRows;
        private TextBox txtNumLeds;
    }
}