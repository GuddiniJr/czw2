using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1.Models
{
    public class ActiveStudie
    {
        [XmlAttribute(attributeName: "name")]
        public String name { get; set; }

        [XmlAttribute(attributeName: "numberOfStudents")]
        public int number { get; set; }
    }
}
