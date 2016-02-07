using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseLearningApp.Klase
{
    class Vocabulary
    {
        private String[] titles;
        private String[] japaneseWords;
        private String[] englishWords;

        public Vocabulary(int lectureNumber)
        {
            japaneseWords = System.IO.File.ReadAllLines(@"vocabs\jp" + lectureNumber + ".txt");
            englishWords = System.IO.File.ReadAllLines(@"vocabs\en" + lectureNumber + ".txt");

            List<String> listOfWords = new List<String>();
            List<String> listOfTitles = new List<String>();

            foreach (string line in System.IO.File.ReadLines(@"vocabs\jp" + lectureNumber + ".txt"))
            {
                if (line.StartsWith("%---"))
                {
                    listOfTitles.Add(line.Substring(4));
                    listOfWords.Add("");
                }
                else
                    listOfWords[listOfWords.Count - 1] += line + "\n";
            }
            titles = listOfTitles.ToArray();
            japaneseWords = listOfWords.ToArray();

            listOfWords.Clear();

            foreach (string line in System.IO.File.ReadLines(@"vocabs\en" + lectureNumber + ".txt"))
            {
                if (line.StartsWith("%---"))
                    listOfWords.Add("");
                else
                    listOfWords[listOfWords.Count - 1] += line + "\n";
            }
            englishWords = listOfWords.ToArray();
        }

        public String[] Titles
        {
            get { return titles; }
        }

        public String[] JapaneseWords
        {
            get { return japaneseWords; }
        }

        public String[] EnglishWords
        {
            get { return englishWords; }
        }
    }
}
