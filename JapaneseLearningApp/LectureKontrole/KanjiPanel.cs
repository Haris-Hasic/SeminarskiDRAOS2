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
        private const int MAX_NUMBER_OF_KANJI = 15;

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
            setReading();
            setButtons();
        }

        private void loadImage()
        {
            pbKanji.Image = kanji.Image;
        }

        private void setReading()
        {
            lKunyomi.Text = "Kunyomi: " + kanji.KunReading;
            lOnyomi.Text = "Onyomi: " + kanji.OnReading;

            lKunyomi.Left = (mainPanel.Width - lKunyomi.Width) / 2;
            lOnyomi.Left = (mainPanel.Width - lOnyomi.Width) / 2;
        }

        private void setButtons()
        {
            Kanji previousKanji = new Kanji(lectureNumber, (kanjiNumber + MAX_NUMBER_OF_KANJI - 2) % MAX_NUMBER_OF_KANJI + 1);
            Kanji nextKanji = new Kanji(lectureNumber, kanjiNumber % MAX_NUMBER_OF_KANJI + 1);

            bPrevious.Text = "< " + previousKanji.Symbol;
            bNext.Text = nextKanji.Symbol + " >";

        }

        private void bSymbolList_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new KanjiListPanel(mainPanel, lectureNumber));
            this.mainPanel.Controls.Remove(this);
        }

        private void bPrevious_Click(object sender, EventArgs e)
        {
            kanjiNumber = (kanjiNumber + MAX_NUMBER_OF_KANJI - 2) % MAX_NUMBER_OF_KANJI + 1;
            kanji = new Kanji(lectureNumber, kanjiNumber);
            loadImage();
            setReading();
            setButtons();
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            kanjiNumber = kanjiNumber % MAX_NUMBER_OF_KANJI + 1;
            kanji = new Kanji(lectureNumber, kanjiNumber);
            loadImage();
            setReading();
            setButtons();
        }


    }
}
