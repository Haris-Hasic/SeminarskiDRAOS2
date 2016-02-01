using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseLearningApp.Klase
{
    class Story
    {
        private String japaneseTitle;
        private String englishTitle;
        private String japaneseText;
        private String englishText;

        public Story(int lectureNumber)
        {
            String[] lines = System.IO.File.ReadAllLines(@"stories\jp" + lectureNumber + ".txt");
            japaneseTitle = lines[0];
            for (int i = 1; i < lines.Length; i++)
            {
                japaneseText += lines[i] + "\n";
            }

            lines = System.IO.File.ReadAllLines(@"stories\en" + lectureNumber + ".txt");
            englishTitle = lines[0];
            for (int i = 1; i < lines.Length; i++)
            {
                englishText += lines[i] + "\n";
            }
        }

        public String JapaneseTitle
        {
            get { return japaneseTitle; }
        }

        public String EnglishTitle
        {
            get { return englishTitle; }
        }

        public String JapaneseText
        {
            get { return japaneseText; }
        }

        public String EnglishText
        {
            get { return englishText; }
        }
    }
}
