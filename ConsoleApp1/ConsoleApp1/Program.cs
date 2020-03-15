using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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


            string fileStart = CheckArgument1(args);
            string fileResult = CheckArgument2(args);
            string fileExtension = CheckArgument3(args);
            string fileLogs = "data/łog.txt";

            StreamWriter streamWriter = new StreamWriter(fileLogs);
            FileInfo file = new FileInfo(fileStart);

            List<Student> studentList = new List<Student>();
            Dictionary<string, int> stundetMap  = new Dictionary<string, int>();

            try
            {
                using (StreamReader stream = new StreamReader(file.OpenRead()))
                {
                    string line = "";
                    while ((line = stream.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        string[] student = line.Split(",");
                        Console.WriteLine(line);

                        if (checkData(student))
                        {
                            var kierunek = new Kierunek
                            {
                                nazwa = student[2],
                                tryb = student[3],
                            };
                            Student student1 = new Student
                            {
                                Imie = student[0],
                                Nazwisko = student[1],
                                Index = int.Parse(student[4]),
                                Kierunek = kierunek,
                                DataUrodzenia = student[5],
                                Email = student[6],
                                Ojciec = student[8],
                                Matka = student[7]
                            };
                            studentList.Add(student1);

                            if (stundetMap.ContainsKey(kierunek.nazwa))
                            {
                                stundetMap[kierunek.nazwa]++;
                            }
                            else
                            {
                                stundetMap.Add(kierunek.nazwa,1);
                            }
                        }
                        else
                        {
                            streamWriter.WriteLine("Zle podane dane : " + line);
                        }
    


                }
                }
            }catch(FileNotFoundException )
            {
                Console.WriteLine("Plik nazwa nie istnieje");
                streamWriter.WriteLine("Plik nazwa nie istnieje");
                return;
            }catch(ArgumentException )
            {
                Console.WriteLine("Podana ścieżka jest niepoprawna");
                streamWriter.WriteLine("Podana ścieżka jest niepoprawna");
                return;
            }catch(Exception e3)
            {
                Console.WriteLine(e3.Message);
                streamWriter.WriteLine(e3.Message);
                return;
            }

            streamWriter.Flush();
            streamWriter.Close();


            ActiveStudies activeSt = new ActiveStudies()
            {
                activeStudies = new List<ActiveStudie>()
            };

            foreach (KeyValuePair<string, int> entry in stundetMap)
            {
                activeSt.activeStudies.Add(new ActiveStudie {name= entry.Key,number= entry.Value });
            }

            Students students = new Students
            {
                Student = studentList.Distinct(new EqualityComp()).ToList<Student>()
            };

            Uczelnia uczelnia = new Uczelnia
            {
                data = "14.03.2020",
                autor = "Alvan Maksym",
                student = students,
                activeStudies = activeSt,
            };


            FileStream writer = new FileStream(fileExtension, FileMode.Create);
        
            XmlSerializer serializer = new XmlSerializer(typeof(Uczelnia));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            serializer.Serialize(writer, uczelnia, namespaces);





        }
        public static  string CheckArgument1(string[] args)
        {
            if (args.Length == 0 || args[0].Equals(""))
            {
                return "Data/dane.csv";
            }
            else
            {
                return  args[0];
            }
        }
        public static string CheckArgument2(string[] args)
        {
            if (args.Length < 2 || args[1].Equals(""))
            {
                return "result.xml";
            }
            else
            {
              return args[1];
            }

        }
        public static string CheckArgument3(string[] args)
        {
            return "data.xml";
        }
        public static bool checkData(string[] data)
        {
            if(data.Length == 9)
            {
                for (int i =0; i < data.Length; i++){
                    if (data[i].Equals(""))
                        return false;        
                }
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
