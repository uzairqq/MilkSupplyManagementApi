using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace MilkManagement.CommonLibrary.Functions
{
   public class TotalMilkCalculate
    {
        public static string TotalMilkCalulate(string morning,string afternoon)
        {

            var regexMorning = (Convert.ToDecimal(Regex.Replace(morning, "[^0-9.]+", string.Empty)));
            var morningMilkSplit = regexMorning.ToString(CultureInfo.InvariantCulture).Split('.');
            var morningMilkMund = Convert.ToInt32(morningMilkSplit[0]);
            var morningMilkKg = 0;
            if (morningMilkSplit.Length != 1)
            {
                morningMilkKg = Convert.ToInt32(morningMilkSplit[1]);
            }


            var regexAfternoon = (Convert.ToDecimal(Regex.Replace(afternoon, "[^0-9.]+", string.Empty)));
            var afternoonMilkSplit = regexAfternoon.ToString(CultureInfo.InvariantCulture).Split('.');
            var afternoonMilkMund = Convert.ToInt32(afternoonMilkSplit[0]);
            var afternoonMilkKg = 0;
            if (afternoonMilkSplit.Length != 1)
            {
                afternoonMilkKg = Convert.ToInt32(afternoonMilkSplit[1]);
            }


            var mundUnitSum = Convert.ToInt32(morningMilkMund) + Convert.ToInt32(afternoonMilkMund);
            var kgUnitSum = 0;
            if (morningMilkKg != 0 || afternoonMilkKg != 0)
            {
                kgUnitSum = morningMilkKg + afternoonMilkKg;
            }

            var grandMilkTotal = mundUnitSum + "." + kgUnitSum;
            return grandMilkTotal;
        }

    }
}
