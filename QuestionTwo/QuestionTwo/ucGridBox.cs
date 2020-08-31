using System.Collections.Generic;
using System.Windows.Forms;

namespace QuestionTwo
{
    public partial class ucGridBox : UserControl
    {
        public ucGridBox()
        {
            InitializeComponent();
        }
        public bool Dead { get; set; }
        public List<ucGridBox> neightbours { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }
    }
}