using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JapaneseLearningApp.LectureKontrole
{
    public partial class KanjiMenuPanel : UserControl
    {
        private Panel mainPanel;

        public KanjiMenuPanel(Panel mainPanel)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
        }

        private void bLecture3_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new KanjiListPanel(this.mainPanel, 3));
            this.mainPanel.Controls.Remove(this);
        }
    }
}
