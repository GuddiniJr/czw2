using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1.Models
{
    public class Students
    {

        [XmlElement(elementName: "student")]
        public List<Student> Student { get; set; }
    }
}

