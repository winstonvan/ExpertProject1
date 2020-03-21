using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Fact
    {
        private List<Statement> facts;

        public Fact() {
            facts = new List<Statement>();
        }

        public void AddFact(Statement fact) {
            facts.Add(fact);
        }

        public void RemoveFact(int i)
        {
            facts.RemoveAt(i);
        }

        public void RemoveAllFacts()
        {
            facts.Clear();
        }

        public List<Statement> GetFacts()
        {
            return facts;
        }

        public Boolean FoundMatchingFact(Statement rule)
        {
            for (int i = 0; i < facts.Count; i++)
            {
                if (facts[i].GetVariable().Equals(rule.GetVariable()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
