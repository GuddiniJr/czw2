using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1.Models
{
    public class Kierunek
    {
        [XmlElement(elementName: "name")]
        public String nazwa { set; get; }

        [XmlElement(elementName: "mode")]
        public String tryb { set; get; }
    }
}
