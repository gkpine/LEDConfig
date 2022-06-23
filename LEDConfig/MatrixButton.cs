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
    public partial class MatrixButton : Button
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public int LEDNumber { get; set; }

        public MatrixButton()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
            this.Size = new Size(32, 32);
            this.LEDNumber = 0;
        }
    }
}
