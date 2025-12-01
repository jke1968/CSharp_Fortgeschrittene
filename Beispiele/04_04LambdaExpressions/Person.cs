using System;

namespace _04_04LambdaExpressions
{
    public class Person : IComparable<Person>
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
            return Salary + " " + Name;
        }

        public int CompareTo(Person other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
