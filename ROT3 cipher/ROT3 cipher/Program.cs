using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROT3Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            string str;
            char aux;


            str = Console.ReadLine();

            foreach(char c in str)
            {
                if(c >= 'A' && c <= 'W')
                {
                    aux = (char)(c + 3);
                }
                else if(c >= 'X' && c <= 'Z')
                {
                    aux = (char)('A' + (c - 'X'));
                }
                else if (c >= 'a' && c <= 'w')
                {
                    aux = (char)(c + 3);
                }
                else if (c >= 'x' && c <= 'z')
                {
                    aux = (char)('a' + (c - 'x'));
                }
                else
                {
                    aux = c;
                }

                result.Append(aux);
            }

            Console.WriteLine(result);
        }
    }
}
