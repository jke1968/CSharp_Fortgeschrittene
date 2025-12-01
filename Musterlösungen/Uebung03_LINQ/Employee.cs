namespace Uebung12_LINQ
{
    internal class Employee
    {
        public string Name { get; }
        public decimal Salary { get; }
        public string Department { get;  }
        public Employee(string name, decimal salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }
        public override string ToString()
        {
            return Name + " " + Salary + " " + Department;
        }
    }
}