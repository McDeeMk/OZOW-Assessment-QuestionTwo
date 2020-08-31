using QuestionTwo.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuestionTwo.Services
{
    public static class Grid
    {
        public static Dictionary<string, int> GetGridSettings()
        {
            Dictionary<string, int> gridSetting = new Dictionary<string, int>();
            gridSetting.Add("columns", Settings.Default.Columns);
            gridSetting.Add("rows", Settings.Default.Rows);
            return gridSetting;
        }

        public static bool DrawGrid(frmGameOfLife form)
        {
            bool Result = false;
            Dictionary<string, int> gridSettings = Grid.GetGridSettings();
            form.pnlGrid.Controls.Clear();
            int intx = 5, inty = 5;
            for (var i = 1; i <= gridSettings["columns"]; i++)
            {
                string col = alphabets.GetValue(i);
                if (string.IsNullOrEmpty(col))
                {
                    continue;
                }
                for (var o = 1; o <= gridSettings["rows"]; o++)
                {
                    ucGridBox gridBox = new ucGridBox();
                    gridBox.SetBounds(intx, inty, 50, 50);
                    gridBox.Name = string.Concat(col, o);
                    gridBox.Visible = true;
                    gridBox.Dead = false;
                    gridBox.BackColor = Color.White;
                    gridBox.ForeColor = Color.Black;
                    gridBox.Col = i;
                    gridBox.Row = o;
                    //gridBox.lblKey.Text = gridBox.Name;
                    gridBox.Margin = new Padding(5, 5, 5, 5);
                    gridBox.Show();
                    form.pnlGrid.Controls.Add(gridBox);
                    intx = gridBox.Bounds.X + 55;
                }
                intx = 5;
                inty += 55;
            }

            foreach (ucGridBox cont in form.pnlGrid.Controls)
            {
                cont.neightbours = GetCellNeighbours(form,cont);
                Result = true;
            }
            return Result;
        }

        public static List<ucGridBox> GetCellNeighbours(frmGameOfLife form,ucGridBox ucCell)
        {
            int Col = ucCell.Col;
            int Row = ucCell.Row;
            string Cell = string.Empty;
            List<ucGridBox> neightbours = new List<ucGridBox>();

      
            if ((Row + 1) > 0 && (Row + 1) <= Settings.Default.Rows)
            {
                Cell = string.Concat(alphabets.GetValue(Col), Row + 1);
                ucGridBox neighbour1 = (ucGridBox)form.pnlGrid.Controls.Find(Cell, false).First();
                neightbours.Add(neighbour1);
            }

            if ((Col + 1) > 0 && (Col + 1) <= Settings.Default.Columns)
            {
                Cell = string.Concat(alphabets.GetValue(Col + 1), Row);
                ucGridBox neighbour2 = (ucGridBox)form.pnlGrid.Controls.Find(Cell, false).First();
                neightbours.Add(neighbour2);
            }

            if ((Row + 1) > 0 && (Row + 1) <= Settings.Default.Rows && (Col + 1) > 0 && (Col + 1) <= Settings.Default.Columns)
            {
                Cell = string.Concat(alphabets.GetValue(Col + 1), Row + 1);
                ucGridBox neighbour3 = (ucGridBox)form.pnlGrid.Controls.Find(Cell, false).First();
                neightbours.Add(neighbour3);
            }

            if ((Row - 1) > 0 && (Row - 1) <= Settings.Default.Rows)
            {
                Cell = string.Concat(alphabets.GetValue(Col), Row - 1);
                ucGridBox neighbour4 = (ucGridBox)form.pnlGrid.Controls.Find(Cell, false).First();
                neightbours.Add(neighbour4);
            }

            if ((Col - 1) > 0 && (Col - 1) <= Settings.Default.Columns)
            {
                Cell = string.Concat(alphabets.GetValue(Col - 1), Row);
                ucGridBox neighbour5 = (ucGridBox)form.pnlGrid.Controls.Find(Cell, false).First();
                neightbours.Add(neighbour5);
            }

            if ((Row - 1) > 0 && (Row - 1) <= Settings.Default.Rows && (Col - 1) > 0 && (Col - 1) <= Settings.Default.Columns)
            {
                Cell = string.Concat(alphabets.GetValue(Col - 1), Row - 1);
                ucGridBox neighbour6 = (ucGridBox)form.pnlGrid.Controls.Find(Cell, false).First();
                neightbours.Add(neighbour6);
            }

            if ((Row - 1) > 0 && (Row - 1) <= Settings.Default.Rows && (Col + 1) > 0 && (Col + 1) <= Settings.Default.Columns)
            {
                Cell = string.Concat(alphabets.GetValue(Col + 1), Row - 1);
                ucGridBox neighbour7 = (ucGridBox)form.pnlGrid.Controls.Find(Cell, false).First();
                neightbours.Add(neighbour7);
            }

            if ((Row + 1) > 0 && (Row + 1) <= Settings.Default.Rows && (Col - 1) > 0 && (Col - 1) <= Settings.Default.Columns)
            {
                Cell = string.Concat(alphabets.GetValue(Col - 1), Row + 1);
                ucGridBox neighbour8 = (ucGridBox)form.pnlGrid.Controls.Find(Cell, false).First();
                neightbours.Add(neighbour8);
            }
            return neightbours;
        }
    }
}