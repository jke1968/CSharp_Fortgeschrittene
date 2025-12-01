using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_04LambdaExpressions
{
    class Main04_04
    {

        static List<Person> persons = new List<Person>
        {
            new Person ( "Breitner",3000 ),
            new Person ( "Vogts", 1000 ),
            new Person ( "Overath", 1000 )
        };

        static void sortBySalaryUsingLambdaExpression()
        {
            // delegate instance:
            persons.Sort(delegate (Person p1, Person p2){return p1.Salary.CompareTo(p2.Salary);});
            // use a lambda expression of type IComparer<Person> instead of a delegate instance as an anonymous function object 
            persons.Sort( (x,y) => x.Salary.CompareTo(y.Salary)  );
        }

        static List<Person> findUsingLambdaExpression()
        {
            // use a lambda expression of type Predicate  
            return persons.FindAll( p => p.Salary == 1000);
        }

        static void Main(string[] args)
        {
            sortBySalaryUsingLambdaExpression();
            Console.WriteLine("sorted persons ");
            // use a lambda expression of type Action
            persons.ForEach( p => Console.WriteLine(p) );
            Console.WriteLine("All persons with salary == 1000");
            findUsingLambdaExpression().ForEach(p => Console.WriteLine(p));
        }
    }
}
