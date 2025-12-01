using System;
using System.Data.Linq.Mapping;

namespace _01_07LINQ2SQL
{
    // [Table] ist ein C# Attribute
    // eine Attribute stellt Metadaten dar, die vom Compiler und/oder der CLR interpretiert werden können
    [Table]
    class Person
    {
        [Column(IsPrimaryKey=true)]
        public string Name { get; set; }
        [Column]
        public int Salary { get; set; }
        public Person() {}
        public Person(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }
        public override string ToString()
        {
            return String.Format("{0,-10} {1}",Name,Salary);
        }
    }
}
