using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Student_Assignment_Bonus
{
    class Student
    {
        private byte _age;
        private string _name;
        private const byte MIN_AGE = 18;
        private const byte MAX_AGE = 99;
        public double? Mark { get; set; }


        public Student(byte age, string name)
        {
            Age = age;
            _name = name;
        }

        public byte Age
        {
            get { return _age; }

            set
            {
                if (value >= MIN_AGE && value <= MAX_AGE)
                {
                    _age = value;
                }
                else
                {
                    _age = MIN_AGE;
                }

            }
        }

        public dynamic Info
        {
            get
            {
                return $"{_name} {Age.ToString()}";
            }
        }
    }
}
