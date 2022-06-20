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
        public int Rows { get; set; }
        public int LEDCount { get; set; }

        private float LEDsPerRow;
        private ColorDialog cd = new();

        private Dictionary<Color, HashSet<int>> layout = new();

        private Color indivColour;

        public ButtonMatrix()
        {
            InitializeComponent();
            Rows = 1;
            LEDCount = 1;
            lblInvalid.Visible = false;
        }

        private void ButtonMatrix_Load(object sender, EventArgs e)
        {
            BuildMatrix();
        }

        private void ClearMatrix()
        {
            foreach (Button b in this.Controls.OfType<Button>().ToList())
            {
                if (b.Name.StartsWith("button") || b.Name.StartsWith("btnRowColour_")) b.Dispose();
            }

            lblInvalid.Visible = false;
            layout.Clear();
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

            LEDsPerRow = (float)LEDCount / (float)Rows;
            if (LEDsPerRow < 1)
            {
                lblInvalid.Visible = true;
                LEDsPerRow = 0;
                return;
            }

            if (LEDsPerRow % 1 != 0) LEDsPerRow = (float)Math.Ceiling(LEDsPerRow);

            int ledCounter = 1;
            for (int row = 0; row < Rows; row++)
            {
                for (int led = 0; led < LEDsPerRow; led++)
                {
                    Button btn = new Button();
                    this.Controls.Add(btn);
                    btn.Size = new Size(32, 32);
                    btn.Name = "button" + row + "_" + ledCounter.ToString();
                    btn.Location = new Point(10 + led * 32, row * 32 + 45);
                    btn.Click += Btn_Click;
                    btn.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    ledCounter++;

                    if (ledCounter > LEDCount) break;
                }

                Button rowBtn = new Button();
                this.Controls.Add(rowBtn);
                rowBtn.AutoSize = true;
                rowBtn.Name = "btnRowColour_" + row;
                rowBtn.Text = "Change Row Colour";
                rowBtn.Location = new Point((int)LEDsPerRow * 32 + 15, row * 32 + 45);
                rowBtn.Click += RowBtn_Click;

            }
        }

        public void ClearColours()
        {
            layout.Clear();
            foreach (Button b in this.Controls.OfType<Button>().ToList())
            {
                if (b.Name.StartsWith("button") || b.Name.StartsWith("btnRowColour_")) b.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            }
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Control[] findResult = this.Controls.Find(((Button)sender).Name, false);
                if (findResult.Length > 0) 
                {
                    Color colourToLog = indivColour;
                    if (((Button)findResult[0]).BackColor == indivColour) colourToLog = ColorTranslator.FromHtml("#FFFFFF");

                    ((Button)findResult[0]).BackColor = colourToLog;

                    int index = Convert.ToInt32(((Button)findResult[0]).Name.Split("_")[1]);
                    HashSet<int>? existing = null;
                    if (layout.TryGetValue(colourToLog, out existing))
                    {
                        existing.Add(index);
                        layout[colourToLog] = existing;
                    }
                    else
                    {
                        existing = new();
                        existing.Add(index);
                        layout.Add(colourToLog, existing);
                    }
                } 
            }
        }

        private void RowBtn_Click(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                int row = Convert.ToInt32(((Button)sender).Name.ToString().Replace("btnRowColour_", ""));
                if (cd.ShowDialog() == DialogResult.Cancel) return;
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
                int index = Convert.ToInt32(b.Name.Split("_")[1]);
                HashSet<int>? existing = null;
                if (layout.TryGetValue(c, out existing)) 
                {
                    existing.Add(index);
                    layout[c] = existing;
                }
                else
                {
                    existing = new();
                    existing.Add(index);
                    layout.Add(c, existing);
                }
            }
        }

        public void SetColour(Color c)
        {
            foreach(Button b in this.Controls.OfType<Button>().ToList())
            {
                if (b.Name.StartsWith("button")) b.BackColor = c;
            }

            layout.Clear();
            layout.Add(c, Enumerable.Range(0, LEDCount).ToHashSet());
        }

        private void btnChangeAll_Click(object sender, EventArgs e)
        {
            if (cd.ShowDialog() == DialogResult.Cancel) return;
            SetColour(cd.Color);
        }

        public string GenerateCode(string ledIndexVariableName, string ledVariableName)
        {
            string code = "switch(" + ledIndexVariableName + ") {";
            foreach (KeyValuePair<Color, HashSet<int>> kvp in layout)
            {
                foreach (int led in kvp.Value)
                {
                    code += Environment.NewLine + "\tcase " + led.ToString() + ":";
                }
                code += Environment.NewLine + "\t\t" + ledVariableName + "[" + ledIndexVariableName + "] = " + ColorToHex(kvp.Key) + ";";
                code += Environment.NewLine + "\t\tbreak;";
            }

            code += Environment.NewLine + "}";
            return code;
        }

        private string ColorToHex(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        private void btnClearColours_Click(object sender, EventArgs e)
        {
            ClearColours();
        }

        private void btnIndiv_Click(object sender, EventArgs e)
        {
            if (cd.ShowDialog() == DialogResult.Cancel) return;
            btnIndiv.BackColor = cd.Color;
            indivColour = cd.Color;
        }
    }
}
