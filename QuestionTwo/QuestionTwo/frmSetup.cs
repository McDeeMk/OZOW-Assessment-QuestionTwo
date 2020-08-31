using QuestionTwo.Services;
using System;
using System.Windows.Forms;

namespace QuestionTwo
{
    public partial class frmSetup : Form
    {
        public frmGameOfLife parentForm;
        public frmSetup()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtColumns.Text) && !string.IsNullOrEmpty(txtRows.Text))
            {
                if (!int.TryParse(txtColumns.Text, out int col) || !int.TryParse(txtRows.Text, out int row))
                {
                    DisplayMessage();
                }
                else 
                {
                    Setup.SaveSettings(int.Parse(txtColumns.Text), int.Parse(txtRows.Text), int.Parse(txtGeneration.Text));
                    lblCurrentSetup.Text = Setup.GetSettings();
                    Grid.DrawGrid(parentForm);
                }
            }
            else 
            {
                DisplayMessage();
            }
        }

        private void DisplayMessage()
        {
            MessageBox.Show("Invalid input.");
        }

        private void frmSetup_Load(object sender, EventArgs e)
        {
            lblCurrentSetup.Text = Setup.GetSettings();
        }
    }
}
