using System;

namespace _01_03DelegatesAsParameters
{
    class Person : IComparable<Person>
    {
        public string Name { get; private set; }
        public decimal Salary { get; private set; }
        public Person(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }
        public override string ToString()
        {
            return String.Format("{0,-10} {1}",Name,Salary);
        }
        // default compare Property : Name 
        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
