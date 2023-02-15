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
    public partial class WordleSolver : Form
    {

        string[] LettersEntered = new string[5];
        string[] words;
        Dictionary<int, String> WordEntered;

        public WordleSolver()
        {
            InitializeComponent();
        }

        private void WordleSolver_Load(object sender, EventArgs e)
        {
            string file = @"C:\Users\FIE21502302\Documents\Visual Studio 2022\Code Snippets\Visual C#\My Code Snippets\Wordle Solver\TrimedWordle.txt";
            words = File.ReadAllLines(file);
            WordEntered = new Dictionary<int, string>();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LettersEntered[0] = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            LettersEntered[1] = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            LettersEntered[2] = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            LettersEntered[3] = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            LettersEntered[4] = textBox5.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PossibleWords.Items.Clear();
            string EnteredWord = textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text;
            bool char1;
            bool char2;
            bool char3;
            bool char4;
            bool char5;

            for (int i =0;i <=4; i++)
            {
                WordEntered.Add(i, EnteredWord.Substring(i, 1));
            }
                
                    foreach (KeyValuePair<int, string> word in WordEntered)
                    {
                        foreach (string Word in words)
                        {
                            if (Word.Substring(word.Key,1) == word.Value)
                            {
                                PossibleWords.Items.Add(word);
                            }
                        }

                        /*if (LettersEntered[letter] == null)
                        {
                            continue;
                        }
                        if (word.IndexOf(LettersEntered[letter]) == -1)
                        {
                            break;
                        }
                        if (word.IndexOf(LettersEntered[letter]) == EnteredWord[letter])
                        {
                            PossibleWords.Items.Add(word);
                            break;
                        }
                        else
                        {
                            PossibleWords.Items.Clear();
                            break;
                        }*/
                }
            }
        }
    }