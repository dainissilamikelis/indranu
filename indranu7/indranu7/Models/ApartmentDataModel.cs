using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace indranu7.Models
{
    public class ApartmenDataModel
    {
        public int ApartmenNo { get; set; }
        public decimal TenantAmount { get; set; }
        public decimal Debt { get; set; }
        public string DebtInfo { get; set; }
        public string ExtraInfo { get; set; }
    }
}
