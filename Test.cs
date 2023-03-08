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
        public List<string> CorrectWords = new List<string>();

        bool LetterOneCorrect;
        bool LetterOneWrongPlace;

        bool LetterTwoCorrect;
        bool LetterTwoWrongPlace;

        bool LetterThreeCorrect;
        bool LetterThreeWrongPlace;

        bool LetterFourCorrect;
        bool LetterFourWrongPlace;

        bool LetterFiveCorrect;
        bool LetterFiveWrongPlace;
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

        public void TestWords(string feedback1, string feedback2, string feedback3, string feedback4, string feedback5, TextBox letter1, TextBox letter2, TextBox letter3, TextBox letter4, TextBox letter5, string[] words)
        {
            string[] Letters = new string[5];
            Random random = new Random();
            int randomValue = random.Next(words.Count() - 1);
            string ChosenWord = words[randomValue];
            if(feedback1 == "Incorrect letter")
            {
                MessageBox.Show(ChosenWord);
            }
            Letters[0] = ChosenWord[0].ToString();
            Letters[1] = ChosenWord[1].ToString();
            Letters[2] = ChosenWord[2].ToString();
            Letters[3] = ChosenWord[3].ToString();
            Letters[4] = ChosenWord[4].ToString();
        }

    }
}
