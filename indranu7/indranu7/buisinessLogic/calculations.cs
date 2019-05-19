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

        private static decimal GetHeatingEnergyLoss(decimal HeatingEnergyLoss)
        {
            return HeatingEnergyLoss / 14;
        }

        public static Dictionary<string, decimal> GetConstants()
        {
            var constants = new Dictionary<string, decimal>();

            constants.Add("ColdWaterLoss", 18.5M);
            constants.Add("WaterHeating", 0.06M);
            constants.Add("HeatingEnergyLoss", 1.24M);
            constants.Add("Power", 0.1M);
            constants.Add("TenantCount", 26.00M);
            constants.Add("ApartmentCount", 14.00M);
            constants.Add("TotalApartmentArea", 754.05M);

            return constants;
        }

        public static Dictionary<string, dynamic> GetTarifs(FieldModel[] inputFields)
        {
            var fieldMap = new Dictionary<string, dynamic>();
            var tarifMap = new Dictionary<string, dynamic>();
            var utils = new utils();

            foreach (FieldModel field in inputFields)
            {
                if (field.Type != "text") fieldMap.Add(field.Name, utils.formatValueToDecimal(field.Value));
                else fieldMap.Add(field.Name, field.Value);
            }

            decimal ColdWaterLoss = GetConstants()["ColdWaterLoss"];
            decimal WaterHeating = GetConstants()["WaterHeating"];
            decimal HeatingEnergyLoss = GetConstants()["HeatingEnergyLoss"];
            decimal totalTenantAmount = GetConstants()["TenantCount"];
            decimal apparmentCount = GetConstants()["ApartmentCount"];
            decimal totalApartmentArea = GetConstants()["TotalApartmentArea"];

            decimal TotalUsedColdWaterAmount = GetUsedColdWaterAmount_TOTAL(fieldMap["ColdWaterAmount"], ColdWaterLoss);
            decimal WaterHeatingEnergyAmount = GetWaterHeatingEnergy_TOTAL(fieldMap["HotWaterAmount"], WaterHeating);
            decimal TotalHeatingEneryUsed = GetHeatingEnergy_TOTAL(fieldMap["HeatAmount"], WaterHeatingEnergyAmount, HeatingEnergyLoss);

            //global tarifs
            decimal HeatTarif = utils.GetTarif(fieldMap["HeatCost"], fieldMap["HeatAmount"]);
            decimal WaterTarif = utils.GetTarif(fieldMap["ColdWaterCost"], fieldMap["ColdWaterAmount"]);
            decimal EletricityTarif = utils.GetTarif(fieldMap["EletricityCost"], fieldMap["EletricityAmount"]);

            // based on apartment count
            decimal WaterLossPerAppartmentTarif = utils.GetTarif(ColdWaterLoss, apparmentCount);
            decimal WaterHeatingLossPerApparmentTarif = utils.GetTarif(HeatingEnergyLoss, apparmentCount);
            decimal UpkeepEletricityCost = utils.GetTarif(fieldMap["EletricityCost"], apparmentCount);
            decimal UpkeepEletrcitiyAmount = utils.GetTarif(fieldMap["EletricityAmount"], apparmentCount);
            decimal HeatingEnergyLossAmount = GetHeatingEnergyLoss(HeatingEnergyLoss);

            //based on sqoure meter count
            decimal HeatingPerSqoureMeterTarif = utils.GetTarif(TotalHeatingEneryUsed, totalApartmentArea);
            decimal TaxTarifPerSqoureMeter = utils.GetTarif(fieldMap["TaxCost"], totalApartmentArea);

            //base on tenant count
            decimal WastePerTenantTarif = utils.GetTarif(fieldMap["WasteCost"], totalTenantAmount);
            decimal ColdWaterVolumePerTenantTarif = utils.GetTarif(TotalUsedColdWaterAmount, totalTenantAmount);
            decimal WaterHeatingPerTenantTarif = utils.GetTarif(WaterHeatingEnergyAmount, totalTenantAmount);

            string AdditionalInformation = fieldMap["ExtraInfo"];
            string Revision = fieldMap["Revision"];

            tarifMap.Add("ColdWater", ColdWaterVolumePerTenantTarif);
            tarifMap.Add("WaterLoss", WaterLossPerAppartmentTarif);
            tarifMap.Add("WaterHeating", WaterHeatingPerTenantTarif);
            tarifMap.Add("WaterHeatingLoss", WaterHeatingLossPerApparmentTarif);
            tarifMap.Add("Heating", HeatingPerSqoureMeterTarif);
            tarifMap.Add("UpkeepEletricity", UpkeepEletrcitiyAmount);
            tarifMap.Add("UpkeepEletricityCost", UpkeepEletricityCost);
            tarifMap.Add("Waste", WastePerTenantTarif);
            tarifMap.Add("Tax", TaxTarifPerSqoureMeter);
            tarifMap.Add("GLOBAL_Eletricity", EletricityTarif);
            tarifMap.Add("GLOBAL_Water", WaterTarif);
            tarifMap.Add("GLOBAL_Heat", HeatTarif);
            tarifMap.Add("ExtraInfo", AdditionalInformation);
            tarifMap.Add("Version", Revision);
            tarifMap.Add("HeatingEnergyLossCost", HeatingEnergyLossAmount);

            return tarifMap;
        }

        public static InfoLine GetReceipt(
            Dictionary<string, dynamic> tarifs,
            int apartmentNo
            )
        {

            var utils = new utils();

            var infoLine = new InfoLine();

            var receipt = new AmountCostForm();
            var infoModel = new InfoModel();

            var receiptCostFields = new CostFieldModel[14];
            var additionalInformation = new FieldModel[2];
            var endInformation = new FieldModel[2];
            var signatureInformation = new FieldModel[4];



            var apartmentArea = utils.GetApartmentArea(apartmentNo);
            var tenantsInAparment = utils.GetDefaultTenantCount(apartmentNo);
            var rent = utils.GetRent(apartmentNo);
            var parking = utils.GetParking(apartmentNo);

            decimal coldWaterLoss = GetConstants()["ColdWaterLoss"];
            decimal waterHeating = GetConstants()["WaterHeating"];

            decimal coldWaterTarif = tarifs["ColdWater"];
            decimal waterLossTarif = Math.Round(tarifs["WaterLoss"], 4);
            decimal waterHeatingTarif = tarifs["WaterHeating"];
            decimal waterHeatingLossTarif = tarifs["WaterHeatingLoss"];
            decimal heatingTarif = tarifs["Heating"];
            decimal upkeepAmount = Math.Round(tarifs["UpkeepEletricity"], 4);

            decimal wasteTarif = tarifs["Waste"];
            decimal taxTarif = tarifs["Tax"];
            decimal waterTarif = tarifs["GLOBAL_Water"];
            decimal heatTarif = tarifs["GLOBAL_Heat"];
            decimal heatingLossCost = Math.Round(tarifs["HeatingEnergyLossCost"], 4);
            string extraInfo = tarifs["ExtraInfo"];

            //daudzumu lauki
            decimal ColdWaterUsed = utils.roundMultiply(coldWaterTarif, tenantsInAparment);
            decimal WaterHeatingApartment = utils.roundMultiply(waterHeatingTarif, tenantsInAparment);
            decimal Heating = utils.roundMultiply(heatingTarif, apartmentArea);

            //summu lauki
            decimal ColdWaterUsedSum = utils.roundMultiply(ColdWaterUsed, waterTarif, 2);
            decimal ColdWaterLossSum = utils.roundMultiply(waterLossTarif, waterTarif, 2);
            decimal WaterHeatingSum = utils.roundMultiply(WaterHeatingApartment, heatTarif, 2);
            decimal WaterHeatingLossSum = utils.roundMultiply(heatingLossCost, heatTarif, 2);
            decimal HeatingSum = utils.roundMultiply(Heating, heatTarif, 2);
            decimal upkeepCost = Math.Round(tarifs["UpkeepEletricityCost"], 2);
            decimal waste = utils.roundMultiply(wasteTarif, tenantsInAparment, 2);
            decimal tax = utils.roundMultiply(taxTarif, apartmentArea, 2);


            decimal utilitiesSum = ColdWaterUsedSum + ColdWaterLossSum + WaterHeatingSum + WaterHeatingLossSum + HeatingSum + upkeepCost + waste;
            decimal apartmentSum = tax + parking + rent + 0.00M;
            decimal sum = utilitiesSum + apartmentSum;

            receiptCostFields[0] = utils.createCostField("Aukstais ūdends un kanalizācija", "m3", "ColdWater", ColdWaterUsed, ColdWaterUsedSum);
            receiptCostFields[1] = utils.createCostField("Ausktā ūdens un zudumi", "m3", "ColdWaterLoss", waterLossTarif, ColdWaterLossSum);

            receiptCostFields[2] = utils.createCostField("Siltais ūdens", "MWh", "WaterHeating", WaterHeatingApartment, WaterHeatingSum);
            receiptCostFields[3] = utils.createCostField("Siltā ūdens zudumi", "MWh", "WaterHeatingLoss", heatingLossCost, WaterHeatingLossSum);
            receiptCostFields[4] = utils.createCostField("Apkure", "MWh", "Heating", Heating, HeatingSum);
            receiptCostFields[5] = utils.createCostField("Koplietošanas elektroapgāde", "kWh", "UpkeepEletricity", upkeepAmount, upkeepCost);
            receiptCostFields[6] = utils.createCostField("Atkritumi un šķirošana", "Iedz.", "Waste", tenantsInAparment, waste);
            receiptCostFields[7] = utils.createCostField("Kopā", "EUR", "UtilitiesSum", 1.00M, utilitiesSum);
            receiptCostFields[8] = utils.createCostField("Īpašuma nodoklis", "m2", "Tax", apartmentArea, tax);
            receiptCostFields[9] = utils.createCostField("Īre", "dzīvoklis", "Rent", apartmentNo, rent);
            receiptCostFields[10] = utils.createCostField("Īre", "stāvieta", "CarRent", apartmentNo, parking);
            receiptCostFields[11] = utils.createCostField("Pārads", "dienas", "Debt", 12.00M, 0.00M);
            receiptCostFields[12] = utils.createCostField("Atlaide", "", "Discount", 0.00M, 0.00M);
            receiptCostFields[13] = utils.createCostField("Kopā", "EUR", "apartmentSum", 0.00M, apartmentSum);

            additionalInformation[0] = utils.createField("Papildinformācija", "", "ExtraInformation", extraInfo, "textArea");
            additionalInformation[1] = utils.createField("Papildinformācija dzīvoklim specifiska", "", "ExtraInfoApartment", "", "Text");

            endInformation[0] = utils.createField("Kopsumma", "EUR", "Sum", sum.ToString());
            endInformation[1] = utils.createField("Kopsumma vārdos", "", "TextSum", utils.createTextSum(sum.ToString()), "text");

            receipt.CostFields = receiptCostFields;
            receipt.AdditionalInformation = additionalInformation;
            receipt.ClosingInformation = endInformation;

            infoModel.ApartmentNo = apartmentNo;

            infoModel.Heating = Heating;
            infoModel.HeatingCost = HeatingSum;

            infoModel.HotWater = WaterHeatingApartment;
            infoModel.HotWaterCost = WaterHeatingSum;

            infoModel.HotWaterLoss = heatingLossCost;
            infoModel.HotWaterLossCost = WaterHeatingLossSum;

            infoModel.ColdWater = ColdWaterUsed;
            infoModel.ColdWaterCost = ColdWaterUsedSum;

            decimal coldWaterLossPerApartment = Decimal.Divide(coldWaterLoss, 14);

            infoModel.ColdWaterLoss = Math.Round(coldWaterLossPerApartment, 4);
            infoModel.ColdWaterLossCost = ColdWaterLossSum;

            infoModel.UpkeepCost = upkeepCost;

            infoModel.WasteCost = waste;
            infoModel.Upkeep = upkeepAmount;
            infoModel.UpkeepCost = upkeepCost;
            infoModel.Tax = tax;

            infoLine.infoLine = infoModel;
            infoLine.receipt = receipt;

            return infoLine;
        }

    }
}
