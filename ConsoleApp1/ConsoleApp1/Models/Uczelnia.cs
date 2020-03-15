using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1.Models
{
    public class Uczelnia
    {
        [XmlAttribute(attributeName: "createdAt")]
        public String data { get; set; }

        [XmlAttribute(attributeName: "author")]
        public string autor { get; set; }

        [XmlElement(elementName: "students")]
        public Students student { get; set; }

        [XmlElement(elementName: "activeStudies")]
        public ActiveStudies activeStudies { get; set; }
    }
}
