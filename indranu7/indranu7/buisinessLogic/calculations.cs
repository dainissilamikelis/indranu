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

        //decimal eletricityAmount,
        //    decimal electricityCost,
        //    decimal coldWaterAmount,
        //    decimal coldWaterCost,
        //    decimal heatAmount,
        //    decimal heatCost,
        //    decimal hotWaterAmount,
        //    decimal wasteCost,
        //    decimal taxCost,
        //    bool winter,
        //    int[] tenantsInAparments,  // map with key and values
        //    DateTime month



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
                decimal ColdWaterUsed = ColdWaterVolumePerTenantTarif * tenantsInAparment;
                decimal ColWaterLoss = WaterLossTarifPerAppartmentTarif;
                decimal WaterHeatingApartment = WaterHeatingPerTenantTarif * tenantsInAparment;
                decimal WaterHeatingLoss = WaterHeatingLossPerApparmentTarif;
                decimal Heating = HeatingPerSqoureMeterTarif * aparmentArea;
                decimal lighting = LightingPerTenantTarif * tenantsInAparment;
                decimal upkeepEletricity = UpkeepEletricityTarif;

                decimal waste = WastePerTenantTarif * tenantsInAparment;
                decimal tax = TaxTarifPerSqoureMeter * aparmentArea;
                decimal ColdWaterUsedSum = ColdWaterUsed * WaterTarif;
                decimal ColdWaterLossSum = ColWaterLoss * WaterTarif;
                decimal WaterHeatingSum = WaterHeating * HeatTarif;
                decimal WaterHeatingLossSum = WaterHeatingLoss * HeatTarif;
                decimal HeatingSum = Heating * HeatTarif;
                decimal lightingSum = lighting * EletricityTarif;
                decimal upkeepEletricitySum = upkeepEletricity * EletricityTarif;

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


                Field1.Label = "1";
                Field1.Name = "1";
                Field1.Unit = "test";
                Field1.Type = "decimal";
                Field1.Value = ColdWaterUsed.ToString();

                Field2.Label = "2";
                Field2.Name = "2";
                Field2.Unit = "test";
                Field2.Type = "decimal";
                Field2.Value = ColdWaterUsedSum.ToString();

                Field3.Label = "3";
                Field3.Name = "3";
                Field3.Unit = "test";
                Field3.Type = "decimal";
                Field3.Value = ColdWaterLoss.ToString();

                Field4.Label = "4";
                Field4.Name = "4";
                Field4.Unit = "test";
                Field4.Type = "decimal";
                Field4.Value = ColdWaterLossSum.ToString();

                Field5.Label = "5";
                Field5.Name = "5";
                Field5.Unit = "test";
                Field5.Type = "decimal";
                Field5.Value = WaterHeatingApartment.ToString();

                Field6.Label = "6";
                Field6.Name = "6";
                Field6.Unit = "test";
                Field6.Type = "decimal";
                Field6.Value = WaterHeatingSum.ToString();

                Field7.Label = "7";
                Field7.Name = "7";
                Field7.Unit = "test";
                Field7.Type = "decimal";
                Field7.Value = WaterHeatingLoss.ToString();

                Field8.Label = "8";
                Field8.Name = "8";
                Field8.Unit = "test";
                Field8.Type = "decimal";
                Field8.Value = Heating.ToString();

                Field9.Label = "9";
                Field9.Name = "9";
                Field9.Unit = "test";
                Field9.Type = "decimal";
                Field9.Value = HeatingSum.ToString();

                Field10.Label = "10";
                Field10.Name = "10";
                Field10.Unit = "test";
                Field10.Type = "decimal";
                Field10.Value = lighting.ToString();

                Field11.Label = "11";
                Field11.Name = "11";
                Field11.Unit = "test";
                Field11.Type = "decimal";
                Field11.Value = lightingSum.ToString();

                Field12.Label = "12";
                Field12.Name = "12";
                Field12.Unit = "test";
                Field12.Type = "decimal";
                Field12.Value = upkeepEletricity.ToString();

                Field13.Label = "13";
                Field13.Name = "13";
                Field13.Unit = "test";
                Field13.Type = "decimal";
                Field13.Value = upkeepEletricitySum.ToString();

                Field14.Label = "14";
                Field14.Name = "14";
                Field14.Unit = "test";
                Field14.Type = "decimal";
                Field14.Value = waste.ToString();

                Field15.Label = "15";
                Field15.Name = "15";
                Field15.Unit = "test";
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
