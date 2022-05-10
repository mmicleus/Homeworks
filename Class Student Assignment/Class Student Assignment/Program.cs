using System;
using Class_Student_Assignment;

namespace StudentAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Student[] studenti;
            
            
            Console.WriteLine("Introduceti numele elevului");
            string name = Console.ReadLine();
            Console.WriteLine("Introduceti varsta elevului");
            byte age = byte.Parse(Console.ReadLine());
            

            Student st = new Student(age,name);

            Console.WriteLine(st.Info);

        }
    }
}
