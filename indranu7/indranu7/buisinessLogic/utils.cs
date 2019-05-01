using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace indranu7.buisinessLogic
{
    public class utils
    {

        public decimal formatValueToDecimal(string value)
        {
            decimal defaulValue = 0.00M;
            if (value != string.Empty)
            {
                var decimalValue = Convert.ToDecimal(value);
                return Math.Round(decimalValue, 2);
            }

            return defaulValue;
        }
    }
}
