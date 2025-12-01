using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_03DelegatesAsParameters
{
    class SalaryComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Salary.CompareTo(y.Salary);
        }
    }
}
