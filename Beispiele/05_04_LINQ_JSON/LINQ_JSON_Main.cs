using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PersonParser
{
    public class Person
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }

    public class JSON_LINQMain
    {
        public static void Main(string[] args)
        {
            try
            {
                string json = File.ReadAllText("persons.json");

                List<Person>? persons = JsonSerializer.Deserialize<List<Person>>(json);
                persons?.Where(p => p.Id > 100)
                        .ToList()
                        .ForEach(p => Console.WriteLine("{0}", p.Name))
                        ;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
