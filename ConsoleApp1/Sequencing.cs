using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Sequencing
    {
        public int Id { get; set; }

        public Sequencing() { }

        public Sequencing (int Id)
        {
            this.Id = Id;
        }

        public static Sequencing operator +(Sequencing x, Sequencing y)
        {
            return new Sequencing(x.Id | y.Id);
        }

        public static Sequencing operator -(Sequencing x, Sequencing y)
        {
            return new Sequencing(x.Id & y.Id);
        }


        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
