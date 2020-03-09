using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //arrlist =  list
            //set  = hashset
            //map = dictionary


            string file = @"Data\dane.csv";
            FileInfo f = new FileInfo(file);
            using (var stream = new StreamReader(f.OpenRead()))
            {

                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    string[] studentWiersz = line.Split(',');

                    Console.WriteLine(line);
                }
            }//Dispose automatycznie
            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("uczelnia"));
            var list = new List<Student>();
            var st = new Student
            {
                Imie = "Jan",
                Nazwisko = "Kowalski",
                Email = "kowalski@wp.pl"
            };
            list.Add(st);
            serializer.Serialize(writer, list);


            //XML
            // stream.Dispose(); // using zamiast dispose auto korzysta dispose 

        }
    }
}
