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
		public List<int> score;

		public Cancer()
		{
			cancerName = "";
			this.conditions = new List<Statement>();
			this.score = new List<int>();
		}

		public Cancer(String cancerName)
		{
			this.cancerName = cancerName;
			this.conditions = new List<Statement>();
		}

		public void AddCondition(Statement condition)
		{
			this.conditions.Add(condition);
			this.UpdateScore();
		}

		public void SetResult(Statement result)
		{
			this.result = result;
		}

		public void UpdateScore()
		{
			// get current length of cancer conditions
			int count = this.conditions.Count;

			// reset list
			this.score.Clear();

			// update list values
			for (int i = 0; i < count; i++)
			{
				this.score.Add(count);
				count--;
			}
		}
	}
}
