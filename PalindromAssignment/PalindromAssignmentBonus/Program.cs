using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrom
{
    internal class PalindromAssignmentBonus
    {
        static void Main(string[] args)
        {
            string str;
            StringBuilder sb = new StringBuilder();
            int length;
            bool isPalind = true;

            str = Console.ReadLine();

            foreach(char ch in str)
            {
                if (Char.IsLetter(ch))
                    sb.Append(ch);
            }


            length = sb.Length;

            for (int i = 0; i <= length / 2; i++)
            {
                if (sb[i] != sb[length - 1 - i])
                {
                    isPalind = false;
                    break;
                }
            }

            string message = (isPalind == true) ? $"'{str}' este palindrom." : $"'{str}' nu este palindrom";

            Console.WriteLine(message);

        }
    }
}
