using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Person[] persons = new Person[]
            {
                new Person { Name = "Alexey", Age = 33 },
                new Person { Name = "Ivan", Age = 38 },
                new Person { Name = "Andrey", Age = 26 },
                new Person { Name = "Alexander", Age = 27 },
                new Person { Name = "Igor", Age = 30 },
                new Person { Name = "Pavel", Age = 35 },
                new Person { Name = "Konstantin", Age = 25 },
            };

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "persons.xml");

            MyXmlSerializer serializer = new MyXmlSerializer();
            string contents = serializer.Serialize(persons);
            File.WriteAllText(filePath, contents);
            Debug.WriteLine("Serialized:");
            Debug.WriteLine(contents);

            Debug.WriteLine("\r\nDeserialized:");

            List<Person> deserializedPersons = new List<Person>();
            string fileData = File.ReadAllText(filePath);
            foreach (var person in new MyStreamReader<Person>(fileData, serializer))
            {
                if (person is Person p)
                    deserializedPersons.Add(p);
            }
            foreach (var item in deserializedPersons)
            {
                Debug.WriteLine($"Name - {item.Name}, Age - {item.Age}");
            }

            Debug.WriteLine("\r\nSorted:");

            IAlgorithm<Person> algorithm = new PersonAlgorithms();
            foreach (var item in algorithm.Sort<Person>(deserializedPersons))
            {
                Debug.WriteLine($"Name - {item.Name}, Age - {item.Age}");
            }
        }
    }
}
