using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEDConfig
{
    public partial class ButtonMatrix : UserControl
    {

        private int _rows;
        private int _ledCount;

        public int Rows { get; set; }
        public int LEDCount { get; set; }

        private int LEDsPerRow;

        public ButtonMatrix()
        {
            InitializeComponent();
            Rows = 1;
            LEDCount = 1;
        }

        private void ButtonMatrix_Load(object sender, EventArgs e)
        {
            BuildMatrix();
        }

        private void ClearMatrix()
        {
            foreach (Button b in this.Controls.OfType<Button>().ToList())
            {
                b.Dispose();
            }
        }

        public void BuildMatrix(int LEDcount, int rowCount)
        {
            this.LEDCount = LEDcount;
            this.Rows = rowCount;
            BuildMatrix();
        }

        public void BuildMatrix()
        {
            ClearMatrix();
            LEDsPerRow = LEDCount / Rows;
            int ledCounter = 1;
            for (int row = 0; row < Rows; row++)
            {
                for (int led = 0; led < LEDsPerRow; led++)
                {
                    Button btn = new Button();
                    this.Controls.Add(btn);
                    btn.Size = new Size(32, 32);
                    btn.Name = "button" + row + "_" + ledCounter.ToString();
                    btn.Location = new Point(led * 32, row * 32 + 35);
                    btn.Click += Btn_Click;
                    ledCounter++;
                }

                Button rowBtn = new Button();
                this.Controls.Add(rowBtn);
                rowBtn.AutoSize = true;
                rowBtn.Name = "btnRowColour_" + row;
                rowBtn.Text = "Change Row Colour";
                rowBtn.Location = new Point(LEDsPerRow * 32 + 15, row * 32 + 35);
                rowBtn.Click += RowBtn_Click;

            }
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                ColorDialog cd = new ColorDialog();
                if (cd.ShowDialog() == DialogResult.Cancel) return;
                Control[] findResult = this.Controls.Find(((Button)sender).Name, false);
                if (findResult.Length > 0) ((Button)findResult[0]).BackColor = cd.Color;
            }
        }

        private void RowBtn_Click(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                int row = Convert.ToInt32(((Button)sender).Name.ToString().Replace("btnRowColour_", ""));
                ColorDialog cd = new ColorDialog();
                if (cd.ShowDialog() == DialogResult.Cancel) return;
                cd.ShowDialog();
                SetColour(cd.Color, row);
            }

        }

        public void SetColour(Color c, int row)
        {
            var rowBtns = this.Controls.OfType<Button>().ToList().Where(b =>
            
                b.Name.StartsWith("button") && b.Name.Replace("button", "").Split("_")[0].Trim() == row.ToString()
            );

            foreach(Button b in rowBtns)
            {
                b.BackColor = c;
            }
        }

        public void SetColour(Color c)
        {
            foreach(Button b in this.Controls.OfType<Button>().ToList())
            {
                b.BackColor = c;
            }
        }

        private void btnChangeAll_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.Cancel) return;
            SetColour(cd.Color);
        }
    }
}
