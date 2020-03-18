using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class Rule
	{
		private String ruleName;

		private List<Fact> facts;
		private Fact result;

		public Rule(String ruleName)
		{
			this.ruleName = ruleName;
			this.facts = new List<Fact>();
		}

		// get functions
		public String GetRuleName()
		{
			return ruleName;
		}

		// set functions
		public void AddCondition(Fact condition)
		{
			this.facts.Add(condition);
		}

		public void SetResult(Fact result)
		{
			this.result = result;
		}

		// print to string
		public String Print()
		{
			String temp = "Rule: " + this.ruleName + "\n";

			for (int i = 0; i < facts.Count; i++)
			{
				temp += "Condition " + (i + 1) + ": " + this.facts[i].Print() + "\n";
            }

			temp += "Result: " + this.result.Print() + "\n";
			return temp;
		}
	}
}
