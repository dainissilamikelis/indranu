using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace indranu7.models
{
    public class ReceiptModel
    {
        public string Label { get; set; }
        public FieldModel[] Fields { get; set; }
        public int Value { get; set; }
    }
}
