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
            Console.WriteLine("Test\n");
                
            InferenceEngine IE = new InferenceEngine();

            string[] symptoms = new string[] {
                "Jaundice"
            };

            for (int i = 0; i < symptoms.Length; i++)
            {
                IE.AddSymptom(new Symptom(new Statement(symptoms[i], "equals", "yes")));
            }

            Cancer cancer = new Cancer("Pancreatic");
            cancer.AddCondition(new Statement("Weight loss", "equals", "yes"));
            cancer.AddCondition(new Statement("Jaundice ", "equals", "yes"));
            cancer.SetResult(new Statement("Pancreatic", "equals", "yes"));
            IE.AddCancer(cancer);

            Cancer cancer2 = new Cancer("Liver");
            cancer2.AddCondition(new Statement("Jaundice", "equals", "yes"));
            cancer2.AddCondition(new Statement("Lump", "equals", "yes"));
            cancer2.AddCondition(new Statement("Nausea", "equals", "yes"));
            cancer2.SetResult(new Statement("Liver", "equals", "yes"));
            IE.AddCancer(cancer2);

            Cancer cancer3 = new Cancer("Colon");
            cancer3.AddCondition(new Statement("Vomiting", "equals", "yes"));
            cancer3.SetResult(new Statement("Colon", "equals", "yes"));
            IE.AddCancer(cancer3);

            IE.PrintSymptoms();
            IE.PrintCancers();

            IE.InferCancers(IE.kb.Symptom);
            Console.ReadLine();

        }
    }
}
