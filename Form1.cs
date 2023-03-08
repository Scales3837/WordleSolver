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
        string[] EnteredLetters = new string[0];
        Dictionary<int, String> WordEntered;

        List<string> Words = new List<string>();

        public WordleSolver()
        {
            InitializeComponent();
        }

        private void WordleSolver_Load(object sender, EventArgs e)
        {
            string file = @"C:\Users\FIE21502302\Documents\Visual Studio 2022\Code Snippets\Visual C#\My Code Snippets\Wordle Solver\valid-wordle-words.txt";
            words = File.ReadAllLines(file);
            WordEntered = new Dictionary<int, string>();
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LettersEntered[0] = textBox1.Text;
            textBox2.Focus();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "_";
            }
        } 

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            LettersEntered[1] = textBox2.Text;
            textBox3.Focus();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "_";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            LettersEntered[2] = textBox3.Text;
            textBox4.Focus();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Text = "_";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            LettersEntered[3] = textBox4.Text;
            textBox5.Focus();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.Text = "_";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            LettersEntered[4] = textBox5.Text;
            button1.Focus();
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.Text = "_";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string EnteredWord = "";

            foreach (string ValidWord in words)
            {
                Words.Add(ValidWord);
            }
            WordEntered.Clear();
            PossibleWords.Items.Clear();

            EnteredWord = textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text;
            if(LettersEntered.Contains("_"))
            {
                
            }
            foreach(string letter in LettersEntered)
            {
                if(letter != "_") {
                    EnteredLetters.Append<string>(letter);
                    EnteredWord = EnteredWord + letter;
                }
            }

            for (int i = 0; i <= 4; i++)
            {
                WordEntered.Add(i, EnteredWord.Substring(i, 1));
            }
                
                    foreach (KeyValuePair<int, string> word in WordEntered)
                    {
                Application.DoEvents();
                foreach (string Word in words)
                {
                            if (Word.Substring(word.Key,1) == word.Value)
                            {
                                //PossibleWords.Items.Add(Word);
                            }
                            else if(word.Value == "_") { }
                            else
                            {
                                Words.Remove(Word);
                            }
                            if (Words.Count == 1)
                            {
                                PossibleWords.Items.Add(Words[0]);
                                break;
                            }
                        }
                }
            }
        }
    }