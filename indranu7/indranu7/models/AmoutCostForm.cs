using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace indranu7.models
{
    public class AmoutCostForm
    {
        public FieldModel[] Fields { get; set; }
        public FieldModel[] CostFields { get; set; }
        public FieldModel[] AdditionalInformation { get; set; }
        public FieldModel[] ClosingInformation { get; set; }
    }
}
