using System;

namespace _05_01LINQ
{
    public class Person 
    {
        public int Salary { get; set; }
        string _name;
        public String Name { 
            get
            {
                return _name;
            }
            
            private set
            {
                _name = value;
            }
        
        }
        public Person( String name, int salary)
        {
            Salary = salary;
            Name = name;
        }
        public override string ToString()
        {
            return Name + " " + Salary;
        }

    }
}
