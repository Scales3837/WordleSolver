using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Wordle_Solver
{
    internal class Test
    {
        public bool OriginalWordTested = false;
        public List<string> IncorrectLetters = new List<string>();

        List<string> PossibleWords = new List<string>();

        public void ShowWords(string[] words, List<string> Words, ListBox PossibleWordsDisplay, Dictionary<int, String> WordEntered, string EnteredWord) {
  
            for (int i = 0; i <= 4; i++)
            {
                WordEntered.Add(i, EnteredWord.Substring(i, 1));
            }
            foreach (KeyValuePair<int, string> word in WordEntered)
            {
                foreach (string Word in words)
                {
                    if (Word.Substring(word.Key,1) == word.Value)
                    {
                        //PossibleWords.Items.Add(Word);
                    }
                    else if (Words.Count == 1)
                    {
                        PossibleWordsDisplay.Items.Add(Words[0]);

                        OriginalWordTested = true;
                        break;
                    }
                    else
                    {
                        Words.Remove(Word);
                    }
                }
            }
        }



        public string GenerateRandom(string[] WordList, string feedback1, string feedback2, string feedback3, string feedback4, string feedback5)
        {
            string[] Letters = new string[5];
            Random random = new Random();
            int randomValue = random.Next(WordList.Count() - 1);
            string ChosenWord = WordList[randomValue];
            Letters[0] = ChosenWord[0].ToString();
            Letters[1] = ChosenWord[1].ToString();
            Letters[2] = ChosenWord[2].ToString();
            Letters[3] = ChosenWord[3].ToString();
            Letters[4] = ChosenWord[4].ToString();

            bool correct = IsGeneratedWordCorrect(ChosenWord);

            if (OriginalWordTested == false)
            {
                OriginalWordTested = true;
            }
            if (correct)
            {
                MessageBox.Show(ChosenWord);
            }
            else
            {
                GenerateRandom(WordList, feedback1, feedback2, feedback3, feedback4, feedback5);
            }
            if (feedback1 == "Incorrect letter")
            {
                IncorrectLetters.Add(ChosenWord[0].ToString());
            }
            if (feedback2 == "Incorrect letter")
            {
                IncorrectLetters.Add(ChosenWord[1].ToString());
            }
            if (feedback3 == "Incorrect letter")
            {
                IncorrectLetters.Add(ChosenWord[2].ToString());
            }
            if (feedback4 == "Incorrect letter")
            {
                IncorrectLetters.Add(ChosenWord[3].ToString());
            }
            if (feedback5 == "Incorrect letter")
            {
                IncorrectLetters.Add(ChosenWord[4].ToString());
            }

            return null;
        }

        public bool IsGeneratedWordCorrect(string ChosenWord)
        {
            bool b = IncorrectLetters.Any(ChosenWord.Contains);
            if (b)
            {
                //Console.WriteLine("Letter is incorrect");
                MessageBox.Show("Word is incorrect", "Wordle solver", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
            return true;
        }

    public void TestWords(string feedback1, string feedback2, string feedback3, string feedback4, string feedback5, string[] words)
        {
            string NewWord = GenerateRandom(words, feedback1, feedback2, feedback3, feedback4, feedback5);
        }

    }
}