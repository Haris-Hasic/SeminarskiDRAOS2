using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using JapaneseLearningApp.Klase;

namespace JapaneseLearningApp.LectureKontrole
{
    public partial class KanjiPanel : UserControl
    {
        private Panel mainPanel;
        private int lectureNumber;
        private int kanjiNumber;
        private Kanji kanji;

        public KanjiPanel(Panel mainPanel, int lectureNumber, int kanjiNumber)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
            this.lectureNumber = lectureNumber;
            this.kanjiNumber = kanjiNumber;

            kanji = new Kanji(lectureNumber, kanjiNumber);

            loadImage();
        }

        private void loadImage()
        {
            pbKanji.Image = kanji.Image;
        }

        private void bSymbolList_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new KanjiListPanel(mainPanel, lectureNumber));
            this.mainPanel.Controls.Remove(this);
        }


    }
}
