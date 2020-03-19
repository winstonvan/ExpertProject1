using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class Cancer
    {
        
        [XmlAttribute]
        public string Name { get; set; }
        
        public Sequencing Symptoms { get; set; }

        public Cancer()
        {
            Symptoms = new Sequencing(0);
        }
    }
}
