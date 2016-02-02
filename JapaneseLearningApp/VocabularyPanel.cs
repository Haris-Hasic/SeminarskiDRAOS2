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

namespace JapaneseLearningApp
{
    public partial class VocabularyPanel : UserControl
    {
        private int lectureNumber;
        private Panel mainPanel;

        public VocabularyPanel(Panel mainPanel, int lectureNumber)
        {
            InitializeComponent();

            this.mainPanel = mainPanel;
            this.lectureNumber = lectureNumber;
            loadVocabulary();
        }

        private void loadVocabulary()
        {
            try
            {
                Vocabulary vocabulary = new Vocabulary(lectureNumber);

                for (int i = 0; i < vocabulary.JapaneseWords.Length; i++)
                {
                    Label japaneseWord = new Label();
                    japaneseWord.Text = vocabulary.JapaneseWords[i];
                    japaneseWord.Font = new Font(lTitle.Font.FontFamily, 16);
                    japaneseWord.ForeColor = Color.White;
                    japaneseWord.Width = (int)(0.4 * flpVocabulary.Width);
                    japaneseWord.Height = 30;
                    flpVocabulary.Controls.Add(japaneseWord);

                    Label englishWord = new Label();
                    englishWord.Text = vocabulary.EnglishWords[i];
                    englishWord.Font = new Font(lTitle.Font.FontFamily, 16);
                    englishWord.ForeColor = Color.White;
                    englishWord.Width = (int)(0.4 * flpVocabulary.Width);
                    englishWord.Height = 30;
                    flpVocabulary.Controls.Add(englishWord);
                }
            }
            catch (Exception e)
            {
                Label error = new Label();
                error.Text = e.Message;
                flpVocabulary.Controls.Add(error);
            }
        }

        private void bStory_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new StoryPanel(this.mainPanel, this.lectureNumber));
            this.mainPanel.Controls.Remove(this);
        }

        private void bGrammar_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Add(new GrammarPanel(this.mainPanel, this.lectureNumber));
            this.mainPanel.Controls.Remove(this);
        }
    }
}
