using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class InferenceEngine
    {
        private List<Rule> rules;
        private List<Fact> facts;

        public InferenceEngine()
        {
            rules = new List<Rule>();

        }

        //****** RULE FUNCTIONS
        public void AddRule(Rule rule)
        {
            rules.Add(rule);
        }

        public void DeleteRule(int i) 
        {
            rules.RemoveAt(i);
        }

        public void DeleteAllRules() 
        {
            rules.Clear();
        }

        public void GetRules()
        {
            for (int i = 0; i < rules.Count; i++)
            {
                Console.WriteLine(rules[i].Print());
            }   
        }

        //****** FACT FUNCTIONS
        public void AddFact(String variable, String op, String value)
        {
            facts.Add(new Fact(variable, op, value));
        }

        public List<Fact> GetFacts()
        {
            return facts;
        }
    }
}
