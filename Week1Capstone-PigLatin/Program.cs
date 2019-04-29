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
            string response = "y";
            string word;
            

            Console.WriteLine("Welcome to the Pig Latin Translator!");

            while (response == "y")
            {
                Console.Write("\nEnter a line to be translated: ");
                word = Console.ReadLine();

                //checks if user input was in all caps
                if (word == word.ToUpper())
                {
                    Console.WriteLine("\n" + (ToPigLatin(word)).ToUpper());
                }
                //while not all caps, checks to see if atleast the first letter is uppercase
                else if (word[0] == (word.ToUpper())[0])
                {
                    Console.WriteLine("\n" + ToTitle(ToPigLatin(word)));
                }
                //checks to see if any caps
                else
                {
                    Console.WriteLine("\n" + (ToPigLatin(word)).ToLower());
                }

                Console.Write("\nTranslate another line? (y/n): ");
                response = Console.ReadLine();


            }

            
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
                //if first letter is a vowel, adds way to message and returns it
                if (message[0] == 'a' || message[0] == 'e' || message[0] == 'i' || message[0] == 'o' || message[0] == 'u')
                {
                    return message += "way";
                }
                else //if the first letter is a consonant
                {
                    //finds first vowel and moves consonants in their initial order to the end of the word sequentially
                    for (int i =0; i < message.Length ;i++)
                    {
                        //if letter is not a vowel, record the number of characters scanned
                        if (message[i] != 'a' && message[i] != 'e' && message[i] != 'i' && message[i] != 'o' && message[i] != 'u' )
                        {
                            count++;
                        }
                        else //if current letter is a vowel, add the substring of consonants that precede it, to the end and then add "ay"
                        {
                            consonants = message.Substring(0, count);
                            word = message.Substring(count, message.Length - count) + consonants + "ay";
                            return word;
                        }
                        
                    }
                    return "Your word does not start with either a vowel or consonant.";
                }
            }
            else //user input doesnt contain a vowel 
            {
                return message + "ay";
            }

        }
        //Convert changed word from PigLatin to TitleCase-PigLatin
        public static string ToTitle(string word)
        {
            string firstLetter = (word.Substring(0,1)).ToUpper();
            string restOfWord = (word.Substring(1, word.Length - 1)).ToLower();
            string result = firstLetter + restOfWord;

            return result;
        }
            
        

    }

}
