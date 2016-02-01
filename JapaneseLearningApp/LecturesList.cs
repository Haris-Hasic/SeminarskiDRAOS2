using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JapaneseLearningApp
{
    public partial class LecturesList : UserControl
    {
        private Panel mainPanel;

        public LecturesList(Panel mainPanel)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
        }

        private void bLecture1_Click(object sender, EventArgs e)
        {
            //this.mainPanel.Controls.Remove(this);
            this.Visible = false;
            this.mainPanel.Controls.Add(new LectureMenu(this.mainPanel, 1));
        }
    }
}
