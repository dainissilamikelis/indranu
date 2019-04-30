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
            var receiptFields = new FieldModel[10];
            var monthField = new FieldModel();
            monthField.Label = "Mēnesis";
            monthField.Type = "month";
            monthField.Unit = "";
            monthField.Value = new DateTime(today.Year, today.Month, 1).ToString();
            monthField.Name = "Month";

            var eletricityField = new FieldModel();
            eletricityField.Label = "Elektroenerģija";
            eletricityField.Type = "number";
            eletricityField.Unit = "kWh";
            eletricityField.Value = "";
            eletricityField.Name = "EletricityAmount";

            var eletricityCost = new FieldModel();
            eletricityCost.Label = "Elektrības izmaksa";
            eletricityCost.Type = "number";
            eletricityCost.Unit = "EUR";
            eletricityCost.Value = "";
            eletricityCost.Name = "EletricityCost";

            var coldWater = new FieldModel();
            coldWater.Label = "Aukstais ūdens";
            coldWater.Type = "number";
            coldWater.Unit = "m3";
            coldWater.Value = "";
            coldWater.Name = "ColdWaterAmount";

            var coldWaterCost = new FieldModel();
            coldWaterCost.Label = "Aukstā ūdens izmaksa";
            coldWaterCost.Type = "number";
            coldWaterCost.Unit = "EUR";
            coldWaterCost.Value = "";
            coldWaterCost.Name = "ColdWaterCost";

            var heat = new FieldModel();
            heat.Label = "Apkure";
            heat.Type = "number";
            heat.Unit = "MWh";
            heat.Value = "";
            heat.Name = "HeatAmount";

            var heatCost = new FieldModel();
            heatCost.Label = "Apkures izmaksa";
            heatCost.Type = "number";
            heatCost.Unit = "EUR";
            heatCost.Value = "";
            heatCost.Name = "HeatCost";

            var hotWater = new FieldModel();
            hotWater.Label = "Siltais ūdens";
            hotWater.Type = "number";
            hotWater.Unit = "m3";
            hotWater.Value = "";
            hotWater.Name = "HotWaterAmount";

            var wasteCost = new FieldModel();
            wasteCost.Label = "Atkritumu izmaksa";
            wasteCost.Type = "number";
            wasteCost.Unit = "EUR";
            wasteCost.Value = ""; // autofill from prveious
            wasteCost.Name = "WasteCost";

            var taxCost = new FieldModel();
            taxCost.Label = "Nodoklis";
            taxCost.Type = "number";
            taxCost.Unit = "EUR";
            taxCost.Value = "";
            taxCost.Name = "TaxCost";



            receiptFields[0] = monthField;
            receiptFields[1] = eletricityField;
            receiptFields[2] = eletricityCost;
            receiptFields[3] = coldWater;
            receiptFields[4] = coldWaterCost;
            receiptFields[5] = heat;
            receiptFields[6] = heatCost;
            receiptFields[7] = hotWater;
            receiptFields[8] = wasteCost;
            receiptFields[9] = taxCost;

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
