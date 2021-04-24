using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Exercise_2
{
    class MainWIndowViewModel
    {
        public Number MyNumber { get; set; }

        public MainWIndowViewModel()
        {
            MyNumber = new Number() { NumberValue = 50 };
        }
    }
}
