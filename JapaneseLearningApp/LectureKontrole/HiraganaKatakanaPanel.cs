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
    public partial class HiraganaKatakanaPanel : UserControl
    {
        private Panel mainPanel;
        private String reading;
        private Image image;
        private bool displayKatakana;

        public HiraganaKatakanaPanel(Panel mainPanel, String reading, bool displayKatakana = false)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
            this.reading = reading;
            this.displayKatakana = displayKatakana;

            setTitle();
            loadImage();
            setReading();
            setButtons();
        }

        private void setTitle()
        {
            if (displayKatakana)
            {
                lTitle.Text = "Katakana";
                bSymbolList.Text = "Katakana List";
            }
            else
            {
                lTitle.Text = "Hiragana";
                bSymbolList.Text = "Hiragana List";
            }

            lTitle.Left = (mainPanel.Width - lTitle.Width) / 2;
        }

        private void loadImage()
        {
            try
            {
                if (displayKatakana)
                    image = Image.FromFile(@"katakana\" + reading + ".gif");
                else
                    image = Image.FromFile(@"hiragana\" + reading + ".gif");
                pbHiragana.Image = image;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void setReading()
        {
            lReading.Text = reading;
            lReading.Left = (mainPanel.Width - lReading.Width) / 2;
        }

        private void setButtons()
        {
            bPrevious.Text = "< " + HiraganaKatakana.Previous(reading);
            bNext.Text = HiraganaKatakana.Next(reading) + " >";
        }

        private void bSymbolList_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new HiraganaKatakanaListPanel(mainPanel, displayKatakana));
            this.mainPanel.Controls.Remove(this);
        }

        private void bPrevious_Click(object sender, EventArgs e)
        {
            reading = HiraganaKatakana.Previous(reading);
            loadImage();
            setReading();
            setButtons();
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            reading = HiraganaKatakana.Next(reading);
            loadImage();
            setReading();
            setButtons();
        }

        private void lReading_Click(object sender, EventArgs e)
        {

        }
    }
}
