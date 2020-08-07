using System;
using System.Collections.Generic;

namespace RansomNote
{
    class Program
    {
        static void Main(string[] args)
        {
            bool caseMismatch = FindWordsInDocument("attack at dawn"); //will return false
            bool caseMatch = FindWordsInDocument("Attack at dawn");  //will return true
            bool wholeWordNotInOrderMatch = FindWordsInDocument("Attack dawn at");  //will return true
            bool wholeWordMatchInExtraWords = FindWordsInDocument("Attack at dawn is to be targeted");  //will return true

            Console.WriteLine($"when case does not match the result is {caseMismatch}");
            Console.WriteLine($"when case matches the result is {caseMatch}");
            Console.WriteLine($"when all the words found but are not in oder and case matched, then result is {wholeWordNotInOrderMatch}");
            Console.WriteLine($"when all the words matches with additional words, then result is {wholeWordMatchInExtraWords}");


            Console.ReadLine();
        }

        /// <summary>
        /// Find the ransome note words from the magazine
        /// </summary>
        /// <param name="magazine">magazine passed as a string parameter</param>
        /// <returns>returns true if words are found and matches the case</returns>
        public static bool FindWordsInDocument(string magazine)
        {

            string ransomeNote = "Attack at dawn";

            var ransomeNoteDict = ConvertStringToDictionary(ransomeNote);

            var magazineDict = ConvertStringToDictionary(magazine);

            bool isMatchFound = false;


            foreach (var item in ransomeNoteDict)
            {
                if (magazineDict.ContainsKey(item.Key))
                {
                    isMatchFound = true;
                    continue;
                }
                else
                {
                    isMatchFound = false;
                    break;
                }

            }
            return isMatchFound;
        }

        private static Dictionary<string, int> ConvertStringToDictionary(string str)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            string[] tempStore = str.Split(' ');


            for (int i = 0; i < tempStore.Length; i++)
            {
                dict.Add(tempStore[i], 1);
            }
            return dict;
        }

    }
}
