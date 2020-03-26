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

            Cancer cancer = new Cancer("Liver");
            cancer.AddCondition(new Statement("motor", "equals", "no"));
            cancer.AddCondition(new Statement("numWheels", "equals", "2"));
            cancer.SetResult(new Statement("vehicle", "equals", "bicycle"));
            IE.AddCancer(cancer);

        }
    }
}
