using System;
using Class_Student_Assignment_Bonus;

namespace StudentAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Student[] studenti;
            double? suma = 0;

            Console.WriteLine("Introduceti numarul de elevi");
            int n = int.Parse(Console.ReadLine());
            studenti = new Student[n];



            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Introduceti numele elevului");
                string name = Console.ReadLine();
                Console.WriteLine("Introduceti varsta elevului");
                byte age = byte.Parse(Console.ReadLine());
                studenti[i] = new Student(age, name);

                Console.WriteLine("Introduceti nota elevului");
                string sNota = Console.ReadLine();
                double dNota;

                studenti[i].Mark = double.TryParse(sNota, out dNota) ? dNota : null;
            }


            foreach (Student s in studenti)
            {
                suma = suma + (s.Mark.HasValue ? s.Mark.Value : 0);
            }

            Console.WriteLine($"Average Mark:{suma / n}");

        }
    }
}
