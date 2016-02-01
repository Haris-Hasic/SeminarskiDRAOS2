using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseLearningApp.Klase
{
    class Vocabulary
    {
        private String[] japaneseWords;
        private String[] englishWords;

        public Vocabulary(int lectureNumber)
        {
            japaneseWords = System.IO.File.ReadAllLines(@"vocabs\jp" + lectureNumber + ".txt");
            englishWords = System.IO.File.ReadAllLines(@"vocabs\en" + lectureNumber + ".txt");
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
