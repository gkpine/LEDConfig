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
        private MatrixButton[,] matrix;
        public int RowCount { get; set; }
        public int LEDCount { get; set; }

        private ColorDialog cd = new();

        private Color indivColour = Color.Empty;

        public ButtonMatrix()
        {
            InitializeComponent();
            matrix = new MatrixButton[1,1];
            RowCount = 1;
            LEDCount = 1;
            lblInvalid.Visible = false;
        }

        private void ButtonMatrix_Load(object sender, EventArgs e)
        {
            DrawMatrix(this.LEDCount, this.RowCount);
        }

        public void DrawMatrix(int ledCount, int rowCount)
        {
            this.LEDCount = ledCount;
            this.RowCount = rowCount;

            int ledsPerRow = (int)Math.Ceiling((float)this.LEDCount / (float)this.RowCount);
            matrix = new MatrixButton[ledsPerRow, rowCount];

            for(int col = 0; col < ledsPerRow; col++)
            {
                for (int row = 0; row < rowCount; row++)
                {
                    matrix[col, row] = new MatrixButton();
                }
            }
            DrawMatrix();
        }

        private void DrawMatrix()
        {
            this.Controls.OfType<Button>().ToList().Where(b => b.Name.StartsWith("btnChangeRow")).ToList().ForEach(b => b.Dispose());
            this.Controls.OfType<MatrixButton>().ToList().ForEach(b => b.Dispose());

            int ledsPerRow = (int)Math.Ceiling((float)this.LEDCount / (float)this.RowCount);
            int ledCounter = 0;

            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                for (int row = 0; row < matrix.GetLength(1); row++)
                {
                    ledCounter = ((ledsPerRow * row) + col);
                    if (!chkInverse.Checked && (row + 1) % 2 == 0)
                    {
                        ledCounter = ((ledsPerRow * (row+1)) - col) -1;
                    } 
                    else if (chkInverse.Checked && (row + 1) % 2 != 0)
                    {
                        ledCounter = ((ledsPerRow * (row + 1)) - col) - 1;
                    }

                    if (chkInverse.Checked) ledCounter = (LEDCount - 1) - ledCounter;
                    
                    if (col * row > this.LEDCount) break;
                    matrix[col, row].Location = new Point(10 + col * 32, row * 32 + (this.Height / 10));
                    matrix[col, row].Name = "led" + ledCounter.ToString();
                    matrix[col, row].Row = row;
                    matrix[col, row].Column = col;
                    matrix[col, row].LEDNumber = ledCounter;
                    matrix[col, row].Click += MatrixButton_Click;
                    matrix[col, row].ForeColor = Color.White;
                    matrix[col, row].Text = matrix[col, row].LEDNumber.ToString();
                    matrix[col, row].Font = new Font(FontFamily.GenericSerif, 4);
                    this.Controls.Add(matrix[col, row]);

                    if (col == matrix.GetLength(0) - 1)
                    {
                        Button changeRow = new Button();
                        changeRow.Name = "btnChangeRow" + row;
                        changeRow.Text = "Change Row Colour";
                        changeRow.AutoSize = true;
                        changeRow.Location = new Point((10 + col * 32) + 45, row * 32 + (this.Height / 10));
                        changeRow.Click += RowBtn_Click;
                        this.Controls.Add(changeRow);
                    }
                }
                
            }
        }

        public void ClearColours()
        {
            foreach (MatrixButton b in this.Controls.OfType<MatrixButton>().ToList())
            {
                b.BackColor = Color.Black;
                matrix[b.Column, b.Row] = b;
            }
        }

        private void MatrixButton_Click(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                MatrixButton mb = (MatrixButton)sender;
                if (indivColour != Color.Empty && mb.BackColor != indivColour)
                {
                    mb.BackColor = indivColour;
                    matrix[mb.Column, mb.Row] = mb;
                }
                else if (mb.BackColor == indivColour)
                {
                    mb.BackColor = Color.Black;
                    matrix[mb.Column, mb.Row] = mb;
                }
                else
                {
                    MessageBox.Show(string.Format("Row: {0}, Col: {1}", mb.Row, mb.Column));
                }
            }
        }

        private void RowBtn_Click(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                int row = Convert.ToInt32(((Button)sender).Name.ToString().Replace("btnChangeRow", ""));
                if (cd.ShowDialog() == DialogResult.Cancel) return;
                SetColour(cd.Color, row);
            }
        }

        public void SetColour(Color c, int row)
        {
            List<MatrixButton> buttons = this.Controls.OfType<MatrixButton>().ToList().Where(b => b.Row == row).ToList();
            foreach(MatrixButton b in buttons)
            {
                b.BackColor = c;
                matrix[b.Column, b.Row] = b;
            }
        }

        public void SetColour(Color c)
        {
            foreach(MatrixButton b in this.Controls.OfType<MatrixButton>().ToList())
            {
                b.BackColor = c;
                matrix[b.Column, b.Row] = b;
            }
        }

        private void btnChangeAll_Click(object sender, EventArgs e)
        {
            if (cd.ShowDialog() == DialogResult.Cancel) return;
            SetColour(cd.Color);
        }

        public string GenerateCode(string ledIndexVariableName, string ledVariableName)
        {
            Dictionary<Color, SortedSet<int>> layout = new();
            foreach(MatrixButton b in this.Controls.OfType<MatrixButton>().ToList())
            {
                SortedSet<int>? existing;
                if (layout.TryGetValue(b.BackColor, out existing))
                {
                    existing.Add(b.LEDNumber);
                    
                    layout[b.BackColor] = existing;
                }
                else
                {
                    existing = new();
                    existing.Add(b.LEDNumber);
                    layout.Add(b.BackColor, existing);
                }
            }


            string code = "switch (" + ledIndexVariableName + ") {";
            foreach (KeyValuePair<Color, SortedSet<int>> kvp in layout)
            {
                foreach (int led in kvp.Value)
                {
                    code += Environment.NewLine + "\tcase " + led.ToString() + ":";
                }
                code += Environment.NewLine + "\t\t" + ledVariableName + "[" + ledIndexVariableName + "] = " + ColorToHex(kvp.Key, true) + ";";
                code += Environment.NewLine + "\t\tbreak;";
            }

            code += Environment.NewLine + "\tdefault: " + Environment.NewLine + "\t\tbreak;" + Environment.NewLine + "}";
            return code;
        }

        private string ColorToHex(Color c, bool useZeroX)
        {
            return (useZeroX ? "0x" : "#") + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
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

        private void chkInverse_CheckedChanged(object sender, EventArgs e)
        {
            DrawMatrix(LEDCount, RowCount);
        }
    }
}
