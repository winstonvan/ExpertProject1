using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class Cancer
	{
		private String cancerName;

		private List<Statement> conditions;
		private Statement result;

		public Cancer(String cancerName)
		{
			this.cancerName = cancerName;
			this.conditions = new List<Statement>();
		}

		// get functions
		public String GetCancerName()
		{
			return cancerName;
		}

		public List<Statement> GetConditions()
		{
			return this.conditions;
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

		public Boolean MatchingCancerWithSymptom(Symptom symptom)
		{
			for (int i = 0; i < conditions.Count; i++)
			{
				if (symptom.FoundMatchingSymptom(conditions[i]) == true)
				{
					return true;
				}
			}
			return true;
		}

		// print to string
		public String Print()
		{
			String temp = "Rule: " + this.cancerName + "\n";

			for (int i = 0; i < conditions.Count; i++)
			{
				temp += "Condition " + (i + 1) + ": " + this.conditions[i].Print() + "\n";
			}

			temp += "Result: " + this.result.Print() + "\n";
			return temp;
		}
	}
}
