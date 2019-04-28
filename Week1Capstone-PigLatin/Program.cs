using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1Capstone_PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Build Specifications:
              1) Convert each word to a lowercase before translating

              2) If a word starts with a vowel (a,e,i,o,u), just add "way" onto the ending.

              3) If a word starts with a consonant, move all of the consonants that appear 
                 before the first vowel to the end of the word, then add "ay" to the end of the word.

                                            *Treat "y" as a consonant.*

                App:
                - Prompt the user for a word.
                - Translates the text to Pig Latin and displays it to the Console.
                - Asks the user if they would want to translate another word.

            Extended Challenges:
            - Keep the case of the word, whether its uppercase(WORD), title case (Word), or lowercase(word).
            - Allow punctuation in the input string.
            - Translate words with contractions. EX: can't become an'tcay
            - Don't translate words that have numbers or symbols. EX: 189 should be left as 189 and 
              hello@grandcircus.co should be left as hello@grandcircus.co.
            - Check that the user has actually entered text before translating.
            - Make the application take a line instead of a single word, and then find the Pig Latin 
              for each word in the line.
             */
            //string.substring(index of string, literal length)

            Console.Write("Please enter a word: ");
            string word = Console.ReadLine();


            Console.WriteLine($"{word} is now {ToPigLatin(word)}");
            
        }
        //Convert to PigLatin
        public static string ToPigLatin(string message)
        {
            message = message.ToLower();
            int count = 0;
            string consonants, word;


            //does something whenever it sees a vowel

            if (message.Contains("a") || message.Contains("e") || message.Contains("i") || message.Contains("o") || message.Contains("u") )
            {
                if (message[0] == 'a' || message[0] == 'e' || message[0] == 'i' || message[0] == 'o' || message[0] == 'u')
                {
                    return message += "way";
                }
                //finds first vowel and moves consonants before it to the end of the word sequentially
                else
                {
                    for(int i =0; i < message.Length ;i++)
                    {

                        if (message[i] != 'a' && message[i] != 'e' && message[i] != 'i' && message[i] != 'o' && message[i] != 'u')
                        {
                            count++;
                        }
                        else
                        {
                            consonants = message.Substring(0, count);
                            word = message.Substring(count, message.Length - 1) + consonants + "ay";
                            return word;
                        }
                        
                    }
                    return message;
                }
            }
            else
            {
                return message + "ay";
            }

        }

        public static int StrLength(string message)
        {
            int stringLength = 0;

            foreach (char letter in message)
            {
                stringLength++;
            }

            return stringLength;
        }
    }
}
