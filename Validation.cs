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
        public static string IsInputValidAuthor(string info)
        {
            while (true)
            {
                if (string.IsNullOrEmpty(info) || info.Length > 35)
                {
                    Console.WriteLine("That is not correct input, try again");

                }

                foreach (char item in info)
                {
                    if (!char.IsLetter(item))
                    {
                        Console.WriteLine("You must use alphabetical characters, try again ");

                    }
                }

                return info;
            }

        }
        public static string IsInputValidTitle(string info)//validates but allows for numbers and special characters
        {
            while (true)
            {
                if (string.IsNullOrEmpty(info) || info.Length > 35)
                {
                    Console.WriteLine("That is not correct input, try again");

                }
                return info;
            }

        }
        public static string TitleCaseString(string sentence)
        {
            if (sentence == null) return sentence;//if theres no input, returns nothing

            char firstChar;
            string[] words = sentence.Split(' ');
            for (int i = 0; i < words.Length; i++)//for each word in the string
            {
                if (words[i].Length == 0) continue;//if length of word is 0, move to next word

                //if (words[i] != ("a"||"an"||"the"||"of" ||"and"||"but"||"for"||"at"||"by"||"from"))
                //{
                firstChar = char.ToUpper(words[i][0]);//changes the first letter of each word as upper case
                //}
                string rest = "";
                if (words[i].Length > 1)//for each word length thats greater than 1 letter
                {
                    rest = words[i].Substring(1).ToLower();//changes the rest of the word to lower case
                }
                words[i] = firstChar + rest;//arranges the first letter and rest of word
            }
            return string.Join(" ", words);//joins the words back into a sentence
        }
         // if (words.Contains("a","an","the","of","and","but","for","at","by","from" ))???? add?
      
        //validates the user input as either y or n
        public static bool YesOrNo(string response)
        {

            while (true)
            {

                if (response == "y")
                {
                    return true;
                }
                else if (response == "n")
                {
                    return false;
                }
                else
                {
                    Console.Write("Invalid input, try (y/n): ");
                    response = Console.ReadLine().ToLower();//changes variable and loops to top

                }
            }
        }
        //need to validiate user number from input menu in Libary Actions.
        public static int SelectNum(string userNum)
        {
            bool temp;
            int numTemp;
            while (true)
            {
                if (temp = int.TryParse(userNum, out numTemp))
                {

                    if (numTemp > 0 && numTemp <= 6)
                    {
                        return numTemp;
                        //break; //do we need the break or does the return break it.
                    }
                    else
                    {
                        Console.Write("Invalid input, enter a number between 1 and 4.");
                        userNum = Console.ReadLine();//changes variable and loops to top

                    }
                }
                else
                {
                    Console.Write("Invalid input, enter a number between 1 and 4.");
                    userNum = Console.ReadLine();//changes variable and loops to top
                }
            }
        }
        //need to validiate user number from input menu in Libary Actions.
        public static int SelectNumBetween1And2(string userNum)
        {
            bool temp;
            int numTemp;
            while (true)
            {
                if (temp = int.TryParse(userNum, out numTemp))
                {

                    if (numTemp > 0 && numTemp <= 2)
                    {
                        return numTemp;
                        //break; //do we need the break or does the return break it.
                    }
                    else
                    {
                        Console.Write("Invalid input, enter a number between 1 and 2.");
                        userNum = Console.ReadLine();//changes variable and loops to top

                    }
                }
                else
                {
                    Console.Write("Invalid input, enter a number between 1 and 2.");
                    userNum = Console.ReadLine();//changes variable and loops to top
                }
            }
        }
        //need to validiate user number from input menu in Search.
        public static int SelectFromSearch(string userNum, int searchLenght)
        {
            bool temp;
            int numTemp;
            while (true)
            {
                if (temp = int.TryParse(userNum, out numTemp))
                {

                    if (numTemp -1 >= 0 && numTemp <= searchLenght)
                    {
                        return numTemp -1;
                        //break; //do we need the break or does the return break it.
                    }
                    else
                    {
                        Console.Write("\nInvalid input, enter a number between 1 and {0}: ", searchLenght);
                        userNum = Console.ReadLine();//changes variable and loops to top

                    }
                }
                else
                {
                    Console.Write("Invalid input, enter a number between 1 and {0}: ", searchLenght);
                    userNum = Console.ReadLine();//changes variable and loops to top
                }
            }
        }

    }

}
