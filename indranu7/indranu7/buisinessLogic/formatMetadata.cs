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
            var receiptFields = new FieldModel[12];
            var apartmentFields = new AssetModel[14];
            var utils = new utils();


            receiptFields[0] = utils.createField("Mēnesis", "2019", "Month", utils.getMonthName(), "text");

            receiptFields[1] = utils.createField("Elektroenerģija", "kWh", "EletricityAmount");
            receiptFields[2] = utils.createField("Elektrības maksa", "EUR", "EletricityCost");
            receiptFields[3] = utils.createField("Aukstais ūdens", "m3", "ColdWaterAmount");
            receiptFields[4] = utils.createField("Aukstā ūdens maksa", "EUR", "ColdWaterCost");
            receiptFields[5] = utils.createField("Apkure", "MWh", "HeatAmount");
            receiptFields[6] = utils.createField("Apkures maksa", "EUR", "HeatCost");
            receiptFields[7] = utils.createField("Siltais ūdens", "m3", "HotWaterAmount");
            receiptFields[8] = utils.createField("Atkritumu izmaksa", "EUR", "WasteCost");
            receiptFields[9] = utils.createField("Nodoklis", "Eur", "TaxCost");
            receiptFields[10] = utils.createField("Papildinformācija", "", "ExtraInfo", "", "text");
            receiptFields[11] = utils.createField("Versija", "", "Revision", "A", "text");

            apartmentFields[0] = utils.createTenantFormField("Dz.1", 1.00M);
            apartmentFields[1] = utils.createTenantFormField("Dz.2", 1.00M);
            apartmentFields[2] = utils.createTenantFormField("Dz.3", 1.00M);
            apartmentFields[3] = utils.createTenantFormField("Dz.4", 2.00M);
            apartmentFields[4] = utils.createTenantFormField("Dz.5", 2.00M);
            apartmentFields[5] = utils.createTenantFormField("Dz.6", 2.00M);
            apartmentFields[6] = utils.createTenantFormField("Dz.7", 2.00M);
            apartmentFields[7] = utils.createTenantFormField("Dz.8", 3.00M);
            apartmentFields[8] = utils.createTenantFormField("Dz.9", 3.00M);
            apartmentFields[9] = utils.createTenantFormField("Dz.10", 2.00M);
            apartmentFields[10] = utils.createTenantFormField("Dz.11", 3.00M);
            apartmentFields[11] = utils.createTenantFormField("Dz.12", 1.00M);
            apartmentFields[12] = utils.createTenantFormField("Dz.14", 2.00M);
            apartmentFields[13] = utils.createTenantFormField("Dz.15", 1.00M);

            receiptForm.FormFields = receiptFields;
            receiptForm.ApartmentFields = apartmentFields;

            return receiptForm;
        }

        public static ReceiptModel[] GetReceipts(ReceiptFormModel inputFields)
        {
            var receipts = new ReceiptModel[16];
            var utils = new utils();
            var tarifs = calculations.GetTarifs(inputFields.FormFields);

            for (int i = 0; i < 14; i++)
            {

                int apartmentNo = (i + 1);
                if (i == 12) apartmentNo = 14;
                if (i == 13) apartmentNo = 15;

                var newReceipt = new ReceiptModel();
                var receiver = utils.createPerson("Inese", "Silamiķele", "220263-10101", "Selgas iela 14-1", "Receiver");
                var payer = utils.GetTenantInformation(apartmentNo);
                newReceipt.Label = apartmentNo + ". Dzīvoklis";
                newReceipt.Id = String.Format("Nr. {0}-{1}-{2}-{3}", utils.getYear(), utils.getMonthName(), apartmentNo, tarifs["Version"]);
                newReceipt.Receiver = receiver;
                newReceipt.Payer = payer;
                newReceipt.Value = i;
                newReceipt.Receipt = calculations.GetReceipt(tarifs, apartmentNo);
                receipts[i] = newReceipt;
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
