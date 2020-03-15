using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1.Models
{
    public class Student
    {
        [XmlAttribute(attributeName: "index")]
        public int Index { get; set; }
        //prop + tabx2
        [XmlElement(elementName: "fname")]
        public string Imie { get; set; }

        [XmlElement(elementName: "lname")]
        public string Nazwisko { get; set; }

        [XmlElement(elementName: "birthdate")]
        public string DataUrodzenia { get; set; }

        [XmlElement(elementName: "email")]
        public string Email { get; set; }

        [XmlElement(elementName: "mothersName")]
        public string Matka { get; set; }

        [XmlElement(elementName: "fathersName")]
        public string Ojciec { get; set; }

        [XmlElement(elementName: "studies")]
        public Kierunek Kierunek { get; set; }
        
       
    }
}
