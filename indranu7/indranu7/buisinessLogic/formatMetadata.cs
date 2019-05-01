using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using indranu7.models;

namespace indranu7.buisinessLogic
{
    public static class formatMetadata
    {
        enum Types
        {
            month,
            number,
            text,
            textArea
        }

        public static FieldModel[] GetReceiptFields()
        {
            var receiptFields = new FieldModel[10];
            var utils = new utils();
            var today = DateTime.Today;

            Console.WriteLine(Types.month.ToString());
            receiptFields[0] = utils.crateField("Mēnesis", "kWh", "Month", "Jan-2018", "month");
            receiptFields[1] = utils.crateField("Elektroenerģija", "kWh", "EletricityAmount");
            receiptFields[2] = utils.crateField("Summa", "EUR", "EletricityCost");
            receiptFields[3] = utils.crateField("Aukstais ūdens", "m3", "ColdWaterAmount");
            receiptFields[4] = utils.crateField("Summa", "EUR", "ColdWaterCost");
            receiptFields[5] = utils.crateField("Apkure", "MWh", "HeatAmount");
            receiptFields[6] = utils.crateField("Maksa", "EUR", "HeatCost");
            receiptFields[7] = utils.crateField("Siltais ūdens", "m3", "HotWaterAmount");
            receiptFields[8] = utils.crateField("Atkritumu izmaksa", "EUR", "WasteCost");
            receiptFields[9] = utils.crateField("Nodoklis", "Eur", "TaxCost");
            receiptFields[10] = utils.crateField("Dz.1", "īrnieki", "1Tenats");

            return receiptFields;
        }

        public static ReceiptModel[] GetAssets()
        {
            var assets = new ReceiptModel[1];
            var fields = new FieldModel[1];
            assets[0] = new ReceiptModel();
            var apartmentNumber = new FieldModel();
            apartmentNumber.Label = "Dzīvokļa nummurs";
            apartmentNumber.Name = "AppartmentNo";
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
