using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean LoopIfTrue = true;

            while (LoopIfTrue == true)
            {
                InferenceEngine IE = new InferenceEngine();

                string[] symptomsList;
                var symptoms = "";
                var treatments = "";
                var input = "";
                var cancer = "";
                Boolean cancerMatch = false;

                Console.WriteLine("*********************************************************************************");
                Console.WriteLine("************************ Cancer Diagnostic Expert System ************************");
                Console.WriteLine("*********************************************************************************");

                Console.WriteLine("\nPlease enter a list of symptoms you're experiencing (separated by commas):");
                input = Console.ReadLine(); // get user input
                input = Regex.Replace(input, " *, *", ","); // remove spaces before and after commas

                // split input by comma delimiter
                symptomsList = input.Split(',');

                // add symptoms to KB
                for (int i = 0; i < symptomsList.Length; i++)
                {
                    IE.AddSymptom(new Symptom(new Statement(symptomsList[i], "equals", "yes")));
                }

                Console.WriteLine("\nSymptoms: ");
                // display symptoms to user
                for (int i = 0; i < IE.kb.Symptom.Count; i++)
                {
                    String symptom = IE.kb.Symptom[i].symptom.GetVariable();
                    Console.WriteLine("Symptom #" + (i + 1) + ": " + (symptom.First().ToString().ToUpper() + symptom.Substring(1)));
                }

                // INFER
                List<Cancer> output = IE.InferCancers(IE.kb.Symptom);

                if (output.Count > 0)
                {
                    cancerMatch = true;

                    Console.WriteLine("\nCancer types matched: ");
                    for (int i = 0; i < output.Count; i++)
                    {
                        Console.WriteLine("Cancer #" + (i + 1) + ": " + output[i].result.GetVariable());
                    }
                }
                else
                {
                    Console.WriteLine("\nNo matches were found.");
                    Console.WriteLine("Would you like to try again?");
                    input = Console.ReadLine().Trim().ToLower();

                    if (input == "yes" || input == "y")
                    {
                        Console.Clear();
                        // loop
                    }
                    else if (input == "no" || input == "n")
                    {
                        LoopIfTrue = false;
                    }
                }

                if (cancerMatch == true)
                {
                    // TREATMENTS
                    Console.WriteLine("\n*********************************************************************************");
                    Console.WriteLine("Select a cancer by number to view the treatments available: ");

                    input = Console.ReadLine().Trim();

                    while (Int32.Parse(input) > output.Count || Int32.Parse(input) < output.Count)
                    {
                        input = Console.ReadLine().Trim();
                    }

                    Console.WriteLine("\nCancer type: " + output[Convert.ToInt32(input) - 1].result.GetVariable());
                    Console.WriteLine("\nTreatments available:");

                    for (int i = 0; i < output[Convert.ToInt32(input) - 1].treatments.Count; i++)
                    {
                        Console.WriteLine("Treatment #" + (i + 1) + ": " + output[Convert.ToInt32(input) - 1].treatments[i].GetVariable());
                    }

                    // HELPFUL?
                    Console.WriteLine("\n*********************************************************************************");
                    Console.WriteLine("Was this information helpful?");
                    input = Console.ReadLine().Trim().ToLower();

                    while ((input != "yes" && input != "no") && (input != "y" && input != "n"))
                    {
                        input = Console.ReadLine().Trim().ToLower();
                    }

                    // ENTER NEW CANCER
                    if (input == "no" || input == "n")
                    {
                        Console.WriteLine("\nWould you like to enter a new cancer?");
                        input = Console.ReadLine().Trim().ToLower();

                        if (input == "yes" || input == "y")
                        {
                            Console.WriteLine("\nEnter the cancer name: ");
                            input = Console.ReadLine().Trim().ToLower();
                            cancer = input;

                            Console.WriteLine("\nEnter the symptoms separated by commas: ");
                            input = Console.ReadLine().Trim().ToLower();
                            symptoms = input;

                            Console.WriteLine("\nEnter the available treatments separated by commas: ");
                            input = Console.ReadLine().Trim().ToLower();
                            treatments = input;

                            IE.kb.AddData(cancer, symptoms, treatments);

                            Console.WriteLine("\nNew cancer has been added to the system.");
                        }
                    }

                    // RESTART?
                    Console.WriteLine("\n*********************************************************************************");
                    Console.WriteLine("Would you like to restart?");
                    input = Console.ReadLine().Trim().ToLower();

                    if (input == "yes" || input == "y")
                    {
                        Console.Clear();
                        // loop
                    }
                    else
                    {
                        LoopIfTrue = false;
                    }
                }
            }
        }
    }
}
