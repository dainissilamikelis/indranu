using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using indranu7.models;

namespace indranu7.buisinessLogic
{
    public static class calculations
    {

        // atgriez kopejo patero auksta udens daudzumus
        private static decimal GetUsedColdWaterAmount_TOTAL(decimal ColdWaterAmout, decimal ColdWaterLoss_CONSTANT)
        {
            return ColdWaterAmout - ColdWaterLoss_CONSTANT;
        }

        // atgriez silto udens daudzumu
        private static decimal GetWaterHeatingEnergy_TOTAL(decimal WarmWaterAmout, decimal WaterHeating_CONSTANT)
        {
            return WarmWaterAmout * WaterHeating_CONSTANT;
        }

        private static decimal GetHeatingEnergy_TOTAL(decimal HeatingEnergy, decimal WaterHeatingEnergy, decimal HeatingEnergyLoss_CONSTNAT)
        {
            return HeatingEnergy - WaterHeatingEnergy - HeatingEnergyLoss_CONSTNAT;
        }

        private static decimal GetUpkeepEletricity_TOTAL(decimal Power_CONSTANT)
        {
            decimal receiptMonthHouts = 1;
            return (Power_CONSTANT * receiptMonthHouts) / 1000;
        }

        private static decimal GetLigthingEnergy_TOTAL(decimal ElectricityAmout, decimal Power_CONSTANT)
        {
            return ElectricityAmout - GetUpkeepEletricity_TOTAL(Power_CONSTANT);
        }

        private static decimal GetTarif(decimal Amout, decimal Cost)
        {
            return Decimal.Divide(Amout, Cost);
        }

        private static decimal AmountToPay(decimal Amout, decimal Tarif)
        {
            return Amout * Tarif;
        }
        
        private static decimal roundMultiply(decimal value1, decimal value2)
        {
            var value = value1 * value2;
            return Math.Round(value, 2);
        }


        public static ReceiptModel[] GetReceipts(FieldModel[] inputFields)
        {
            var fieldMap = new Dictionary<string, decimal>();
            var receipts = new ReceiptModel[4];
            decimal ColdWaterLoss = 1.00M;
            decimal WaterHeating = 1.00M;
            decimal HeatingEnergyLoss = 1.00M;
            decimal Power = 1.00M;
            int counter = 1;
            var utils = new utils();
            foreach (FieldModel field in inputFields)
            {
                if (field.Type != "month")
                    fieldMap.Add(field.Name, utils.formatValueToDecimal(field.Value));
            }

            decimal TotalUsedColdWaterAmount = GetUsedColdWaterAmount_TOTAL(fieldMap["ColdWaterAmount"], ColdWaterLoss);
            decimal WaterHeatingEnergyAmount = GetWaterHeatingEnergy_TOTAL(fieldMap["HotWaterAmount"], WaterHeating);
            decimal TotalHeatingEneryUsed = GetHeatingEnergy_TOTAL(fieldMap["HeatAmount"], WaterHeatingEnergyAmount, HeatingEnergyLoss);
            decimal UpkeekElectricity = GetUpkeepEletricity_TOTAL(Power);
            decimal LigthingEnergy = GetLigthingEnergy_TOTAL(fieldMap["EletricityAmount"], Power);
            decimal EletricityTarif = GetTarif(fieldMap["EletricityAmount"], fieldMap["EletricityCost"]);
            decimal HeatTarif = GetTarif(fieldMap["HeatAmount"], fieldMap["HeatCost"]);
            decimal WaterTarif = GetTarif(fieldMap["ColdWaterAmount"], fieldMap["ColdWaterCost"]);
            decimal totalTenantAmout = 15.00M;
            decimal apparmentCount = 14.00M;
            decimal totalApartmentArea = 1000.33M;
            decimal ColdWaterVolumePerTenantTarif = GetTarif(TotalUsedColdWaterAmount, totalTenantAmout);
            decimal WaterLossTarifPerAppartmentTarif = GetTarif(ColdWaterLoss, apparmentCount);
            decimal WaterHeatingPerTenantTarif = GetTarif(WaterHeatingEnergyAmount, totalTenantAmout);
            decimal WaterHeatingLossPerApparmentTarif = GetTarif(WaterHeating, apparmentCount);
            decimal HeatingPerSqoureMeterTarif = GetTarif(TotalHeatingEneryUsed, totalApartmentArea);
            decimal LightingPerTenantTarif = GetTarif(LigthingEnergy, totalTenantAmout);
            decimal UpkeepEletricityTarif = GetTarif(UpkeekElectricity, apparmentCount);
            decimal WastePerTenantTarif = GetTarif(fieldMap["WasteCost"], totalTenantAmout);
            decimal TaxTarifPerSqoureMeter = GetTarif(fieldMap["TaxCost"], totalApartmentArea);

            for (int i = 0; i < 3; i++)
            {
                var receipt = new ReceiptModel();
                receipt.Label = counter.ToString() + " Dzivoklis";
                receipt.Fields = new FieldModel[15];
                receipt.Value = counter;
                counter++;

                decimal tenantsInAparment = 3.00M;
                decimal aparmentArea = 46.7M;
                decimal ColdWaterUsed = roundMultiply(ColdWaterVolumePerTenantTarif, tenantsInAparment);
                decimal ColWaterLoss = Math.Round(WaterLossTarifPerAppartmentTarif,2);
                decimal WaterHeatingApartment = roundMultiply(WaterHeatingPerTenantTarif , tenantsInAparment);
                decimal WaterHeatingLoss = Math.Round(WaterHeatingLossPerApparmentTarif,2);
                decimal Heating = roundMultiply(HeatingPerSqoureMeterTarif, aparmentArea);
                decimal lighting = roundMultiply(LightingPerTenantTarif, tenantsInAparment);
                decimal upkeepEletricity = Math.Round(UpkeepEletricityTarif);

                decimal waste = roundMultiply(WastePerTenantTarif,tenantsInAparment);
                decimal tax = roundMultiply(TaxTarifPerSqoureMeter, aparmentArea);
                decimal ColdWaterUsedSum = roundMultiply(ColdWaterUsed, WaterTarif);
                decimal ColdWaterLossSum = roundMultiply(ColWaterLoss, WaterTarif);
                decimal WaterHeatingSum = roundMultiply(WaterHeating, HeatTarif);
                decimal WaterHeatingLossSum = roundMultiply(WaterHeatingLoss, HeatTarif);
                decimal HeatingSum = roundMultiply(Heating, HeatTarif);
                decimal lightingSum = roundMultiply(lighting, EletricityTarif);
                decimal upkeepEletricitySum = roundMultiply(upkeepEletricity, EletricityTarif);


                //foreach(FieldModel field in receipt.Fields)
                //{
                //    var newField = new FieldModel();

                //}


                var Field1 = new FieldModel();
                var Field2 = new FieldModel();
                var Field3 = new FieldModel();
                var Field4 = new FieldModel();
                var Field5 = new FieldModel();
                var Field6 = new FieldModel();
                var Field7 = new FieldModel();
                var Field8 = new FieldModel();
                var Field9 = new FieldModel();
                var Field10 = new FieldModel();
                var Field11 = new FieldModel();
                var Field12 = new FieldModel();
                var Field13 = new FieldModel();
                var Field14 = new FieldModel();
                var Field15 = new FieldModel();


                Field1.Label = "Cold water used";
                Field1.Name = "1";
                Field1.Unit = "m3";
                Field1.Type = "decimal";
                Field1.Value = ColdWaterUsed.ToString();

                Field2.Label = "Cold water cost";
                Field2.Name = "2";
                Field2.Unit = "EUR";
                Field2.Type = "decimal";
                Field2.Value = ColdWaterUsedSum.ToString();

                Field3.Label = "Cold water loss";
                Field3.Name = "3";
                Field3.Unit = "m3";
                Field3.Type = "decimal";
                Field3.Value = ColdWaterLoss.ToString();

                Field4.Label = "Cold water loss cost";
                Field4.Name = "4";
                Field4.Unit = "eur";
                Field4.Type = "decimal";
                Field4.Value = ColdWaterLossSum.ToString();

                Field5.Label = "Water heating";
                Field5.Name = "5";
                Field5.Unit = "kWh";
                Field5.Type = "decimal";
                Field5.Value = WaterHeatingApartment.ToString();

                Field6.Label = "Water heatign cost";
                Field6.Name = "6";
                Field6.Unit = "EUR";
                Field6.Type = "decimal";
                Field6.Value = WaterHeatingSum.ToString();

                Field7.Label = "Water heating loss";
                Field7.Name = "7";
                Field7.Unit = "kWh";
                Field7.Type = "decimal";
                Field7.Value = WaterHeatingLoss.ToString();

                Field8.Label = "Heating";
                Field8.Name = "8";
                Field8.Unit = "kWh";
                Field8.Type = "decimal";
                Field8.Value = Heating.ToString();

                Field9.Label = "Heating cost";
                Field9.Name = "9";
                Field9.Unit = "EUR";
                Field9.Type = "decimal";
                Field9.Value = HeatingSum.ToString();

                Field10.Label = "Lighting";
                Field10.Name = "10";
                Field10.Unit = "kWh";
                Field10.Type = "decimal";
                Field10.Value = lighting.ToString();

                Field11.Label = "Ligthing cost";
                Field11.Name = "11";
                Field11.Unit = "EUR";
                Field11.Type = "decimal";
                Field11.Value = lightingSum.ToString();

                Field12.Label = "Upkeep eletrcity";
                Field12.Name = "12";
                Field12.Unit = "kWh";
                Field12.Type = "decimal";
                Field12.Value = upkeepEletricity.ToString();

                Field13.Label = "Upkeep eletricity cost";
                Field13.Name = "13";
                Field13.Unit = "EUR";
                Field13.Type = "decimal";
                Field13.Value = upkeepEletricitySum.ToString();

                Field14.Label = "waste";
                Field14.Name = "14";
                Field14.Unit = "EUR";
                Field14.Type = "decimal";
                Field14.Value = waste.ToString();

                Field15.Label = "tax";
                Field15.Name = "15";
                Field15.Unit = "EUR";
                Field15.Type = "decimal";
                Field15.Value = tax.ToString();

                receipt.Fields[0] = Field1;
                receipt.Fields[1] = Field2;
                receipt.Fields[2] = Field4;
                receipt.Fields[3] = Field5;
                receipt.Fields[4] = Field6;
                receipt.Fields[5] = Field8;
                receipt.Fields[6] = Field7;
                receipt.Fields[7] = Field8;
                receipt.Fields[8] = Field9;
                receipt.Fields[9] = Field10;
                receipt.Fields[10] = Field11;
                receipt.Fields[11] = Field12;
                receipt.Fields[12] = Field13;
                receipt.Fields[13] = Field14;
                receipt.Fields[14] = Field15;


                receipts[i] = receipt;
            }

            return receipts;
        }

    }
}
