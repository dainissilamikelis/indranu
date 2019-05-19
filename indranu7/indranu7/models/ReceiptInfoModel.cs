using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace indranu7.models
{
    public class ReceiptInfoModel
    {
        public InfoModel[] Info { get; set; }
        public TarifModel[] Tarifs { get; set; }
        public ReceiptModel[] Receipts { get; set; }
    }
}
