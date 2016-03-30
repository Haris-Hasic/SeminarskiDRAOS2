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
    public partial class WritingMenu : UserControl
    {
        private Panel mainPanel;

        public WritingMenu(Panel mainPanel)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
        }

        private void bHiragana_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new HiraganaKatakanaListPanel(mainPanel));
            this.mainPanel.Controls.Remove(this);
        }

        private void bKatakana_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new HiraganaKatakanaListPanel(mainPanel, true));
            this.mainPanel.Controls.Remove(this);
        }

        private void bKanji_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new KanjiMenuPanel(mainPanel));
            this.mainPanel.Controls.Remove(this);
        }

        private void bHome_Click(object sender, EventArgs e)
        {
            (this.Parent.Parent.Parent as TabControl).SelectedIndex = 1;
        }
    }
}
