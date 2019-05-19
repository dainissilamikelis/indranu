using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using indranu7.models;

namespace indranu7.buisinessLogic
{
    public class utils
    {

        public string getMonthName()
        {
            var today = DateTime.Now;
            var monthId = today.AddMonths(-1).Month;
            switch (monthId)
            {
                case 1:
                    return "Januvāris";
                case 2:
                    return "Februāris";
                case 3:
                    return "Marts";
                case 4:
                    return "Aprīlis";
                case 5:
                    return "Maijs";
                case 6:
                    return "Jūnijs";
                case 7:
                    return "Jūlijs";
                case 8:
                    return "Augusts";
                case 9:
                    return "Septembris";
                case 10:
                    return "Oktobris";
                case 11:
                    return "Novembris";
                default:
                    return "Decembirs";

            }
        }

        public string getYear()
        {
            var today = DateTime.Now;

            return today.Year.ToString();
        }

        public decimal GetTarif(decimal Amout, decimal Cost)
        {
            return Decimal.Divide(Amout, Cost);
        }

        public decimal AmountToPay(decimal Amout, decimal Tarif)
        {
            return Amout * Tarif;
        }

        public decimal roundMultiply(decimal value1, decimal value2, int decimals = 4)
        {
            var value = value1 * value2;
            return Math.Round(value, decimals);
        }

        public decimal multiply(decimal value1, decimal value2)
        {
            return value1 * value2;
        }

        public decimal formatValueToDecimal(string value)
        {
            decimal defaulValue = 0.00M;
            if (value != string.Empty)
            {
                var decimalValue = Convert.ToDecimal(value);
                return Math.Round(decimalValue, 2);
            }

            return defaulValue;
        }

        public FieldModel[] createSignatures(string payerName, string payerSurname)
        {
            var signatures = new FieldModel[4];
            signatures[0] = createField("Saņēmēja paraksts", "", "ReceiverSignature", "", "text");
            signatures[1] = createField("Atšifrējums", "", "ReceiverSignatureMeaning", "Inese Silamiķele", "text");
            signatures[2] = createField("Saņēmēja paraksts", "", "PayerSignature", "", "text");
            signatures[3] = createField("Atšifrējums", "", "PayerSignatureMeaning", payerName + payerSurname, "text");

            return signatures;
        }

        public FieldModel[] createPerson(string Name, string Surname, string ID, string Address, string Type = "Payer")
        {
            var person = new FieldModel[4];
            person[0] = createField("Vārds", "", Type + "Name", Name, "text");
            person[1] = createField("Uzvārds", "", Type + "Surname", Surname, "text");
            person[2] = createField("Personas kods", "", Type + "ID", ID, "text");
            person[3] = createField("Dzīves vieta", "", Type + "Address", Address, "text");

            return person;
        }


        public FieldModel createField(string Label, string Unit, string Name, string Value = "", string Type = "number")
        {
            //if (Value == String.Empty) Value = "123"; 

            var newField = new FieldModel();
            newField.Label = Label;
            newField.Type = Type;
            newField.Unit = Unit;
            newField.Name = Name;
            newField.Value = Value;

            return newField;
        }

        public TarifModel createTarifField(string Name, decimal Value)
        {
            var tarif = new TarifModel();
            tarif.TarifName = Name;
            tarif.Tarif = Value;

            return tarif;
        }

        public CostFieldModel createCostField(string Label, string AmountUnit, string Name, decimal ValueAmount = 0.00M, decimal CostValue = 0.00M)
        {
            var newCostField = new CostFieldModel();
            string costLabel = "Maksa";
            string amountLabel = Label;
            string costName = Name + "Cost";
            string amountName = Name + "Amount";
            newCostField.CostField = createField(costLabel, "EUR", costName, CostValue.ToString());
            newCostField.AmountField = createField(Label, AmountUnit, amountName, ValueAmount.ToString());

            return newCostField;
        }

        public AssetModel createTenantFormField(string ApartmentNo, decimal TenantCount, decimal Discount = 0.00M, string AdditonalInformation = "", decimal Dept = 0.00M)
        {
            var newTenant = new AssetModel();
            var fields = new FieldModel[3];
            string TenantCountName = ApartmentNo + "TenantCount";
            string TenantDiscauntName = ApartmentNo + "TenantDiscount";
            string TenantExtraInforName = ApartmentNo + "TenantExtraInfo";
            newTenant.Label = ApartmentNo;
            var TenantCountField = createField("Īrnieku skaits", "", TenantCountName, TenantCount.ToString());
            var Discountfield = createField("Atlaide", "EUR", TenantDiscauntName, Discount.ToString());
            var AdditonalInformationField = createField("Papildus informācija", "", TenantExtraInforName);
            fields[0] = TenantCountField;
            fields[1] = Discountfield;
            fields[2] = AdditonalInformationField;
            newTenant.Fields = fields;
            return newTenant;
        }

        private string getHundrenText(char value)
        {
            switch (value)
            {
                case '2':
                    return "divi simti";
                case '3':
                    return "trīs simti";
                case '4':
                    return "četri simti";
                case '5':
                    return "pieci simti";
                case '6':
                    return "seši simti";
                case '7':
                    return "septiņi simti";
                case '8':
                    return "astoņi simti";
                case '9':
                    return "deviņi simti";
                default: return "viens simts";
            }
        }

        private string getOneText(char value)
        {
            switch (value)
            {
                case '1':
                    return "viens";
                case '2':
                    return "divi";
                case '3':
                    return "trīs";
                case '4':
                    return "četri";
                case '5':
                    return "pieci";
                case '6':
                    return "seši";
                case '7':
                    return "septiņi";
                case '8':
                    return "astoņi";
                case '9':
                    return "deviņi";
                default: return string.Empty;
            }
        }

        private string getTenText(char value)
        {
            var defValue = "";
            var addValue = "";
            switch (value)
            {
                case '1':
                    addValue = "desmit";
                    break;
                case '2':
                    addValue = "div";
                    break;
                case '3':
                    addValue = "trīs";
                    break;
                case '4':
                    addValue = "četr";
                    break;
                case '5':
                    addValue = "piec";
                    break;
                case '6':
                    addValue = "seš";
                    break;
                case '7':
                    addValue = "setpiņ";
                    break;
                case '8':
                    addValue = "astoņ";
                    break;
                case '9':
                    addValue = "deviņ";
                    break;
            }

            return addValue + defValue;
        }


        private string getBigSumText(Char[] bigSum)
        {
            var text = "";
            if (bigSum.Length == 3)
            {
                var hundred = getHundrenText(bigSum[0]);
                var tens = getTenText(bigSum[1]);
                var ones = getOneText(bigSum[2]);
                text = hundred + " " + tens + " " + ones;
            }
            else if (bigSum.Length == 2)
            {
                var tens = getTenText(bigSum[0]);
                var ones = getOneText(bigSum[1]);
                text = tens + " " + ones;
            }
            else
            {
                var ones = getOneText(bigSum[0]);
                text = ones;
            }

            return text + " EUR";
        }

        public string createTextSum(string sum)
        {
            var splitSum = sum.Split('.');
            var end = "i";
            var bigSum = splitSum[0];
            var smallSum = splitSum[1];
            var text = string.Empty;
            var newText = "00 EUR";
            if (smallSum[1] == '1') end = "s";
            if (bigSum.Length != 0)
            {
                text = getBigSumText(bigSum.ToArray());
            }

            if (text != string.Empty)
            {
                string firstUpper = text[0].ToString().ToUpper();
                newText = firstUpper + text.Substring(1, text.Length - 1);

            }
            return newText + " un " + smallSum + " cent" + end;
        }

        public FieldModel[] GetTenantInformation(int apartmentId)
        {
            switch (apartmentId)
            {
                case 1:
                    return createPerson("Dāvis", "Sīmanis", "21080-10909", "Indrānu iela 7-1");
                case 2:
                    return createPerson("Anastasija", "Geca", "", "Indrānu iela 7-2");
                case 3:
                    return createPerson("Anda", "Masējeva", "221057-10103", "Indrānu iela 7-3");
                case 4:
                    return createPerson("Valentīna", "Kuščenko", "070152-10118", "Indrānu iela 7-4");
                case 5:
                    return createPerson("Gatis", "Ķīsis", "301171-10615", "Indrānu iela 7-5");
                case 6:
                    return createPerson("Juris", "Krežis", "170439-10102", "Indrānu iela 7-6");
                case 7:
                    return createPerson("Jeļena", "Baševska", "", "Indrānu iela 7-7");
                case 8:
                    return createPerson("Ance", "Purmale", "", "Indrānu iela 7-8");
                case 9:
                    return createPerson("Andis", "Jargans", "", "Indrānu iela 7-9");
                case 10:
                    return createPerson("Lelde", "Sebre", "060171-11209", "Indrānu iela 7-10");
                case 11:
                    return createPerson("Salvis", "Skopāns", "", "Indrānu iela 7-11");
                case 12:
                    return createPerson("Ivo", "Lorencs", "", "Indrānu iela 7-12");
                case 14:
                    return createPerson("Kārlis", "Dombrovskis", "260168-11293", "Indrānu iela 7-14");
                case 15:
                    return createPerson("Katrīna", "Bičevska", "220198-10706", "Indrānu iela 7-15");
                default:
                    return createPerson("Inese", "Silamiķele", "220263-10101", "Selges Iela 14");
            }
        }

        public decimal GetApartmentArea(int apartmentId)
        {
            switch (apartmentId)
            {
                case 1:
                    return 54.16M;
                case 2:
                    return 30.48M;
                case 3:
                    return 35.17M;
                case 4:
                    return 57.07M;
                case 5:
                    return 54.33M;
                case 6:
                    return 58.39M;
                case 7:
                    return 72.28M;
                case 8:
                    return 54.8M;
                case 9:
                    return 58.01M;
                case 10:
                    return 71.86M;
                case 11:
                    return 49.4M;
                case 12:
                    return 55.15M;
                case 14:
                    return 53.34M;
                case 15:
                    return 49.79M;
                default:
                    return 0;
            }
        }

        public int GetDefaultTenantCount(int apartmentId)
        {
            switch (apartmentId)
            {
                case 1:
                    return 1;
                case 2:
                    return 1;
                case 3:
                    return 1;
                case 4:
                    return 2;
                case 5:
                    return 2;
                case 6:
                    return 2;
                case 7:
                    return 2;
                case 8:
                    return 3;
                case 9:
                    return 3;
                case 10:
                    return 2;
                case 11:
                    return 3;
                case 12:
                    return 1;
                case 14:
                    return 2;
                case 15:
                    return 1;
                default:
                    return 0;
            }
        }

        public decimal GetRent(int apartmentId)
        {
            switch (apartmentId)
            {
                case 1:
                    return 77;
                case 2:
                    return 90;
                case 3:
                    return 50;
                case 4:
                    return 150;
                case 5:
                    return 150;
                case 6:
                    return 10;
                case 7:
                    return 200;
                case 8:
                    return 77.82M;
                case 10:
                    return 102;
                case 11:
                    return 200;
                case 12:
                    return 190;
                case 14:
                    return 75.74M;
                default:
                    return 0;
            }
        }

        public decimal GetParking(int apartmentId)
        {
            if (apartmentId == 1 || apartmentId == 7 || apartmentId == 10 || apartmentId == 11 || apartmentId == 12)
                return 25;

            return 0;
        }
    }
}
