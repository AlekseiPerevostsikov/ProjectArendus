using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_WPF
{
    class Tax
    {
        private double w;
        private double s;


        public Tax(double Warehousetax, double Statetax)
        {
            this.w = Warehousetax;
            this.s = Statetax;
        }

        public Tax()
        {

        }

        public double Warehousetax { get => w; set => w = value; }
        public double Statetax { get => s; set => s = value; }

    }
}
