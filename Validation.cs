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
        public static string IsInputValid(string info)
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

                    if (numTemp < 0 && numTemp >= 4)
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
    }
}
