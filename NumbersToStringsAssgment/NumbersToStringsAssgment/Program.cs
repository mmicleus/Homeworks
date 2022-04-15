using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToStringsAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int index;
            int powerOf10;
            string[] digits = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] tenTo19 = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = {"twenty-","thirty-","fourty-","fifty-","sixty-","seventy-","eighty-","ninety-" };
            string nr;
            StringBuilder sb = new StringBuilder();

            Console.WriteLine("Introduceti numarul:");
            nr = Console.ReadLine();
            powerOf10 = nr.Length - 1;

            for(int i = 0;i < nr.Length;i++)
            {
                index = nr[i] - 48;
                switch(powerOf10)
                {
                    case 3:
                        sb.Append(digits[index] + " thousand ");
                        break;
                    case 2:
                        if(index != 0)
                            sb.Append(digits[index] + " hundred ");
                        break;
                    case 1:
                        if(index == 1)
                        {
                            sb.Append(tenTo19[nr[i+1] - 48] + " ");
                            i++;
                        }
                        else if(index >= 2)
                        {
                            sb.Append(tens[index - 2]);
                        }
                            
                        break;
                    case 0:
                        if (nr.Length == 1 && index == 0)
                            sb.Append("zero");
                        else
                            sb.Append(digits[index]);
                        break;

                }
                powerOf10--;
            }

            
            Console.WriteLine(sb.ToString().TrimEnd('-',' '));

        }
    }
}
