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
		public String cancerName;
		public List<Statement> conditions;
		public Statement result;

		public Cancer(String cancerName)
		{
			this.cancerName = cancerName;
			this.conditions = new List<Statement>();
		}

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
	}
}
