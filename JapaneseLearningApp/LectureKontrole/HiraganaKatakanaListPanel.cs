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
    public partial class HiraganaKatakanaListPanel : UserControl
    {
        private const int NUMBER_OF_ROWS = 5;
        private const int NUMBER_OF_COLUMNS = 4;
        private const int BUTTON_WIDTH = 80;
        private const int BUTTON_HEIGHT = 65;
        private const int BUTTON_SPACING = 10;

        private String[,] symbols = {
                                        { "a", "i", "u", "e", "o" },
                                        { "ka", "ki", "ku", "ke", "ko" },
                                        { "sa", "shi", "su", "se", "so" },
                                        { "ta", "chi", "tsu", "te", "to" },
                                        { "na", "ni", "nu", "ne", "no" },
                                        { "ha", "hi", "fu", "he", "ho" },
                                        { "ma", "mi", "mu", "me", "mo" },
                                        { "ya", "", "yu", "", "yo" },
                                        { "ra", "ri", "ru", "re", "ro" },
                                        { "wa", "", "", "", "wo" },
                                        { "n", "", "", "", "" }
                                    };

        
        private Panel mainPanel;
        private bool displayKatakana;
        List<Button> buttons = new List<Button>();

        public HiraganaKatakanaListPanel(Panel mainPanel, bool displayKatakana = false)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
            this.displayKatakana = displayKatakana;
            setTitle();
            setButtons();
        }

        private void setTitle()
        {
            if (displayKatakana)
                lTitle.Text = "Katakana";
            else
                lTitle.Text = "Hiragana";

            lTitle.Left = (mainPanel.Width - lTitle.Width) / 2;
        }

        private void setButtons()
        {
            for (int i = 0; i < symbols.GetLength(0); i++)
            {
                for (int j = 0; j < symbols.GetLength(1); j++)
                {
                    if (!symbols[i, j].Equals(""))
                    {
                        Button button = new Button();
                        button.Width = BUTTON_WIDTH;
                        button.Height = BUTTON_HEIGHT;
                        button.Left = i * (BUTTON_WIDTH + BUTTON_SPACING);
                        button.Top = j * (BUTTON_HEIGHT + BUTTON_SPACING);
                        button.BackColor = Color.FromArgb(161, 202, 241);
                        button.ForeColor = Color.White;
                        button.FlatStyle = FlatStyle.Flat;
                        button.Font = new System.Drawing.Font(lTitle.Font.FontFamily, 20);
                        button.Text = symbols[i, j];

                        button.Click += new EventHandler(hiraganaButton_Click);

                        buttons.Add(button);
                        pHiragana.Controls.Add(button);
                    }
                }
            }
        }

        private void hiraganaButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            this.mainPanel.Controls.Add(new HiraganaKatakanaPanel(this.mainPanel, clickedButton.Text, displayKatakana));
            this.mainPanel.Controls.Remove(this);
        }
    }
}
