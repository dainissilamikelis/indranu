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
            var today = DateTime.Today;
            var receiptFields = new FieldModel[9];
            var motnhField = new FieldModel();
            motnhField.Label = "Mēnesis";
            motnhField.Type = "text";
            motnhField.Unit = "";
            motnhField.Value = new DateTime(today.Year, today.Month, 1).ToString();

            var eletricityField = new FieldModel();
            eletricityField.Label = "Elektroenerģija";
            eletricityField.Type = "decimal";
            eletricityField.Unit = "kWh";
            eletricityField.Value = "";

            var eletricityCost = new FieldModel();
            eletricityCost.Label = "Elektrības izmaksa";
            eletricityCost.Type = "decimal";
            eletricityCost.Unit = "EUR";
            eletricityCost.Value = "";

            var coldWater = new FieldModel();
            coldWater.Label = "Aukstais ūdens";
            coldWater.Type = "decimal";
            coldWater.Unit = "m3";
            coldWater.Value = "";

            var coldWaterCost = new FieldModel();
            coldWaterCost.Label = "Aukstā ūdens izmaksa";
            coldWaterCost.Type = "decimal";
            coldWaterCost.Unit = "EUR";
            coldWaterCost.Value = "";

            var heat = new FieldModel();
            heat.Label = "Apkure";
            heat.Type = "decimal";
            heat.Unit = "MWh";
            heat.Value = "";

            var heatCost = new FieldModel();
            heatCost.Label = "Apkures izmaksa";
            heatCost.Type = "decimal";
            heatCost.Unit = "EUR";
            heatCost.Value = "";

            var hotWater = new FieldModel();
            hotWater.Label = "Siltais ūdens";
            hotWater.Type = "decimal";
            hotWater.Unit = "m3";
            hotWater.Value = "";

            var wasteCost = new FieldModel();
            wasteCost.Label = "Atkritumu izmaksa";
            wasteCost.Type = "decimal";
            wasteCost.Unit = "EUR";
            wasteCost.Value = ""; // autofill from prveious

            var taxCost = new FieldModel();
            taxCost.Label = "Nodoklis";
            taxCost.Type = "decimal";
            taxCost.Unit = "EUR";
            taxCost.Value = "";



            receiptFields[0] = motnhField;
            receiptFields[1] = eletricityField;
            receiptFields[2] = coldWater;
            receiptFields[3] = coldWaterCost;
            receiptFields[4] = heat;
            receiptFields[5] = heatCost;
            receiptFields[6] = hotWater;
            receiptFields[7] = wasteCost;
            receiptFields[8] = taxCost;

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
