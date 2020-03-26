using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class InferenceEngine
    {
        public KnowledgeBase kb;

        public InferenceEngine()
        {
            kb = new KnowledgeBase();
        }

        public void InferCancers(List<Symptom> symptoms) // forward chaining
        {
            // find which facts corresponds to a rule and create a temp list of matching facts
            List<Cancer> temp = new List<Cancer>();

            for (int i = 0; i < symptoms.Count; i++)
            {
                for (int j = 0; j < kb.Symptoms.Count; j++)
                {
                    
                }
            }            
        }

        public List<Cancer> FindMatch()
        {
            List<Cancer> temp = new List<Cancer>();

            for (int i = 0; i < kb.Cancers.Count(); i++)
            {

            }
            return 
        }
    }
}
