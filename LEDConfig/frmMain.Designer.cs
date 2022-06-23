﻿namespace LEDConfig
{
    partial class frmMain
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.txtCodeGen = new System.Windows.Forms.TextBox();
            this.txtVarName = new System.Windows.Forms.TextBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.txtNumLeds = new System.Windows.Forms.TextBox();
            this.panMatrix.SuspendLayout();
            this.panControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonMatrix
            // 
            this.buttonMatrix.AutoSize = true;
            this.buttonMatrix.LEDCount = 1;
            this.buttonMatrix.Location = new System.Drawing.Point(0, 0);
            this.buttonMatrix.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.buttonMatrix.Name = "buttonMatrix";
            this.buttonMatrix.RowCount = 1;
            this.buttonMatrix.Size = new System.Drawing.Size(1161, 925);
            this.buttonMatrix.TabIndex = 0;
            // 
            // panMatrix
            // 
            this.panMatrix.AutoScroll = true;
            this.panMatrix.Controls.Add(this.buttonMatrix);
            this.panMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMatrix.Location = new System.Drawing.Point(0, 0);
            this.panMatrix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panMatrix.Name = "panMatrix";
            this.panMatrix.Size = new System.Drawing.Size(1221, 943);
            this.panMatrix.TabIndex = 1;
            // 
            // panControls
            // 
            this.panControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panControls.Controls.Add(this.btnGenerate);
            this.panControls.Controls.Add(this.txtIndex);
            this.panControls.Controls.Add(this.txtCodeGen);
            this.panControls.Controls.Add(this.txtVarName);
            this.panControls.Controls.Add(this.btnBuild);
            this.panControls.Controls.Add(this.txtRows);
            this.panControls.Controls.Add(this.txtNumLeds);
            this.panControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.panControls.Location = new System.Drawing.Point(1221, 0);
            this.panControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panControls.Name = "panControls";
            this.panControls.Size = new System.Drawing.Size(285, 943);
            this.panControls.TabIndex = 2;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(7, 260);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(143, 38);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate Code";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(7, 198);
            this.txtIndex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.PlaceholderText = "LED Index Variable Name";
            this.txtIndex.Size = new System.Drawing.Size(258, 31);
            this.txtIndex.TabIndex = 3;
            // 
            // txtCodeGen
            // 
            this.txtCodeGen.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCodeGen.Location = new System.Drawing.Point(7, 308);
            this.txtCodeGen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCodeGen.Multiline = true;
            this.txtCodeGen.Name = "txtCodeGen";
            this.txtCodeGen.ReadOnly = true;
            this.txtCodeGen.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCodeGen.Size = new System.Drawing.Size(258, 621);
            this.txtCodeGen.TabIndex = 4;
            this.txtCodeGen.WordWrap = false;
            // 
            // txtVarName
            // 
            this.txtVarName.Location = new System.Drawing.Point(7, 150);
            this.txtVarName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVarName.Name = "txtVarName";
            this.txtVarName.PlaceholderText = "LED Variable Name";
            this.txtVarName.Size = new System.Drawing.Size(258, 31);
            this.txtVarName.TabIndex = 2;
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(7, 102);
            this.btnBuild.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(107, 38);
            this.btnBuild.TabIndex = 5;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(7, 53);
            this.txtRows.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRows.Name = "txtRows";
            this.txtRows.PlaceholderText = "# of Rows";
            this.txtRows.Size = new System.Drawing.Size(258, 31);
            this.txtRows.TabIndex = 1;
            this.txtRows.TextChanged += new System.EventHandler(this.txtRows_TextChanged);
            // 
            // txtNumLeds
            // 
            this.txtNumLeds.Location = new System.Drawing.Point(7, 7);
            this.txtNumLeds.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNumLeds.Name = "txtNumLeds";
            this.txtNumLeds.PlaceholderText = "# of LEDs";
            this.txtNumLeds.Size = new System.Drawing.Size(258, 31);
            this.txtNumLeds.TabIndex = 0;
            this.txtNumLeds.TextChanged += new System.EventHandler(this.txtNumLeds_TextChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1506, 943);
            this.Controls.Add(this.panMatrix);
            this.Controls.Add(this.panControls);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
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
        private Button btnGenerate;
        private TextBox txtIndex;
    }
}