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


            IE.PrintSymptoms();
            IE.PrintCancers();

            IE.InferCancers(IE.kb.Symptom);
            Console.ReadLine();

        }
    }
}
