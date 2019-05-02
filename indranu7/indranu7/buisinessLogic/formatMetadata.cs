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

        public static ReceiptFormModel GetReceiptFields()
        {
            var receiptForm = new ReceiptFormModel();
            var receiptFields = new FieldModel[11];
            var apartmentFields = new FieldModel[14];
            var utils = new utils();
            var today = DateTime.Now;
            var lastMonth = today.AddMonths(-1).Month;

            receiptFields[0] = utils.createField("Mēnesis", "2019", "Month", utils.getMonthName(lastMonth), "text");
            receiptFields[1] = utils.createField("Elektroenerģija", "kWh", "EletricityAmount");
            receiptFields[2] = utils.createField("Elektrības maksa", "EUR", "EletricityCost");
            receiptFields[3] = utils.createField("Aukstais ūdens", "m3", "ColdWaterAmount");
            receiptFields[4] = utils.createField("Aukstā ūdens maksa", "EUR", "ColdWaterCost");
            receiptFields[5] = utils.createField("Apkure", "MWh", "HeatAmount");
            receiptFields[6] = utils.createField("Apkures maksa", "EUR", "HeatCost");
            receiptFields[7] = utils.createField("Siltais ūdens", "m3", "HotWaterAmount");
            receiptFields[8] = utils.createField("Atkritumu izmaksa", "EUR", "WasteCost");
            receiptFields[9] = utils.createField("Nodoklis", "Eur", "TaxCost");
            receiptFields[10] = utils.createField("Papildinformācija", "", "ExtraInfo", "", "Text");

            apartmentFields[0] = utils.createField("Dz.1", "īrnieki", "1_Tenats");
            apartmentFields[1] = utils.createField("Dz.2", "īrnieki", "2_Tenats");
            apartmentFields[2] = utils.createField("Dz.3", "īrnieki", "3_Tenats");
            apartmentFields[3] = utils.createField("Dz.4", "īrnieki", "4_Tenats");
            apartmentFields[4] = utils.createField("Dz.5", "īrnieki", "5_Tenats");
            apartmentFields[5] = utils.createField("Dz.6", "īrnieki", "6_Tenats");
            apartmentFields[6] = utils.createField("Dz.7", "īrnieki", "7_Tenats");
            apartmentFields[7] = utils.createField("Dz.8", "īrnieki", "8_Tenats");
            apartmentFields[8] = utils.createField("Dz.9", "īrnieki", "9_Tenats");
            apartmentFields[9] = utils.createField("Dz.10", "īrnieki", "10_Tenats");
            apartmentFields[10] = utils.createField("Dz.11", "īrnieki", "11_Tenats");
            apartmentFields[11] = utils.createField("Dz.12", "īrnieki", "12_Tenats");
            apartmentFields[12] = utils.createField("Dz.14", "īrnieki", "14_Tenats");
            apartmentFields[13] = utils.createField("Dz.15", "īrnieki", "15_Tenats");

            receiptForm.formFields = receiptFields;
            receiptForm.apartmentFields = apartmentFields;

            return receiptForm;
        }

        public static ReceiptModel[] GetReceipts(FieldModel[] inputFields)
        {
            var receipts = new ReceiptModel[16];
            var utils = new utils();
            var tarifs = calculations.GetTarifs(inputFields);

            for (int i = 1; i < 15; i++)
            {
                if(i != 13)
                {
                    var newReceipt = new ReceiptModel();
                    var receiver = utils.createPerson("Inese", "Silamiķele", "220261-10101", "Selgas iela 14-1", "Receiver");
                    var payer = utils.createPerson("TEST" + i, "testing", "test-test", "Test 12");

                    newReceipt.Label = i + ". Dzīvoklis";
                    newReceipt.Receiver = receiver;
                    newReceipt.Payer = payer;
                    newReceipt.Value = i;
                    newReceipt.Receipt = calculations.GetReceipt(tarifs, 54.16M, 1.0M);

                    receipts[i] = newReceipt;
                }
            }

            return receipts;
        }

        public static AssetModel[] GetAssets()
        {
            var assets = new AssetModel[14];

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
