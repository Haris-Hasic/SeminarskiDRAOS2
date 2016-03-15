using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseLearningApp.Klase
{
    class HiraganaKatakana
    {
        private static String[] symbols = {
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

        public static string Next(string character)
        {
            int index = Array.FindIndex<String>(symbols, c => c.Equals(character));

            return symbols[(index + 1) % symbols.Length];
        }

        public static string Previous(string character)
        {
            int index = Array.FindIndex<String>(symbols, c => c.Equals(character));

            return symbols[(index + symbols.Length - 1) % symbols.Length];
        }
    }
}
