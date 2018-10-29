using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Validation
    {
        //validates the input so that it isnt null or a number
        public static string IsInputValidAuthor()
        {
            while (true)
            {
                string info = Console.ReadLine().ToLower();
                if (string.IsNullOrEmpty(info) || info.Length > 35)//if null or too long, error
                {
                    Console.Write("That is not correct input, try again: ");
                    continue;
                }
                else
                {
                    foreach (char item in info)
                    {
                        if (item == char.Parse(" ") || item == char.Parse("-"))//if name has a space or is hyphenated, continue
                        {
                            continue;
                        }
                        else if (!char.IsLetter(item))//but any other special characters/numbers = error
                        {
                            Console.WriteLine("You must use alphabetical characters, try again ");
                            continue;
                        }
                    }
                }
                return info;
            }
        }
        public static string IsInputValidTitle()//validates but allows for numbers and special characters
        {
            while (true)
            {
                string info = Console.ReadLine().ToLower();
                if (string.IsNullOrEmpty(info) || info.Length > 35)//if null or too long, error
                {
                    Console.Write("That is not correct input, try again: ");
                    
                    continue;
                }
                return info;//allows for all numbers and special characters
            }
        }
        public static string TitleCaseString()
        {
            while (true)
            {
                string sentence = Console.ReadLine();
                if (sentence == null)
                {
                    Console.Write("Error, please enter a title: "); //if theres no input, returns nothing
                    continue;
                }
                char firstChar;
                string[] words = sentence.Split(' ');
                for (int i = 0; i < words.Length; i++)              //for each word in the string
                {
                    if (words[i].Length == 0) continue;             //if length of word is 0, move to next word
                    firstChar = char.ToUpper(words[i][0]);          //changes the first letter of each word as upper case
                    string rest = "";
                    if (words[i].Length > 1)                        //for each word length thats greater than 1 letter
                    {
                        rest = words[i].Substring(1).ToLower();     //changes the rest of the word to lower case
                    }
                    words[i] = firstChar + rest;                    //arranges the first letter and rest of word

                }
                return string.Join(" ", words);                     //joins all the words back into a sentence
            }
        }

        //validates the user input as either y or n
        public static bool YesOrNo()
        {
            while (true)
            {
                string response = Console.ReadLine().ToLower();
                if (response == "y" || response == "yes")
                {
                    return true;
                }
                else if (response== "n" || response == "no")
                {
                    return false;
                }
                else
                {
                    Console.Write("Invalid input, try with yes or no: ");
                    continue;
                    //loops to top
                }
            }
        }
        //need to validiate user number from input menu in Libary Actions.
        public static int SelectNum()
        {
            bool temp;
            int numTemp;
            while (true)
            {
                string userNum = Console.ReadLine();
                if (temp = int.TryParse(userNum, out numTemp))
                {
                    if (numTemp > 0 && numTemp <= 6)
                    {
                        return numTemp;
                    }
                    else
                    {
                        Console.Write("Invalid input, enter a number between 1 and 6: ");
                        continue;
                        //loops to top
                    }
                }
                else
                {
                    Console.Write("Invalid input, enter a number between 1 and 6: ");
                    continue;
                    //loops to top
                }
            }
        }
        //need to validiate user number from input menu in Libary Actions.
        public static int SelectNumBetween1And2()
        {
            bool temp;
            int numTemp;
            while (true)
            {
                string userNum = Console.ReadLine();
                if (temp = int.TryParse(userNum, out numTemp))
                {
                    if (numTemp > 0 && numTemp <= 2)
                    {
                        return numTemp;
                    }
                    else
                    {
                        Console.Write("Invalid input, enter a number between 1 and 2: ");
                        continue;
                    }
                }
                else
                {
                    Console.Write("Invalid input, enter a number between 1 and 2: ");
                    continue;
                }
            }
        }
        //need to validiate user number from input menu in Search.
        public static int SelectFromSearch(int searchLength)//removed string input parameter!!!
        {
            bool temp;
            int numTemp;
            while (true)
            {
                string userNum = Console.ReadLine();
                if (temp = int.TryParse(userNum, out numTemp))
                {

                    if (numTemp - 1 >= 0 && numTemp <= searchLength)
                    {
                        return numTemp - 1;
                    }
                    else
                    {
                        Console.Write("\nInvalid input, enter a number between 1 and {0}: ", searchLength);
                        continue;
                    }
                }
                else
                {
                    Console.Write("Invalid input, enter a number between 1 and {0}: ", searchLength);
                    continue;
                }
            }
        }

    }

}
