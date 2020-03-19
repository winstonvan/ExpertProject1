using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class Symptom
    {

        
        public string Name { get; set; }
        public Sequencing Assignment { get; set; }

        public Symptom() { }

        public override string ToString()
        {
            return this.Name + " (" + this.Assignment.ToString() + ")";
        }
    }
}

