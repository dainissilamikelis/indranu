using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using indranu7.models;

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
                return decimalValue;
            }

            return defaulValue;
        }

        public FieldModel crateField(string Label, string Unit, string Name, string Value = "", string Type = "number")
        {
            var newField = new FieldModel();
            newField.Label = Label;
            newField.Type = Type;
            newField.Unit = Unit;
            newField.Name = Name;
            newField.Value = Value;

            return newField;
        }
    }
}
