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


        public int Rows
        {
            get
            {
                return _rows;
            }
            set
            {
                _rows = value; 
                ClearMatrix();
                BuildMatrix();
            }
        }
        public int LEDCount { 
        get
            {
                return _ledCount;
            }
            set
            {
                _ledCount = value;
                ClearMatrix();
                BuildMatrix();
            }
        }

        private int LEDsPerRow;

        public ButtonMatrix()
        {
            InitializeComponent();
            Rows = 1;
            LEDCount = 10;
        }

        private void ButtonMatrix_Load(object sender, EventArgs e)
        {
            ClearMatrix();
            BuildMatrix();
        }

        private void ClearMatrix()
        {
            foreach (Button b in this.Controls.OfType<Button>().ToList())
            {
                b.Dispose();
            }
        }

        private void BuildMatrix()
        {
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
                    btn.Location = new Point(led * 32, row * 32);
                    ledCounter++;
                }

                Button rowBtn = new Button();
                this.Controls.Add(rowBtn);
                rowBtn.AutoSize = true;
                rowBtn.Name = "btnRowColour_" + row;
                rowBtn.Text = "Change Row Colour";
                rowBtn.Location = new Point(LEDsPerRow * 32 + 15, row * 32);

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

        //public void SetColour(Color c, int buttonIndex)
        //{
        //    List<Button> btnList = this.Controls.OfType<Button>().ToList().Where(b => b.Name.StartsWith("button") && b.Name.Replace("button", "").Split("_")[1].Trim() == buttonIndex.ToString()).ToList();
        //    btnList[0].BackColor = c;
        //}

        public void SetColour(Color c)
        {
            foreach(Button b in this.Controls.OfType<Button>().ToList())
            {
                b.BackColor = c;
            }
        }
    }
}
