using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            InferenceEngine IE = new InferenceEngine();
            Console.WriteLine("Test\n");

            Rule rule1 = new Rule("Bicycle");
            rule1.AddCondition(new Fact("motor", "equals", "no"));
            rule1.AddCondition(new Fact("numWheels", "equals", "2"));
            rule1.SetResult(new Fact("vehicle", "equals", "bicycle"));
            IE.AddRule(rule1);

            rule1.Print();
            Console.ReadLine();
        }
    }
}
