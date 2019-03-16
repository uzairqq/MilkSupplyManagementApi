using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace MilkManagement.CommonLibrary.Functions
{
    public class SupplierSuppliedCalculationFunction
    {
        public static (string morningPurchase, string afternoonPurchase) GetMorningSupplyAndAfterNoonSupply(
            string morningPurchase,
            string afterNoonPurchase,
            int customerCurrentRate)
        {
            string morningsupply = string.Empty,
                afternoonSupply = string.Empty;
            if (morningPurchase.Contains("M") || morningPurchase.Contains("m") ||
                morningPurchase.Contains("Mund") || morningPurchase.Contains("mund"))
            {
                decimal regex = (Convert.ToDecimal(Regex.Replace(morningPurchase, "[^0-9.]+", string.Empty)));
                if (regex % 1 == 0)
                {
                    morningsupply =
                        (Convert.ToDouble(regex) * customerCurrentRate)
                        .ToString(CultureInfo.CurrentCulture);
                }
                else if (regex % 1 != 0)
                {
                    var values = regex.ToString(CultureInfo.InvariantCulture).Split('.');
                    var firstValue = int.Parse(values[0]);
                    var secondValue = int.Parse(values[1]);
                    var firstValueMultiply = firstValue * customerCurrentRate;
                    var secondValueCutted = Convert.ToDecimal(customerCurrentRate) / 40;

                    var secondValueMultiply = secondValueCutted * secondValue;//convert to int 
                    var sumOfBoth = firstValueMultiply + secondValueMultiply;
                    morningsupply = sumOfBoth.ToString(CultureInfo.InvariantCulture);
                    //var cuttedValue = secondValue / 40;
                    //var setup = secondValue % 40;
                    //var add = cuttedValue + firstValue;
                    //var result1 = (add * 40) * customerCurrentRate;
                    //var result2 = setup * customerCurrentRate;
                    //morningsupply = Convert.ToInt32(result1 + result2).ToString();
                }

            }
            else if (morningPurchase.Contains("KG") || morningPurchase.Contains("kg") || morningPurchase.Contains("Kg"))
            {
                var currentRate = Convert.ToDecimal(customerCurrentRate) / 40;
                var morningRegex = Regex.Replace(morningPurchase, "[^0-9]+", string.Empty);
                var result = Convert.ToInt32(currentRate * Convert.ToInt32(morningRegex));
                morningsupply = result.ToString();

                //morningsupply =
                //    (Convert.ToDouble(Regex.Replace(morningPurchase, "[^0-9]+", string.Empty)) * Convert.ToDouble(currentRate.ToString()))
                //    .ToString(CultureInfo.CurrentCulture);// for future direct use // to implement short code 
            }

            if (afterNoonPurchase.Contains("M") || afterNoonPurchase.Contains("m") ||
                afterNoonPurchase.Contains("Mund") || afterNoonPurchase.Contains("mund"))
            {
                decimal regex = (Convert.ToDecimal(Regex.Replace(afterNoonPurchase, "[^0-9.]+", string.Empty)));
                if (regex % 1 == 0)
                {
                    afternoonSupply =
                        (Convert.ToDouble(regex) * customerCurrentRate)
                        .ToString(CultureInfo.CurrentCulture);
                }
                else if (regex % 1 != 0)
                {
                    var values = regex.ToString(CultureInfo.InvariantCulture).Split('.');
                    var firstValue = int.Parse(values[0]);
                    var secondValue = int.Parse(values[1]);
                    var firstValueMultiply = firstValue * customerCurrentRate;
                    var secondValueCutted = Convert.ToDecimal(customerCurrentRate) / 40;
                    var secondValueMultiply = secondValueCutted * secondValue;
                    var sumOfBoth = firstValueMultiply + secondValueMultiply;
                    afternoonSupply = sumOfBoth.ToString(CultureInfo.InvariantCulture);

                    //var cuttedValue = secondValue / 40;
                    //var setup = secondValue % 40;
                    //var add = cuttedValue + firstValue;
                    //var result1 = (add * 40) * customerCurrentRate;
                    //var result2 = setup * customerCurrentRate;
                    //afternoonSupply = Convert.ToInt32(result1 + result2).ToString();  // If Wanted Then we can comment then out a/c to requirments
                }

            }
            else if (afterNoonPurchase.Contains("KG") || afterNoonPurchase.Contains("kg") ||
                     afterNoonPurchase.Contains("Kg"))
            {
                var currentRate = Convert.ToDecimal(customerCurrentRate) / 40;
                var afternoonRegex = Regex.Replace(afterNoonPurchase, "[^0-9]+", string.Empty);
                var result = Convert.ToInt32(currentRate * Convert.ToInt32(afternoonRegex));
                afternoonSupply = result.ToString();

                //afternoonSupply =
                //    (Convert.ToDouble(Regex.Replace(afterNoonPurchase, "[^0-9]+", string.Empty)) * (customerCurrentRate/40))
                //    .ToString(CultureInfo.CurrentCulture);
            }
            return (morningsupply, afternoonSupply);
        }
    }
}
