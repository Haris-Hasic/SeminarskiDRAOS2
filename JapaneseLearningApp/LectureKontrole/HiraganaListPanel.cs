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
    public partial class HiraganaListPanel : UserControl
    {
        private const int NUMBER_OF_ROWS = 5;
        private const int NUMBER_OF_COLUMNS = 4;
        private const int BUTTON_WIDTH = 80;
        private const int BUTTON_HEIGHT = 65;
        private const int BUTTON_SPACING = 10;

        private String[] hiragana = {
                                        "a", "i", "u", "e", "o",
                                        "ka", "ki", "ku", "ke", "ko",
                                        "sa", "shi", "su", "se", "so",
                                        "ta", "chi", "tsu", "te", "to",
                                        "na", "ni", "nu", "ne", "no",
                                        "ha", "hi", "fu", "he", "ho",
                                        "ma", "mi", "mu", "me", "mo",
                                        "ya", "yu", "yo",
                                        "ra", "ri", "ru", "re", "ro",
                                        "wa", "wo",
                                        "n"
                                    };

        
        private Panel mainPanel;
        List<Button> buttons = new List<Button>();

        public HiraganaListPanel(Panel mainPanel)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
            setButtons();
        }

        public void setButtons()
        {
            for (int i = 0; i < 20; i++)
            {
                Button button = new Button();
                button.Width = BUTTON_WIDTH;
                button.Height = BUTTON_HEIGHT;
                button.Left = i / NUMBER_OF_ROWS * (BUTTON_WIDTH + BUTTON_SPACING);
                button.Top = i % NUMBER_OF_ROWS * (BUTTON_HEIGHT + BUTTON_SPACING);
                button.BackColor = Color.FromArgb(161, 202, 241);
                button.ForeColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
                button.Font = new System.Drawing.Font(lTitle.Font.FontFamily, 20);
                button.Text = hiragana[i];

                button.Click += new EventHandler(hiraganaButton_Click);

                buttons.Add(button);
                pHiragana.Controls.Add(button);
            }
        }

        private void hiraganaButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            this.mainPanel.Controls.Add(new HiraganaPanel(this.mainPanel, clickedButton.Text));
            this.mainPanel.Controls.Remove(this);
        }
    }
}
