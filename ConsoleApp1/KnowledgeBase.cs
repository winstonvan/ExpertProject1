using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
        
        public class KnowledgeBase
        {
            
            public List<Symptom> Symptoms { get; set; }
           
            public List<Cancer> Cancers { get; set; }

            public KnowledgeBase()
            {
                Symptoms = new List<Symptom>();
                Cancers = new List<Cancer>();
            }
           

          
            public Cancer newCancer(string Name, params string[] Ing)
            {
                Cancer r = new Cancer();

                IEnumerable<Symptom> ingIterator = from Symptom i in Symptoms where Ing.Contains(i.Name) select i;
                foreach (Symptom i in ingIterator) r.Symptoms += i.Assignment;
                r.Name = Name;

                return r;
            }
           
        }
    }


