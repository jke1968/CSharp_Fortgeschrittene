using System;
using System.Data.Linq;
using System.Linq;

namespace _01_07LINQ2SQL
{

    // Anwendungsfall 1 für LINQ : relationale Datenbanken ( flache Struktur )
    class Program
    {
        // connectionstring für die vorinstallierte SQLServer Instanz namens "SQLEXPRESS", Annahme : Database "MyDB" existiert bereits
        // Tabelle "person" wurde folgendermassen erstellt:
        // create table person (name varchar(20) PRIMARY KEY, salary decimal(7,2) );

        static string connectionString = @"Data Source=DESKTOP-CINDRRN\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True;";
        static void FillTable()
        {
            // erzeugt neue connection, wird garbage collected, nicht thread-safe
            DataContext context = new DataContext(connectionString);
            // Annahme : Tabelle Person existiert bereits in MyDB, Abbildung über Attributes in Klasse Person
            Table<Person>  persons = context.GetTable<Person>();
            persons.InsertOnSubmit(new Person("Breitner", 1000));
            persons.InsertOnSubmit(new Person("Vogts", 2000));
            persons.InsertOnSubmit(new Person("Overath", 1000));
            context.SubmitChanges();
            Console.WriteLine("Created " + persons.Count() + " person entries in table person");
            // connection wird hier wieder geschlossen
        }

        static void DeleteTable()
        {
            DataContext context = new DataContext(connectionString);
            context.ExecuteCommand("delete from Person;");
            Console.WriteLine("Deleted all entries from table Person ");
        }

        static Action<Person> printPerson = p => Console.WriteLine(p);
        static void PrepareDB()
        {
            DeleteTable();
            FillTable();
        }
        static void Main(string[] args)
        {
            PrepareDB();
            DataContext context = new DataContext(connectionString);
             //System.Data.Linq.Table implementiert IQueryable ( ein Spezialisierung von IEnumerable<T> ),
             //stellt also eine sequence dar und kann daher 
             //verwendet werden wie bereits bei LINQ2Objects gesehen
             //Hinweis : IQueryable enthält für alle query Operatoren zusätzliche Überladungen,
             //die anstelle von Lambda Expressions sog. Expression Trees als Parameter fordern.
             //Aus diesen Expression Trees generiert der entsprechede LINQ2SQL Provider dann
             //keinen C# Code ( also delegates wie bein LINQ2Objects)
             //sondern die zur jeweiligen DB passenden SQL Statements
            Table<Person> persons = context.GetTable<Person>();
            Console.Write("Alle Personen\n");
            // auch hier lazy evaluation / deferred execution :
            // 1. SQL Statement wird generiert 
            // 2. SQL Statement wird an die DB gesendet
            foreach (Person p in persons) { Console.WriteLine(p); }
            Console.Write("Personen mit Gehalt = 1000\n");
            IQueryable<Person> sequence = 
            persons
                .Where(p => p.Salary == 1000)
                .OrderByDescending(p => p.Name);
            // neues SQL Statement, s.o.
            foreach (Person p in sequence) { Console.WriteLine(p); }
            Console.WriteLine("***");
            // Alternative mit LINQ Query Expression / Comprehension Syntax : 
            sequence =  
                from p in persons 
                where p.Salary == 1000 
                orderby p.Name descending 
                select p;
            // neues SQL Statement, s.o.
            foreach (Person p in sequence) { Console.WriteLine(p); }
        }
    }
}
