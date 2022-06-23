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
        public MatrixButton[,] matrix;

        public int RowCount { get; set; }
        public int LEDCount { get; set; }

        private float LEDsPerRow;
        private ColorDialog cd = new();

        private Dictionary<Color, HashSet<int>> layout = new();

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
            int ledsPerRow = (int)Math.Ceiling((float)this.LEDCount / (float)this.RowCount);

            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                for (int row = 0; row < matrix.GetLength(1); row++)
                {
                    if (col * row > this.LEDCount) break;
                    matrix[col, row].Location = new Point(10 + col * 32, row * 32 + (this.Height / 10));
                    matrix[col, row].Name = "led" + (col * row).ToString();
                    matrix[col, row].Row = row;
                    matrix[col, row].Column = col;
                    matrix[col, row].LEDNumber = (col * row) + 1;
                    matrix[col, row].Click += MatrixButton_Click;
                    this.Controls.Add(matrix[col, row]);
                }
            }
        }

        private void ClearMatrix()
        {
            lblInvalid.Visible = false;
            matrix = new MatrixButton[1,1];
            matrix[0, 0] = new MatrixButton { Name = "led0", Row = 1, Column = 1, Location = new Point(10, (this.Height / 10)) };

            DrawMatrix();
        }

        public void ClearColours()
        {
            foreach (MatrixButton b in this.Controls.OfType<MatrixButton>().ToList())
            {
                b.BackColor = Color.Black;
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
            /*string code = "switch(" + ledIndexVariableName + ") {";
            foreach (KeyValuePair<Color, HashSet<int>> kvp in layout)
            {
                foreach (int led in kvp.Value)
                {
                    code += Environment.NewLine + "\tcase " + led.ToString() + ":";
                }
                code += Environment.NewLine + "\t\t" + ledVariableName + "[" + ledIndexVariableName + "] = " + ColorToHex(kvp.Key, true) + ";";
                code += Environment.NewLine + "\t\tbreak;";
            }

            code += Environment.NewLine + "\tdefault: " + Environment.NewLine + "\t\tbreak;" + Environment.NewLine + "}";
            return code;*/

            return "Hello";
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
    }
}
