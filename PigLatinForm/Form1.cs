using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PigLatinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Translate_Click_1(object sender, EventArgs e)
        {
            string sentence = InputBox.Text;
            //TranslateToPigLatin(sentence);
            OutputBox.Text = TranslateToPigLatin(sentence);
        }
        /*Console.WriteLine("Please enter a sentence to convert to Pig Latin");
            string sentence = InputBox.text;
        string pigLatin = TranslateToPigLatin(sentence);    //Runs function over user input
        Console.WriteLine(pigLatin);*/
        public string TranslateToPigLatin(string sentence)
        {
            //Console.WriteLine("Please enter a sentence to convert to Pig Latin");

            //string pigLatin = TranslateToPigLatin(sentence);    //Runs function over user input
            //Console.WriteLine(pigLatin);

            string[] vowels = { "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y" }; //string array of vowels, (including Y) for PigLatin rules.


            List<string> pigWords = new List<string>(); //Instantiate new pigWords List

            // Break sentence down into words
            foreach (string word in sentence.Split(' '))
            {


                int firstVowelPosition = 1; //Instantiate and set with value.
                string firstLetter = word.Substring(0, 1); //assign the first letter of the originally handled word
                bool isFirstLetterCaps = char.IsUpper(char.Parse(firstLetter)); //check if first letter is capitalised

                for (int i = 0; i < word.Length; i++) //Iterate over each char in each word.
                {
                    string v = word[i].ToString(); //cast lambda position of word to string
                    bool isLetterAVowel = vowels.Contains(v); //check if letter is a vowel (including y)
                    if (isLetterAVowel)
                    {
                        firstVowelPosition = i; //assign position of vowel to variable
                        break;
                    }
                }

                string beforeVowel = word.Substring(0, firstVowelPosition); //assign all consanants before first vowel to variable
                string restOfWord = word.Substring(firstVowelPosition, word.Length - firstVowelPosition); //assign all remaining chars to variable
                string pigWord = null; //Instantiate variable to null


                // Rule 1 - Vowel in first position, add "way" to end
                if (firstVowelPosition == 0)
                {
                    pigWord = word.ToLower() + "way"; //decapitalise final word
                }

                // Rule 2 - Vowel in second or greater position,
                //          move consonants before vowel to end
                //          and add "ay" to end
                else if (firstVowelPosition > 0)
                {
                    pigWord = restOfWord.ToLower() + beforeVowel.ToLower() + "ay"; //decapitalise final word
                }

                if (isFirstLetterCaps)
                {
                    // change pigWords first letter to upper case
                    string completedWord = pigWord.Substring(0, 1).ToUpper() + pigWord.Substring(1);
                    pigWords.Add(completedWord);
                }
                else
                {
                    pigWords.Add(pigWord); //if no capitalised first letter was detected, simply add the word as lowercase
                }
            }
            
            return string.Join(" ", pigWords); //add complete pigwords to string and return it to user

        }
    }
}
