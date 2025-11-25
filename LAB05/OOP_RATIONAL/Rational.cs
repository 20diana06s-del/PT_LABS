using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RATIONAL
{
    public class Rational
    {
        public int Numerator {  get; set; }
        private int denominator;
        public int Denominator
        {
            get {  return this.denominator; }
            set
            {
                if (value == 0)
                { throw new DivideByZeroException("Denominator should not be = 0"); }
                this.denominator = value;
            }
        }
    }
}