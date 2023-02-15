﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wordle_Solver
{
    public partial class WordleSolver : Form
    {

        string[] LettersEntered = new string[5];
        string[] words;

        public WordleSolver()
        {
            InitializeComponent();
        }

        private void WordleSolver_Load(object sender, EventArgs e)
        {
            string file = @"C:\Users\FIE21502302\Documents\Visual Studio 2022\Code Snippets\Visual C#\My Code Snippets\Wordle Solver\TrimedWordle.txt";
            words = File.ReadAllLines(file);
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

            for (int letter = 0; letter < LettersEntered.Length; letter++)
            {
                foreach (string word in words)
                {
                    if(EnteredWord.All(Letter => word.Contains(LettersEntered[letter])) && EnteredWord.GroupBy(Letter => letter).All()) {
                        PossibleWords.Items.Add(word);
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
}
