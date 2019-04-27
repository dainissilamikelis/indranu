using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using indranu7.models;

namespace indranu7.buisinessLogic
{
    public static class formatMetadata
    {

        public static FieldModel[] GetReceiptFields()
        {
            var receiptFields = new FieldModel[1];
            var electroEnergy = new FieldModel();
            electroEnergy.Label = "Elektroenerģija";
            electroEnergy.Type = "text";
            electroEnergy.Unit = "Kwh";
            electroEnergy.Value = "47.99";

            receiptFields[0] = electroEnergy;

            return receiptFields;
        }

        public static ReceiptModel[] GetAssets()
        {
            var assets = new ReceiptModel[1];
            var fields = new FieldModel[1];
            assets[0] = new ReceiptModel();
            var apartmentNumber = new FieldModel();
            apartmentNumber.Label = "Dzīvokļa nummurs";
            apartmentNumber.Type = "text";
            apartmentNumber.Unit = "";
            apartmentNumber.Value = "Dz. 1";

            fields[0] = apartmentNumber;

            assets[0].Label = "Dzīvoklis Nr. 1";
            assets[0].Fields = fields;
            assets[0].Value = 0;

            return assets;
        }


        public static FieldModel[] GetTarifFields()
        {
            var tarifFields = new FieldModel[1];

            var heating = new FieldModel();
            heating.Label = "Elektroenerģija";
            heating.Type = "text";
            heating.Unit = "Kwh";
            heating.Value = "47.99";

            tarifFields[0] = heating;
            return tarifFields;
        }
    }
}
