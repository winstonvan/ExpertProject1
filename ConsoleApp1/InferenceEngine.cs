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
        private List<Cancer> cancer;
        private List<Symptom> symptom;

        public InferenceEngine()
        {
            cancer = new List<Cancer>();
            symptom = new List<Symptom>();
            kb = new KnowledgeBase();
        }

        // set functions
        public void AddCancer(Cancer cancer)
        {
            this.cancer.Add(cancer);
        }

        // get functions
        public void GetCancers()
        {
            for (int i = 0; i < cancer.Count; i++)
            {
                Console.WriteLine(cancer[i].Print());
            }
        }

        // delete functions
        public void DeleteCancers() 
        {
            this.cancer.Clear();
        }


        public void InferCancers(List<Symptom> symptoms) // forward chaining
        {
            // find which facts corresponds to a rule and create a temp list of matching facts
            List<Cancer> temp = new List<Cancer>();

            for (int i = 0; i < symptoms.Count; i++)
            {
                
            }            
        }
    }
}
