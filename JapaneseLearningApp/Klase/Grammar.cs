using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseLearningApp.Klase
{
    class Grammar
    {
        String[] grammarSections;

        public Grammar(int lectureNumber)
        {
            List<String> listOfSections = new List<String>();

            foreach (string line in System.IO.File.ReadLines(@"grammar\grammar" + lectureNumber + ".txt"))
            {
                if (line.Equals("%---"))
                    listOfSections.Add("");
                else
                    listOfSections[listOfSections.Count - 1] += line + "\n";
            }
            grammarSections = listOfSections.ToArray();
        }

        public String[] GrammarSections
        {
            get { return grammarSections; }
        }
    }
}
