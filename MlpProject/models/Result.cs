using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlpProject.models
{
    public class Result
    {
        public double val1 { get; set; }
        public double val2 { get; set; }
        public double accuracy { get; set; }
        public Result(double _val1, double _val2, double acc)
        {
            val1 = _val1;
            val2 = _val2;
            accuracy = acc;
        }
    }

}
