using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using indranu7.models;

namespace indranu7.buisinessLogic
{
    public class utils
    {

        public string getMonthName(int monthId)
        {
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

        public decimal GetTarif(decimal Amout, decimal Cost)
        {
            return Decimal.Divide(Amout, Cost);
        }

        public decimal AmountToPay(decimal Amout, decimal Tarif)
        {
            return Amout * Tarif;
        }

        public decimal roundMultiply(decimal value1, decimal value2)
        {
            var value = value1 * value2;
            return Math.Round(value, 2);
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

        public FieldModel[] createPerson(string Name, string Surname,  string ID, string Address, string Type = "Payer")
        {
            var person = new FieldModel[4];
            person[0] = createField("Vārds", "", Type+"Name", Name, "text");
            person[1] = createField("Uzvārds", "", Type+"Surname", Surname, "text");
            person[2] = createField("Personas kods", "", Type+"ID", ID, "text");
            person[3] = createField("Dzīves vieta", "", Type+"Address", Address, "text");

            return person;
        }


        public FieldModel createField(string Label, string Unit, string Name, string Value = "", string Type = "number")
        {
            var newField = new FieldModel();
            newField.Label = Label;
            newField.Type = Type;
            newField.Unit = Unit;
            newField.Name = Name;
            newField.Value = Value;

            return newField;
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
            var defValue = "desmit";
            var addValue = "";
            switch (value)
            {
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
            else if( bigSum.Length == 2)
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
                newText = firstUpper + text.Substring(1, text.Length-1);
                
            }
            return newText + " un " + smallSum + " cent" + end;
        }
    }
}
