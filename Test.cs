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
                        break;
                    }
                    else
                    {
                        Words.Remove(Word);
                    }
                }
            }
        }

        public void TestWords()

    }
}
