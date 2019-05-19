using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace indranu7.models
{
    public class ReceiptModel
    {
        public string Label { get; set; }
        public string Id { get; set; }
        public int Value { get; set; }
        public AmountCostForm Receipt { get; set; }
        public FieldModel[] Payer { get; set; }
        public FieldModel[] Receiver { get; set; }
        public FieldModel[] Signatures { get; set; }
    }
}
