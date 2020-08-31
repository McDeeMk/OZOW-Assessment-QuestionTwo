using QuestionTwo.Properties;
using System;
using System.Drawing;
using System.Linq;

namespace QuestionTwo.Services
{
    public static class GameLogic
    {

        public static bool UpdateState(frmGameOfLife form, ucGridBox ucCell)
        {
            bool Result = false;
            int deadCount = 0;
            int liveCount = 0;

            foreach (ucGridBox neighbour in ucCell.neightbours)
            {
                ucGridBox item = (ucGridBox)form.pnlGrid.Controls.Find(neighbour.Name, true).First();
                if (item.Equals(null))
                {
                    continue;
                }
                if (item.Dead)
                {
                    deadCount += 1;
                }
                else
                {
                    liveCount += 1;
                }
            }

            if (liveCount < 2)
            {
                ucCell.Dead = true;
                ucCell = SetColor(ucCell);
                Result = true;
            };

            if (liveCount == 2 || liveCount == 3)
            {
                ucCell.Dead = false;
                ucCell = SetColor(ucCell);
                Result = true;
            }

            if (liveCount > 3)
            {
                ucCell.Dead = true;
                ucCell = SetColor(ucCell);
                Result = true;
            }

            if (deadCount == 3)
            {
                ucCell.Dead = false;
                ucCell = SetColor(ucCell);
                Result = true;
            }
            return Result;
        }

        public static bool PlayNetxGeneration(frmGameOfLife form, string Cell)
        {
            ucGridBox ucCell = (ucGridBox)form.pnlGrid.Controls.Find(Cell, false).First();
            if (ucCell != null)
            {
                ucCell.Dead = true;
                ucCell = GameLogic.SetColor(ucCell);
                GameLogic.UpdateState(form, ucCell);
            }
            return ucCell.Dead;
        }

        public static ucGridBox SetColor(ucGridBox ucCell)
        {
            if (ucCell.Dead)
            {
                ucCell.ForeColor = Color.White;
                ucCell.BackColor = Color.Red;
            }
            else
            {
                ucCell.ForeColor = Color.White;
                ucCell.BackColor = Color.LightGreen;
            }
            return ucCell;
        }
    }
}
