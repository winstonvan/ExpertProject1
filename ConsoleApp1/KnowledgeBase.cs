using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    // 
     // The knowledgebase:
     //
    
    public class KnowledgeBase
    {
        // A list of all the ingredients (facts):
        public List<Symptom> Symptom { get; set; }
        // A list of all the recipes (rules):
        public List<Cancer> Cancers { get; set; }

        public KnowledgeBase()
        {
            Cancers = new List<Cancer>();
            Symptom = new List<Symptom>();
        }
        //
        // Add a new ingredient to the ingredients list:
        //
        public Symptom AddSymptom(string name)
        {
            Symptom n = new Symptom(new Statement());
            Symptom.Add(n);
            return n;
        }

        //
        // Returns the specified ingredient, or null:
        //
        public Symptom GetSymptom(Statement name)
        {
            IEnumerable<Symptom> i = from Symptom ii in Symptom where ii.symptom == name select ii;
            
                return i.FirstOrDefault();
        }

        //
        // Builds a Recipe called "Name" with the specified ingredients:
        //
        
        
        //
        // Serialize this class to an XML file:
        //
        public void Save(string FileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(KnowledgeBase));
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(FileName))
            {
                xs.Serialize(sw, this);
                sw.Flush();
                sw.Close();
            }
        }
        //
        // Load a knowledgebase XML:
        //
        public static KnowledgeBase Load(string FileName)
        {
            KnowledgeBase kb = null;
            using (System.IO.FileStream stream = System.IO.File.OpenRead(FileName))
            {
                XmlSerializer xs = new XmlSerializer(typeof(KnowledgeBase));
                kb = xs.Deserialize(stream) as KnowledgeBase;
            }
            return kb;
        }
    }
}



