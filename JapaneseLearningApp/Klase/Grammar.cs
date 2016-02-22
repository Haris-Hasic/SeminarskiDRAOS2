using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseLearningApp.Klase
{
    class Grammar
    {
        String[] titles;
        String[] grammarSections;

        public Grammar(int lectureNumber)
        {
            List<String> listOfTitles = new List<String>();
            List<String> listOfSections = new List<String>();

            foreach (string line in System.IO.File.ReadLines(@"grammar\grammar" + lectureNumber + ".txt"))
            {
                if (line.StartsWith("%---"))
                {
                    listOfTitles.Add(line.Substring(4));
                    listOfSections.Add("");
                }
                else
                    listOfSections[listOfSections.Count - 1] += line + "\n";
            }
            titles = listOfTitles.ToArray();
            grammarSections = listOfSections.ToArray();
        }

        public String[] Titles
        {
            get { return titles; }
        }

        public String[] GrammarSections
        {
            get { return grammarSections; }
        }
    }
}
