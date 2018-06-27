using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.Controller.Modules.DataShowerModule
{
    public static class DataUtils
    {
        public static string NumberFormat(int number)
        {
            if (number / 1000 >= 1) return $"{Math.Round(number / 1000f, 1)}K";

            return number.ToString();
        }
    }
}
