using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Statement
    {
        private String variable = ""; // name: car
        private String op = ""; // operator: equals, notEquals, negation, lessThan, greaterThan 
        private String value = ""; // numWheels: 4
                                   // Fact: car = numWheels(4)

        // constructors
        public Statement() { }

        public Statement(String variable, String op, String value)
        {
            this.variable = variable;
            this.op = op;
            this.value = value;
        }

        // get functions
        public String GetVariable()
        {
            return this.variable;
        }
        public String GetValue()
        {
            return this.value;
        }
        public String GetOperator()
        {
            return this.op;
        }

        // set functions
        public void SetVariable(String variable)
        {
            this.variable = variable;
        }
        public void SetValue(String value)
        {
            this.value = value;
        }
        public void SetOperator(String op)
        {
            this.op = op;
        }

        // print to string
        public String Print()
        {
            return this.variable + " " + this.op + " " + this.value;
        }
    }
}
