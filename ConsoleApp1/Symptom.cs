using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Symptom
    {
        private Statement symptom;

        public Symptom(Statement symptom)
        { 
            this.symptom = symptom;
        }

        public Statement GetSymptom()
        {
            return this.symptom;
        }
    }
}
