﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class Symptom
    {

        [XmlAttribute]
        public string Name { get; set; }
        public Sequencing Signature { get; set; }

        public Symptom() { }

        public override string ToString()
        {
            return this.Name + " (" + this.Signature.ToString() + ")";
        }
    }
}

