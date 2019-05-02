﻿using System;
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

        public static Dictionary<string ,decimal> GetConstants()
        {
            var constants = new Dictionary<string, decimal>();

            constants.Add("ColdWaterLoss", 0.04M);
            constants.Add("WaterHeating", 0.5M);
            constants.Add("HeatingEnergyLoss", 0.03M);
            constants.Add("Power", 0.13M);
            constants.Add("TenantCount", 26.00M);
            constants.Add("ApartmentCount", 14.00M);
            constants.Add("TotalApartmentArea", 754.05M);

            return constants;
        }

        public static Dictionary<string, decimal> GetTarifs(FieldModel[] inputFields)
        {
            var fieldMap = new Dictionary<string, decimal>();
            var tarifMap = new Dictionary<string, decimal>();
            var utils = new utils();

            foreach (FieldModel field in inputFields)
            {
                if (field.Type != "text")
                    fieldMap.Add(field.Name, utils.formatValueToDecimal(field.Value));
            }


            decimal ColdWaterLoss = GetConstants()["ColdWaterLoss"];
            decimal WaterHeating = GetConstants()["WaterHeating"];
            decimal HeatingEnergyLoss = GetConstants()["HeatingEnergyLoss"];
            decimal Power = GetConstants()["Power"];
            decimal totalTenantAmout = GetConstants()["TenantCount"];
            decimal apparmentCount = GetConstants()["ApartmentCount"];
            decimal totalApartmentArea = GetConstants()["TotalApartmentArea"];

            decimal TotalUsedColdWaterAmount = GetUsedColdWaterAmount_TOTAL(fieldMap["ColdWaterAmount"], ColdWaterLoss);
            decimal WaterHeatingEnergyAmount = GetWaterHeatingEnergy_TOTAL(fieldMap["HotWaterAmount"], WaterHeating);
            decimal TotalHeatingEneryUsed = GetHeatingEnergy_TOTAL(fieldMap["HeatAmount"], WaterHeatingEnergyAmount, HeatingEnergyLoss);
            decimal UpkeekElectricity = GetUpkeepEletricity_TOTAL(Power);
            decimal LigthingEnergy = GetLigthingEnergy_TOTAL(fieldMap["EletricityAmount"], Power);
            decimal EletricityTarif = utils.GetTarif(fieldMap["EletricityAmount"], fieldMap["EletricityCost"]);
            decimal HeatTarif = utils.GetTarif(fieldMap["HeatAmount"], fieldMap["HeatCost"]);
            decimal WaterTarif = utils.GetTarif(fieldMap["ColdWaterAmount"], fieldMap["ColdWaterCost"]);
            decimal ColdWaterVolumePerTenantTarif = utils.GetTarif(TotalUsedColdWaterAmount, totalTenantAmout);
            decimal WaterLossPerAppartmentTarif = utils.GetTarif(ColdWaterLoss, apparmentCount);
            decimal WaterHeatingPerTenantTarif = utils.GetTarif(WaterHeatingEnergyAmount, totalTenantAmout);
            decimal WaterHeatingLossPerApparmentTarif = utils.GetTarif(WaterHeating, apparmentCount);
            decimal HeatingPerSqoureMeterTarif = utils.GetTarif(TotalHeatingEneryUsed, totalApartmentArea);
            decimal LightingPerTenantTarif = utils.GetTarif(LigthingEnergy, totalTenantAmout);
            decimal UpkeepEletricityTarif = utils.GetTarif(UpkeekElectricity, apparmentCount);
            decimal WastePerTenantTarif = utils.GetTarif(fieldMap["WasteCost"], totalTenantAmout);
            decimal TaxTarifPerSqoureMeter = utils.GetTarif(fieldMap["TaxCost"], totalApartmentArea);

            tarifMap.Add("ColdWater", ColdWaterVolumePerTenantTarif);
            tarifMap.Add("WaterLoss", WaterLossPerAppartmentTarif);
            tarifMap.Add("WaterHeating", WaterHeatingPerTenantTarif);
            tarifMap.Add("WaterHeatingLoss", WaterHeatingLossPerApparmentTarif);
            tarifMap.Add("Heating", HeatingPerSqoureMeterTarif);
            tarifMap.Add("Lighting", LightingPerTenantTarif);
            tarifMap.Add("UpkeepEletricity", UpkeepEletricityTarif);
            tarifMap.Add("Waste", WastePerTenantTarif);
            tarifMap.Add("Tax", TaxTarifPerSqoureMeter);
            tarifMap.Add("Water", WastePerTenantTarif);
            tarifMap.Add("Heat", HeatingPerSqoureMeterTarif);
            tarifMap.Add("Eletricity", EletricityTarif);

            return tarifMap;
        }

        public static AmoutCostForm GetReceipt(
            Dictionary<string, decimal> tarifs, 
            decimal apartmentArea, 
            decimal tenantsInAparment
            )
        {

            decimal coldWaterLoss = GetConstants()["ColdWaterLoss"];
            decimal waterHeating = GetConstants()["WaterHeating"];

            var receipt = new AmoutCostForm();
            var receiptFields = new FieldModel[7];
            var receiptCostFields = new FieldModel[9];
            var additionalInformation = new FieldModel[1];
            var endInformation = new FieldModel[2];
            var utils = new utils();

            decimal coldWaterTarif = tarifs["ColdWater"];
            decimal waterLossTarif = tarifs["WaterLoss"];
            decimal waterHeatingTarif = tarifs["WaterHeating"];
            decimal waterHeatingLossTarif = tarifs["WaterHeatingLoss"];
            decimal heatingTarif = tarifs["Heating"];
            decimal lightingTarif = tarifs["Lighting"];
            decimal upkeepEletricityTarif = tarifs["UpkeepEletricity"];
            decimal wasteTarif = tarifs["Waste"];
            decimal taxTarif = tarifs["Tax"];
            decimal waterTarif = tarifs["Water"];
            decimal heatTarif = tarifs["Heat"];
            decimal eletricityTarif = tarifs["Eletricity"];

            decimal ColdWaterUsed = utils.roundMultiply(coldWaterTarif, tenantsInAparment);
            decimal ColWaterLoss = Math.Round(waterLossTarif, 2);
            decimal WaterHeatingApartment = utils.roundMultiply(waterHeatingTarif, tenantsInAparment);
            decimal WaterHeatingLoss = Math.Round(waterHeatingLossTarif, 2);
            decimal Heating = utils.roundMultiply(heatingTarif, apartmentArea);
            decimal lighting = utils.roundMultiply(lightingTarif, tenantsInAparment);
            decimal upkeepEletricity = Math.Round(upkeepEletricityTarif);
            decimal waste = utils.roundMultiply(wasteTarif,tenantsInAparment);

            decimal tax = utils.roundMultiply(taxTarif, apartmentArea);
            decimal ColdWaterUsedSum = utils.roundMultiply(ColdWaterUsed, waterTarif);
            decimal ColdWaterLossSum = utils.roundMultiply(ColWaterLoss, waterTarif);
            decimal WaterHeatingSum = utils.roundMultiply(waterHeating, heatTarif);
            decimal WaterHeatingLossSum = utils.roundMultiply(WaterHeatingLoss, heatTarif);
            decimal HeatingSum = utils.roundMultiply(Heating, heatTarif);
            decimal lightingSum = utils.roundMultiply(lighting, eletricityTarif);
            decimal upkeepEletricitySum = utils.roundMultiply(upkeepEletricity, eletricityTarif);

            decimal sum = tax + ColdWaterUsedSum + ColdWaterLossSum + WaterHeatingSum + WaterHeatingLossSum + HeatingSum + lightingSum + upkeepEletricitySum;

            receiptFields[0] = utils.createField("Aukstais ūdens un kanalizācija","m3", "ColdWaterUsed", ColdWaterUsed.ToString());
            receiptFields[1] = utils.createField("Aukstā ūdens zudumi", "m3", "ColdWaterLoss", coldWaterLoss.ToString());
            receiptFields[2] = utils.createField("Siltais ūdens", "kWh", "WaterHeating", WaterHeatingApartment.ToString());
            receiptFields[3] = utils.createField("Siltā ūdens zudumi", "kWh", "WaterHeatingLoss", WaterHeatingLoss.ToString());
            receiptFields[4] = utils.createField("Sildīšana", "kWh", "Heating", Heating.ToString());
            receiptFields[5] = utils.createField("Apgaismojums", "kWh", "Lighting", lighting.ToString());
            receiptFields[6] = utils.createField("Koplietošanas elektroapgāde", "kWh", "UpkeepEletricity", upkeepEletricity.ToString());

            receiptCostFields[0] = utils.createField("Summa", "EUR", "ColdWaterCost", ColdWaterUsedSum.ToString());
            receiptCostFields[1] = utils.createField("Summa", "EUR", "ColdWaterLossCost", ColdWaterLossSum.ToString());
            receiptCostFields[2] = utils.createField("Summa", "EUR", "WaterHeatingCost", WaterHeatingSum.ToString());
            receiptCostFields[3] = utils.createField("Summa", "EUR", "HeatingCost", HeatingSum.ToString().ToString());
            receiptCostFields[4] = utils.createField("Summa", "EUR", "LightingCost", lightingSum.ToString());
            receiptCostFields[5] = utils.createField("Summa", "EUR", "UpkeepEletricity", upkeepEletricitySum.ToString());
            receiptCostFields[6] = utils.createField("Atkritumi un šķirošana", "EUR", "Waste", waste.ToString());
            receiptCostFields[7] = utils.createField("Īpašuma nodoklis", "EUR", "Tax", tax.ToString());
            receiptCostFields[8] = utils.createField("Īre", "EUR", "Rent", "300");

            additionalInformation[0] = utils.createField("Papildinformācija", "", "ExtraInformation", "", "textArea");

            endInformation[0] = utils.createField("Kopsumma", "EUR", "Sum", sum.ToString());
            endInformation[1] = utils.createField("Kopsumma vārdos", "", "TextSum", utils.createTextSum(sum.ToString()), "text");

            receipt.Fields = receiptFields;
            receipt.CostFields = receiptCostFields;
            receipt.AdditionalInformation = additionalInformation;
            receipt.ClosingInformation = endInformation;


            return receipt;
        }

    }
}
