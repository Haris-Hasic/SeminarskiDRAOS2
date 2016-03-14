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
    public partial class KanjiListPanel : UserControl
    {
        private const int NUMBER_OF_ROWS = 4;
        private const int NUMBER_OF_COLUMNS = 4;
        private const int BUTTON_WIDTH = 80;
        private const int BUTTON_HEIGHT = 80;
        private const int BUTTON_SPACING = 12;

        List<Button> buttons = new List<Button>();

        private Panel mainPanel;
        private int lectureNumber;

        public KanjiListPanel(Panel mainPanel, int lectureNumber)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
            this.lectureNumber = lectureNumber;

            setButtons();
        }

        private void setButtons()
        {
            for (int i = 0; i < NUMBER_OF_ROWS; i++)
            {
                for (int j = 0; j < NUMBER_OF_COLUMNS; j++)
                {
                    if (i * NUMBER_OF_ROWS + j > 14) break;

                    Button button = new Button();
                    button.Width = BUTTON_WIDTH;
                    button.Height = BUTTON_HEIGHT;
                    button.Left = i * (BUTTON_WIDTH + BUTTON_SPACING);
                    button.Top = j * (BUTTON_HEIGHT + BUTTON_SPACING);
                    button.BackColor = Color.FromArgb(161, 202, 241);
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.Font = new System.Drawing.Font(lTitle.Font.FontFamily, 24);

                    int kanjiNumber = NUMBER_OF_COLUMNS * i + j + 1;
                    Kanji kanji = new Kanji(lectureNumber, kanjiNumber);
                    button.Name = "button" + kanjiNumber;
                    button.Text = kanji.Symbol;

                    button.Click += new EventHandler(kanjiButton_Click);

                    buttons.Add(button);
                    pKanji.Controls.Add(button);
                }
            }
        }

        private void kanjiButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int kanjiNumber = Convert.ToInt32(clickedButton.Name.Substring(6));

            this.mainPanel.Controls.Add(new KanjiPanel(this.mainPanel, lectureNumber, kanjiNumber));
            this.mainPanel.Controls.Remove(this);
        }
    }
}
