using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Sequencing
    {
        public long Bits { get; set; }

        public Sequencing() { }

        public Sequencing (long Bits)
        {
            this.Bits = Bits;
        }

        public static Sequencing operator +(Sequencing a, Sequencing b) => new Sequencing(a.Bits | b.Bits);
        public static Sequencing operator -(Sequencing a, Sequencing b) => new Sequencing(a.Bits & b.Bits);


        public override string ToString()
        {
            return Bits.ToString();
        }
    }
}
