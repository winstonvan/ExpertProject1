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

        public void AddCancer(Cancer cancer)
        {
            kb.Cancers.Add(cancer);
        }

        public void AddSymptom(Symptom symptom)
        {
            kb.Symptom.Add(symptom);
        }

        public void InferCancers(List<Symptom> symptoms) // forward chaining
        {
            // set score to 0
            for (int i = 0; i < kb.Cancers.Count; i++)
            {
                kb.Cancers[i].SetTotal(0);
            }

            // find which facts corresponds to a rule and create a temp list of rules that match
            List<Cancer> temp = new List<Cancer>();

            for (int i = 0; i < symptoms.Count; i++)
            {
                var match = FindMatch(symptoms[i]);

                if (match == null)
                {
                    // no match, continue to next iteration
                }
                else
                {
                    temp = temp.Union(match).ToList();
                }
            }

            temp.Sort((x, y) => y.total - x.total);


            Console.WriteLine("\nCancer types matched: ");
            for (int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine("Cancer " + (i + 1) + ": " + temp[i].result.GetVariable());
            }
        }

        public List<Cancer> FindMatch(Symptom s)
        {
            List<Cancer> temp = new List<Cancer>();

            for (int i = 0; i < kb.Cancers.Count(); i++)
            {
                for (int j = 0; j < kb.Cancers[i].conditions.Count; j++)
                {
                    if (kb.Cancers[i].conditions[j].GetVariable().Trim().ToLower().Equals(s.symptom.GetVariable().Trim().ToLower()))
                    {
                        // matches, add to temp list
                        kb.Cancers[i].SetTotal(10 - (j + 1));
                        temp.Add(kb.Cancers[i]);
                    }
                    else
                    {
                        // does not match
                    }
                }
            }

            return temp;
        }

        public void PrintCancers()
        {
            for (int i = 0; i < kb.Cancers.Count; i++)
            {
                Console.WriteLine("\nCancer " + (i + 1) + ": ");
                for (int j = 0; j < kb.Cancers[i].conditions.Count; j++)
                {
                    Console.WriteLine("Condition " + (j + 1) + ": " + kb.Cancers[i].conditions[j].GetVariable());
                }
                Console.WriteLine("Cancer type: " + kb.Cancers[i].result.GetVariable());
            }
        }

        public void PrintSymptoms()
        {
            Console.WriteLine("\nSymptoms count: " + kb.Symptom.Count);

            for (int i = 0; i < kb.Symptom.Count; i++)
            {
                Console.WriteLine("Symptom " + (i + 1) + ": " + kb.Symptom[i].symptom.GetVariable() + "");
            }
        }
    }
}
