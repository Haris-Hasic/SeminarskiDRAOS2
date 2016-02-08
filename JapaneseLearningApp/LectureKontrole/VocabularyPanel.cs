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

        private String[] titles;
        private String[] japaneseWords;
        private String[] englishWords;

        private int currentSection;

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
                titles = vocabulary.Titles;
                japaneseWords = vocabulary.JapaneseWords;
                englishWords = vocabulary.EnglishWords;
                currentSection = 1;
                lProgress.Text = currentSection + "/" + titles.Length;

                displayVocabularySection();
            }
            catch (Exception e)
            {
                Label error = new Label();
                error.Text = e.Message;
                flpVocabulary.Controls.Add(error);
            }
        }

        private void displayVocabularySection()
        {
            // Get array of words for the current section
            String[] japaneseWordsInSection = japaneseWords[currentSection - 1].Split(new string[] { "\n" }, StringSplitOptions.None);
            String[] englishWordsInSection = englishWords[currentSection - 1].Split(new string[] { "\n" }, StringSplitOptions.None);

            flpVocabulary.Controls.Clear();

            // Remove scroll bar if it's not needed
            flpVocabulary.AutoScroll = false;
            flpVocabulary.AutoScroll = true;

            for (int i = 0; i < japaneseWordsInSection.Length; i++)
            {
                Label japaneseWord = new Label();
                japaneseWord.Text = japaneseWordsInSection[i];
                japaneseWord.Font = new Font(lTitle.Font.FontFamily, 16);
                japaneseWord.ForeColor = Color.White;
                japaneseWord.Width = (int)(0.4 * flpVocabulary.Width);
                japaneseWord.Height = 30;
                flpVocabulary.Controls.Add(japaneseWord);

                Label englishWord = new Label();
                englishWord.Text = englishWordsInSection[i];
                englishWord.Font = new Font(lTitle.Font.FontFamily, 16);
                englishWord.ForeColor = Color.White;
                englishWord.Width = (int)(0.4 * flpVocabulary.Width);
                englishWord.Height = 30;
                flpVocabulary.Controls.Add(englishWord);
            }
        }

        private void bPrevious_Click(object sender, EventArgs e)
        {
            if (currentSection > 1)
            {
                currentSection--;
                lProgress.Text = currentSection + "/" + titles.Length;
                displayVocabularySection();
            }
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            if (currentSection < titles.Length)
            {
                currentSection++;
                lProgress.Text = currentSection + "/" + titles.Length;
                displayVocabularySection();
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
