﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace MilkManagement.CommonLibrary.Functions
{
   public class MarketSellCalculate
    {
        public static (string morningsupply, string afternoonSupply) GetMorningSupplyAndAfterNoonSupply(
           string morningSupply,
           string afterNoonSupply,
           int morningMilkRate, int afternoonMilkRate)
        {
            string morningsupply = string.Empty,
                afternoonSupply = string.Empty;
            if (morningSupply.Contains("M") || morningSupply.Contains("m") ||
                morningSupply.Contains("Mund") || morningSupply.Contains("mund"))
            {
                decimal regex = (Convert.ToDecimal(Regex.Replace(morningSupply, "[^0-9.]+", string.Empty)));
                if (regex % 1 == 0)
                {
                    morningsupply =
                        (Convert.ToDouble(regex) * morningMilkRate)
                        .ToString(CultureInfo.CurrentCulture);
                }
                else if (regex % 1 != 0)
                {
                    var values = regex.ToString(CultureInfo.InvariantCulture).Split('.');
                    var firstValue = int.Parse(values[0]);
                    var secondValue = int.Parse(values[1]);
                    var cuttedValue = secondValue / 40;
                    var setup = secondValue % 40;
                    var add = cuttedValue + firstValue;
                    var result1 = Convert.ToDouble(add * morningMilkRate);

                    var result2 = setup * Convert.ToDouble(Convert.ToDecimal(morningMilkRate) / 40);
                    morningsupply = Convert.ToDouble(result1 + result2).ToString(CultureInfo.InvariantCulture);
                }

            }
            else if (morningSupply.Contains("KG") || morningSupply.Contains("kg") || morningSupply.Contains("Kg"))
            {

                morningsupply =
                    (Convert.ToDouble(Regex.Replace(morningSupply, "[^0-9]+", string.Empty)) * morningMilkRate / 40)
                    .ToString(CultureInfo.CurrentCulture);
            }

            if (afterNoonSupply.Contains("M") || afterNoonSupply.Contains("m") ||
                afterNoonSupply.Contains("Mund") || afterNoonSupply.Contains("mund"))
            {
                decimal regex = (Convert.ToDecimal(Regex.Replace(afterNoonSupply, "[^0-9.]+", string.Empty)));
                if (regex % 1 == 0)
                {
                    afternoonSupply =
                        (Convert.ToDouble(regex) * afternoonMilkRate)
                        .ToString(CultureInfo.CurrentCulture);
                }
                else if (regex % 1 != 0)
                {
                    var values = regex.ToString(CultureInfo.InvariantCulture).Split('.');
                    var firstValue = int.Parse(values[0]);
                    var secondValue = int.Parse(values[1]);
                    var cuttedValue = secondValue / 40;
                    var setup = secondValue % 40;
                    var add = cuttedValue + firstValue;
                    var result1 = add * afternoonMilkRate;
                    var result2 = setup * (Convert.ToDouble(afternoonMilkRate) / 40);
                    afternoonSupply = Convert.ToDouble(Convert.ToDouble(result1) + result2).ToString(CultureInfo.InvariantCulture);
                }

            }
            else if (afterNoonSupply.Contains("KG") || afterNoonSupply.Contains("kg") ||
                     afterNoonSupply.Contains("Kg"))
            {
                afternoonSupply =
                    (Convert.ToDouble(Regex.Replace(afterNoonSupply, "[^0-9]+", string.Empty)) * afternoonMilkRate / 40)
                    .ToString(CultureInfo.CurrentCulture);
            }
            return (morningsupply, afternoonSupply);
        }
    }
}
