using NUnit.Framework;
using QuestionTwo;
using QuestionTwo.Services;
using System.Collections.Generic;
using System.Linq;

namespace QuestionTwoTest
{
    public class Tests
    {
        /*
         YOU NEED TO RUN ALL TEST AT ONCE ONE EACH CASE AS THERE IS DEPENDENCY ON OTHER TEST AND SENSITIVE TO THE ORDER OF EXECUTION
         */

        frmGameOfLife mainform = new frmGameOfLife();

        ///<summary>
        /// This will Test Saving of Row 10 and Column 10, Returns True for success and false for fail.
        ///</summary>
        [Test]
        public void Test_Save_SaveSettings()
        {
            Assert.IsTrue(Setup.SaveSettings(10, 10, 500));
        }

        ///<summary>
        /// This will Test retrieving of Row 10 and Column 10, Returns a joined string with a capital 'Columns + X + Rows'.
        ///</summary>
        [Test]
        public void Test_Retrieve_SaveSettings()
        {
            Assert.AreEqual("Col:10 Row:10 Gen:500",Setup.GetSettings());
        }

        ///<summary>
        /// This will Test if we can get an Alphabet by its ID from an enum (A-Z) with IDs(1-26)' where D = 4.
        ///</summary>
        [Test]
        public void Test_Retrieve_Aphabet_Name_By_ID() => Assert.AreEqual("D", alphabets.GetValue(4));

        ///<summary>
        /// This will Test if we can get an Alphabet ID by its Name from an enum (A-Z) with IDs(1-26)' where D = 4.
        ///</summary>
        [Test]
        public void Test_Retrieve_Aphabet_ID_By_Name() => Assert.AreEqual(4, alphabets.GetValue("D"));

        ///<summary>
        /// This will Test retieving Grid settings with a "Dictionary<string, int>" which will be the columns and rows with their values and null if fail.
        ///</summary>
        [Test]
        public void Test_Get_Grid_Settings()
        {
            Assert.IsNotNull(Grid.GetGridSettings());
        }

        ///<summary>
        /// This will Test drawing of the two dimentional grid made of columns and rows based of the number of columns and rows setup.
        ///</summary>
        [Test]
        public void Test_DrawGrid()
        {
            Assert.IsTrue(Grid.DrawGrid(mainform));
        }

        ///<summary>
        /// This will Test retrieving a specific Cell's neighbouring Cells directly around it only. A cell should have a maximum of 8 naightbours. 0 fail and greater then 0 pass.
        ///</summary>
        [Test]
        public void Test_Get_CellNeighbours()
        {        
            ucGridBox ucCell = (ucGridBox)mainform.pnlGrid.Controls.Find("D4", true).First();
            List<ucGridBox> contList = Grid.GetCellNeighbours(mainform, ucCell);
            Assert.AreNotEqual(0,contList.Count);
        }

   
        ///<summary>
        /// This will Test the game logic. updating of cell status to dead or alive based on Game of life conditions.
        /// Condition 1: Any live cell with fewer than two live neighbours dies, as if by underpopulation..
        ///</summary>
        [Test]
        public void Test_PlayGame_Update_Cell_Status_Condition_1()
        {
            
            ucGridBox ucCell = (ucGridBox)mainform.pnlGrid.Controls.Find("D4", true).First();
            ucCell.Dead = true;
            foreach (ucGridBox Cont in ucCell.neightbours)
            {
                Cont.Dead = true;
            }

            int count = 1;
            foreach (ucGridBox Cont in ucCell.neightbours)
            {
                if (count > 3)
                {
                    break;
                }
                Cont.Dead = false;
                count += 1;
            }
            Assert.AreEqual(false, GameLogic.PlayNetxGeneration(mainform, "D4"));
        }

        ///<summary>
        /// This will Test the game logic. updating of cell status to dead or alive based on Game of life conditions.
        /// Condition 2: Any live cell with two or three live neighbours lives on to the next generation.
        ///</summary>
        [Test]
        public void Test_PlayGame_Update_Cell_Status_Condition_2()
        {
            ucGridBox ucCell = (ucGridBox)mainform.pnlGrid.Controls.Find("D4", true).First();
            ucCell.Dead = false;
            foreach (ucGridBox Cont in ucCell.neightbours)
            {
                Cont.Dead = true;
            }

            int count = 1;
            foreach (ucGridBox Cont in ucCell.neightbours)
            {
                if (count.Equals(3))
                {
                    break;
                }
                Cont.Dead = false;
                count += 1;
            }
            Assert.AreEqual(false, GameLogic.PlayNetxGeneration(mainform, "D4"));
        }

        ///<summary>
        /// This will Test the game logic. updating of cell status to dead or alive based on Game of life conditions.
        /// Condition 3: Any live cell with more than three live neighbours dies, as if by overpopulation.
        ///</summary>
        [Test]
        public void Test_PlayGame_Update_Cell_Status_Condition_3()
        {
            
            ucGridBox ucCell = (ucGridBox)mainform.pnlGrid.Controls.Find("D4", true).First();
            ucCell.Dead = false;
            foreach (ucGridBox Cont in ucCell.neightbours)
            {
                Cont.Dead = true;
            }

            int count = 1;
            foreach (ucGridBox Cont in ucCell.neightbours)
            {
                if (count.Equals(5))
                {
                    break;
                }
                Cont.Dead = false;
                count += 1;
            }

            Assert.AreEqual(true, GameLogic.PlayNetxGeneration(mainform, "D4"));
        }

             ///<summary>
        /// This will Test the game logic. updating of cell status to dead or alive based on Game of life conditions.
        /// Condition 4: Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        ///</summary>
        [Test]
        public void Test_PlayGame_Update_Cell_Status_Condition_4()
        {
            
            ucGridBox ucCell = (ucGridBox)mainform.pnlGrid.Controls.Find("D4", true).First();
            ucCell.Dead = true;
            foreach (ucGridBox Cont in ucCell.neightbours)
            {
                Cont.Dead = true;
            }

            int count = 1;
            foreach (ucGridBox Cont in ucCell.neightbours)
            {
                if (count > 3)
                {
                    break;
                }
                Cont.Dead = false;
                count += 1;
            }
            Assert.AreEqual(false, GameLogic.PlayNetxGeneration(mainform, "D4"));
        }
    }
}