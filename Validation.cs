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
    }
}
