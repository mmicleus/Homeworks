using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrom
{
    internal class PalindromAssignment
    {
        static void Main(string[] args)
        {
            string str;
            int length;
            bool isPalind = true;

            str = Console.ReadLine();
            length = str.Length;    

            for(int i = 0;i <= length / 2;i++)
            {
                if(str[i] != str[length - 1 - i])
                {
                    isPalind = false;
                    break;
                }
            }

           string message =  (isPalind == true) ? $"'{str}' este palindrom." : $"'{str}' nu este palindrom";

            Console.WriteLine(message);

        }
    }
}
