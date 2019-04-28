using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using indranu7.models;

namespace indranu7.buisinessLogic
{
    public class calculations
    {

        // atgriez kopejo patero auksta udens daudzumus
        public decimal GetUsedColdWaterAmount_TOTAL(decimal ColdWaterAmout, decimal ColdWaterLoss_CONSTANT)
        {
            return ColdWaterAmout - ColdWaterLoss_CONSTANT;
        }

        // atgriez silto udens daudzumu
        public decimal GetWaterHeatingEnergy_TOTAL(decimal WarmWaterAmout, decimal WaterHeating_CONSTANT)
        {
            return WarmWaterAmout * WaterHeating_CONSTANT;
        }

        public decimal GetHeatingEnergy_TOTAL(decimal HeatingEnergy, decimal WaterHeatingEnergy, decimal HeatingEnergyLoss_CONSTNAT)
        {
            return HeatingEnergy - WaterHeatingEnergy - HeatingEnergyLoss_CONSTNAT;
        }

        public decimal GetUpkeepEletricity_TOTAL(decimal Power_CONSTANT)
        {
            decimal receiptMonthHouts = 1;
            return (Power_CONSTANT * receiptMonthHouts) / 1000;
        }

        public decimal GetLigthingEnergy_TOTAL(decimal ElectricityAmout, decimal Power_CONSTANT)
        {
            return ElectricityAmout - GetUpkeepEletricity_TOTAL(Power_CONSTANT);
        }

        public decimal GetTarif(decimal Amout, decimal Cost)
        {
            return Cost / Amout;
        }

        public decimal AmountToPay(decimal Amout, decimal Tarif)
        {
            return Amout * Tarif;
        }


        public ReceiptModel[] GetReceipts(
            decimal eletricityAmount,
            decimal electricityCost,
            decimal coldWaterAmount,
            decimal coldWaterCost,
            decimal heatAmount,
            decimal heatCost,
            decimal hotWaterAmount,
            decimal wasteCost,
            decimal taxCost,
            bool winter,
            int[] tenantsInAparments,  // map with key and values
            DateTime month
            )
        {
            var receipts = new ReceiptModel[13];
            decimal consant = 1;
            decimal TotalUsedColdWaterAmount = GetUsedColdWaterAmount_TOTAL(coldWaterAmount, consant);
            decimal WaterHeatingEnergyAmount = GetWaterHeatingEnergy_TOTAL(hotWaterAmount, consant);
            decimal TotalHeatingEneryUsed = GetHeatingEnergy_TOTAL(heatAmount, WaterHeatingEnergyAmount, consant);
            decimal UpkeekElectricity = GetUpkeepEletricity_TOTAL(consant);
            decimal LigthingEnergy = GetLigthingEnergy_TOTAL(eletricityAmount, consant);
            decimal EletricityTarif = GetTarif(eletricityAmount, electricityCost);
            decimal HeatTarif = GetTarif(heatAmount, heatCost);
            decimal WaterTarif = GetTarif(coldWaterAmount, coldWaterCost);
            decimal totalTenantAmout = 15;
            decimal apparmentCount = 14;
            decimal totalApartmentArea = 1000;
            decimal ColdWaterVolumePerTenantTarif = GetTarif(TotalUsedColdWaterAmount, totalTenantAmout);
            decimal WaterLossTarifPerAppartmentTarif = GetTarif(consant / apparmentCount);
            decimal WaterHeatingPerTenantTarif = GetTarif(WaterHeatingEnergyAmount / totalTenantAmout);
            decimal WaterHeatingLossPerApparmentTarif = GetTarif(consant / apparmentCount);
            decimal HeatingPerSqoureMeterTarif = GetTarif(TotalHeatingEneryUsed / totalApartmentArea);
            decimal LightingPerTenantTarif = GetTarif(LigthingEnergy, totalTenantAmout);
            decimal UpkeepEletricityTarif = GetTarif(UpkeekElectricity, apparmentCount);
            decimal WastePerTenantTarif = GetTarif(wasteCost / totalTenantAmout);
            decimal TaxTarifPerSqoureMeter = GetTarif(taxCost, totalApartmentArea);

            foreach (var receipt in receipts)
            {
                decimal tenantsInAparment;
                decimal aparmentArea;
                decimal ColdWaterUsed = ColdWaterVolumePerTenantTarif * tenantsInAparment;
                decimal ColWaterLoss = WaterLossTarifPerAppartmentTarif;
                decimal WaterHeating = WaterHeatingPerTenantTarif * tenantsInAparment;
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
            }

            return receipts;
        }

    }
}
