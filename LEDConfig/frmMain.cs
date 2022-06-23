namespace LEDConfig
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            txtVarName.TextChanged += TxtVarName_TextChanged;
            txtIndex.TextChanged += TxtIndex_TextChanged;

            txtVarName.Text = Properties.Settings.Default.LEDArrayName;
            txtIndex.Text = Properties.Settings.Default.LEDIndexName;
            txtNumLeds.Text = Properties.Settings.Default.LEDCount.ToString();
            txtRows.Text = Properties.Settings.Default.RowCount.ToString();
        }

        private void TxtIndex_TextChanged(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIndex.Text))
            {
                Properties.Settings.Default.LEDIndexName = txtIndex.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void TxtVarName_TextChanged(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVarName.Text))
            {
                Properties.Settings.Default.LEDArrayName = txtVarName.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            int ledCount;
            int rowCount;
            if (!int.TryParse(txtNumLeds.Text, out ledCount) || !int.TryParse(txtRows.Text, out rowCount)) return;

            buttonMatrix.DrawMatrix(ledCount, rowCount);
        }

        private void txtRows_TextChanged(object sender, EventArgs e)
        {
            int rowCount;
            if (!int.TryParse(txtRows.Text, out rowCount))
            {
                txtRows.ForeColor = Color.Red;
            }
            else
            {
                txtRows.ForeColor = Color.Black;
                Properties.Settings.Default.RowCount = rowCount;
                Properties.Settings.Default.Save();
            }
        }

        private void txtNumLeds_TextChanged(object sender, EventArgs e)
        {
            int ledCount;
            if (!int.TryParse(txtNumLeds.Text, out ledCount))
            {
                txtNumLeds.ForeColor = Color.Red;
            }
            else
            {
                txtNumLeds.ForeColor = Color.Black;
                Properties.Settings.Default.LEDCount = ledCount;
                Properties.Settings.Default.Save();
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIndex.Text) || string.IsNullOrEmpty(txtVarName.Text))
            {
                MessageBox.Show("Must have both an index variable name and LED variable name to generate code.");
                return;
            }

            txtCodeGen.Text = buttonMatrix.GenerateCode(txtIndex.Text, txtVarName.Text);
        }
    }
}