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

		private List<Statement> conditions;
		private Statement result;

		public Rule(String ruleName)
		{
			this.ruleName = ruleName;
			this.conditions = new List<Statement>();
		}

		// get functions
		public String GetRuleName()
		{
			return ruleName;
		}

		// set functions
		public void AddCondition(Statement condition)
		{
			this.conditions.Add(condition);
		}

		public void SetResult(Statement result) 
		{
			this.result = result;
		}

		public Boolean MatchRuleWithFact(Fact fact)
		{
			for (int i = 0; i < conditions.Count; i++)
			{
				if (fact.FoundMatchingFact(conditions[i]) == true)
				{
					return true;
				}
			}
			return true;
		}

		// print to string
		public String Print()
		{
			String temp = "Rule: " + this.ruleName + "\n";

			for (int i = 0; i < conditions.Count; i++)
			{
				temp += "Condition " + (i + 1) + ": " + this.conditions[i].Print() + "\n";
            }

			temp += "Result: " + this.result.Print() + "\n";
			return temp;
		}
	}
}
