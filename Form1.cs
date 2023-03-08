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
        Test tst = new Test();

        List<string> Words = new List<string>();

        List<string> feedback1 = new List<string>() { "Incorrect letter", "Correct letter, wrong place", "Correct letter, correct place" };
        List<string> feedback2 = new List<string>() { "Incorrect letter", "Correct letter, wrong place", "Correct letter, correct place" };
        List<string> feedback3 = new List<string>() { "Incorrect letter", "Correct letter, wrong place", "Correct letter, correct place" };
        List<string> feedback4 = new List<string>() { "Incorrect letter", "Correct letter, wrong place", "Correct letter, correct place"  };
        List<string> feedback5 = new List<string>() { "Incorrect letter", "Correct letter, wrong place", "Correct letter, correct place" };
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
            comboBox1.DataSource = feedback1;
            comboBox2.DataSource = feedback2;
            comboBox3.DataSource = feedback3;
            comboBox4.DataSource = feedback4;
            comboBox5.DataSource = feedback5;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LettersEntered[0] = textBox1.Text;
            textBox2.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            LettersEntered[1] = textBox2.Text;
            textBox3.Focus();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            LettersEntered[2] = textBox3.Text;
            textBox4.Focus();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            LettersEntered[3] = textBox4.Text;
            textBox5.Focus();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            LettersEntered[4] = textBox5.Text;
            button1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string EnteredWord = "";

            foreach (string ValidWord in words)
            {
                Words.Add(ValidWord);
            }
            PossibleWords.Items.Clear();
            WordEntered.Clear();
            Array.Clear(EnteredLetters, 0, EnteredLetters.Count());
            EnteredWord = textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text;

            if (tst.OriginalWordTested)
            {
                string f1 = comboBox1.SelectedItem.ToString();
                string f2 = comboBox2.SelectedItem.ToString();
                string f3 = comboBox3.SelectedItem.ToString();
                string f4 = comboBox4.SelectedItem.ToString();
                string f5 = comboBox5.SelectedItem.ToString();
                tst.TestWords(f1, f2, f3, f4, f5, textBox1, textBox2, textBox3, textBox4, textBox5, words);
            }
            else
            {
                string f1 = comboBox1.SelectedItem.ToString();
                string f2 = comboBox2.SelectedItem.ToString();
                string f3 = comboBox3.SelectedItem.ToString();
                string f4 = comboBox4.SelectedItem.ToString();
                string f5 = comboBox5.SelectedItem.ToString();
                tst.ShowWords(words, Words, PossibleWords, WordEntered, EnteredWord);
                tst.TestWords(f1, f2, f3, f4, f5, textBox1, textBox2, textBox3, textBox4, textBox5, words);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string f1 = comboBox1.SelectedItem.ToString();
            string f2 = comboBox2.SelectedItem.ToString();
            string f3 = comboBox3.SelectedItem.ToString();
            string f4 = comboBox4.SelectedItem.ToString();
            string f5 = comboBox5.SelectedItem.ToString();
            tst.TestWords(f1, f2, f3, f4, f5, textBox1, textBox2, textBox3, textBox4, textBox5, words);
        }
    }
}