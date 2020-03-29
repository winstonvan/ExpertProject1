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
        public int total;

        public Cancer()
        {
            cancerName = "";
            this.conditions = new List<Statement>();
            this.score = new List<int>();
            this.total = 0;
        }

        public Cancer(String cancerName)
        {
            this.cancerName = cancerName;
            this.conditions = new List<Statement>();
            this.score = new List<int>();
            this.total = 0;
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

        public void SetTotal(int total)
        {
            this.total += total;
            Console.WriteLine(total);
        }

        public void UpdateScore()
        {
            // get current length of cancer conditions
            int count = 10;

            // reset list

            this.score.Clear();

            // update list values
            for (int i = 0; i < this.conditions.Count; i++)
            {
                this.score.Add(count);
                count--;
            }
        }
    }
}
