using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class KnowledgeBase
    {
        public List<Symptom> Symptom { get; set; }
        public List<Cancer> Cancers { get; set; }

        public KnowledgeBase()
        {
            Cancers = new List<Cancer>();
            Symptom = new List<Symptom>();
            LoadData();
        }

        public void AddData(String cancer, String symptoms, String treatments)
        {
            cancer = "Cancer: " + cancer;
            symptoms = "Symptoms: " + Regex.Replace(symptoms, " *, *", "|"); // remove spaces before and after commas and replace commas with |
            treatments = "Treatments: " + Regex.Replace(treatments, " *, *", "|");

            using (StreamWriter sw = new StreamWriter("C:/Users/winst/Documents/Git/ExpertProject1/ConsoleApp1/data.txt", true))
            {
                sw.WriteLine(cancer);
                sw.WriteLine(symptoms);
                sw.WriteLine(treatments + "\n");
                sw.Close();
            }
        }

        public void LoadData()
        {
            StreamReader sr = new StreamReader("C:/Users/winst/Documents/Git/ExpertProject1/ConsoleApp1/data.txt");
            String currentLine = sr.ReadLine();
            String split;
            String result;

            string[] symptoms;
            string[] treatments;

            Cancer c = new Cancer();

            while (!sr.EndOfStream)
            {
                if (currentLine.Contains("Cancer:"))
                {
                    split = "Cancer: ";
                    result = currentLine.Substring(currentLine.IndexOf(split) + split.Length);
                    c.SetResult(new Statement(result, "equals", "yes"));
                }
                else if (currentLine.Contains("Symptoms:"))
                {
                    split = "Symptoms: ";   
                    result = currentLine.Substring(currentLine.IndexOf(split) + split.Length);
                    symptoms = result.Split('|');

                    for (int i = 0; i < symptoms.Length; i++)
                    {
                        c.AddCondition(new Statement(symptoms[i], "equals", "yes"));
                    }
                }
                else if (currentLine.Contains("Treatments:"))
                {
                    split = "Treatment: ";
                    result = currentLine.Substring(currentLine.IndexOf(split) + split.Length);
                    treatments = result.Split('|');

                    for (int i = 0; i < treatments.Length; i++)
                    {
                        c.AddTreatment(new Statement(treatments[i], "equals", "yes"));
                    }
                }
                else
                {
                    Cancers.Add(c);
                    c = new Cancer();
                }

                currentLine = sr.ReadLine(); // next line
            }

            sr.Close();
        }
    }
}



