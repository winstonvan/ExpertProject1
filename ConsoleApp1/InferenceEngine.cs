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

        public List<Cancer> InferCancers(List<Symptom> symptoms) // forward chaining
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

            // sort by score
            temp.Sort((x, y) => y.total - x.total);

            return temp;
        }

        public List<Cancer> FindMatch(Symptom s)
        {
            List<Cancer> temp = new List<Cancer>();

            for (int i = 0; i < kb.Cancers.Count(); i++)
            {
                for (int j = 0; j < kb.Cancers[i].conditions.Count; j++)
                {
                    String[] source = (kb.Cancers[i].conditions[j].GetVariable().Trim().ToLower()).Split(' ');
                    String[] target = (s.symptom.GetVariable().Trim().ToLower()).Split(' ');
                    
                    for (int k = 0; k < source.Length; k++)
                    {
                        for (int l = 0; l < target.Length; l++)
                        {
                            int distance = LevenshteinDistance(source[k], target[l]);
                            
                            if (distance <= 1)
                            {
                                kb.Cancers[i].SetTotal(10 - (j + 1));
                                temp.Add(kb.Cancers[i]);
                                break;
                            }
                        }
                    }
                }
            }
            return temp;
        }

        public int LevenshteinDistance(string source, string target)
        {
            if (string.IsNullOrEmpty(source))
            {
                if (string.IsNullOrEmpty(target)) return 0;
                return target.Length;
            }
            if (string.IsNullOrEmpty(target)) return source.Length;

            if (source.Length > target.Length)
            {
                var temp = target;
                target = source;
                source = temp;
            }

            var m = target.Length;
            var n = source.Length;
            var distance = new int[2, m + 1];
            // Initialize the distance matrix
            for (var j = 1; j <= m; j++) distance[0, j] = j;

            var currentRow = 0;
            for (var i = 1; i <= n; ++i)
            {
                currentRow = i & 1;
                distance[currentRow, 0] = i;
                var previousRow = currentRow ^ 1;
                for (var j = 1; j <= m; j++)
                {
                    var cost = (target[j - 1] == source[i - 1] ? 0 : 1);
                    distance[currentRow, j] = Math.Min(Math.Min(
                                distance[previousRow, j] + 1,
                                distance[currentRow, j - 1] + 1),
                                distance[previousRow, j - 1] + cost);
                }
            }
            return distance[currentRow, m];
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
                Console.WriteLine("Symptom #" + (i + 1) + ": " + kb.Symptom[i].symptom.GetVariable() + "");
            }
        }
    }
}
