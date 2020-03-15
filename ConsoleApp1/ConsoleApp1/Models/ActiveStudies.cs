using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1.Models
{
    public class ActiveStudies
    {
        [XmlElement(elementName: "studies")]
        public List<ActiveStudie> activeStudies { get; set; }
    }
}
