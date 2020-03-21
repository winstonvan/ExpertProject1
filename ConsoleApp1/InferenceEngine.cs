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
        private Fact fact = new Fact();

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
        public void AddFact(Statement fact)
        {
            this.fact.AddFact(fact);
        }

        public void DeleteFact(int i)
        {
            fact.RemoveFact(i);
        }

        public void DeleteAtFacts()
        {
            fact.RemoveAllFacts();
        }

        public List<Statement> GetFacts()
        {
            return this.fact.GetFacts();
        }

        public void ForwardChaining()
        {
            // find which facts corresponds to a rule and create a temp list of matching facts
            List<Rule> temp = new List<Rule>();

            for (int i = 0; i < rules.Count; i++)
            {
                if (rules[i].MatchRuleWithFact(fact) == true)
                {
                    temp.Add(rules[i]);
                }
            }

            //

            
        }
    }
}
