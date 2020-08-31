using QuestionTwo.Properties;
using QuestionTwo.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuestionTwo
{
    public partial class frmGameOfLife : Form
    {
        public frmGameOfLife()
        {
            InitializeComponent();
        }

        Random Rand = new Random();
        int Generations = 0;

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name.Equals("Menu"))
            { 
                frmSetup frmMenu = new frmSetup();
                frmMenu.parentForm = this;
                frmMenu.ShowDialog();          
            }
            else if (e.ClickedItem.Name.Equals("StartGame"))
            {
                if (e.ClickedItem.Text.Equals("Play"))
                {
                    timer1.Enabled = true;
                    timer1.Start();
                    e.ClickedItem.Text = "Stop";
                    e.ClickedItem.Image = Resources.stop;
                }
                else
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    e.ClickedItem.Text = "Play";
                    e.ClickedItem.Image = Resources.play;
                }
               
            }
        }

        private void frmGameOfLife_Load(object sender, System.EventArgs e)
        {
            Grid.DrawGrid(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            int Col = Rand.Next(1, Settings.Default.Columns + 1);
            int Row = Rand.Next(1, Settings.Default.Rows + 1);
            string Cell = string.Concat(alphabets.GetValue(Col), Row);
            GameLogic.PlayNetxGeneration(this,Cell);
            if (Generations.Equals(Settings.Default.Generation))
            {
                var menu = menuStrip1.Items.Find("StartGame", false).First();
                menu.Text = "Play";
                menu.Image = Resources.play;
                MessageBox.Show("Game Over : " + Generations.ToString() + " Generations Played...");
                Generations = 0;
            }
            else
            {
                Generations += 1;
                timer1.Start();
            }     
        }
    }
}
