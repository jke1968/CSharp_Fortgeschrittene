namespace Uebung_Delegates
{
    public class Person
    {

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    };


    internal class Uebung02A
    {

        delegate String ProcessPerson(Person p);

        static List<Person> persons = new List<Person>()
        {
            new Person(100,"Peter"),
            new Person(101,"Paul"),
            new Person(102,"Mary")
        };
        static void ProcessPersons(ProcessPerson process)
        {
            foreach (var person in persons)
            {
                Console.WriteLine(process(person));
            }
        }

        static String GetName(Person person)
        {
            return person.Name;
        }
        static String GetId(Person person)
        {
            return person.Id.ToString();
        }
        static void Main(string[] args)
        {
            ProcessPersons(GetName);
            ProcessPersons(GetId);
        }
    }
}
