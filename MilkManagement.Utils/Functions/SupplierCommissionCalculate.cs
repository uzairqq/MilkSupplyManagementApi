using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace MilkManagement.CommonLibrary.Functions
{
   public class SupplierCommissionCalculate
    {
        public static int SupplierComissionCalulate(string morning,string afternoon,int comissionRate)
        {

            //Morning Milk
            var regexMorning = (Convert.ToDecimal(Regex.Replace(morning, "[^0-9.]+", string.Empty)));
            var morningMilk = regexMorning.ToString(CultureInfo.InvariantCulture).Split('.');
            var miltiplyMundValueMorning = 0;
            var addMundAndKgValueMorning = 0;
            if (morningMilk.Length != 1)
            {
                var multiplyKgValueMorning = 40 * Convert.ToInt32(comissionRate) /
                                             Convert.ToInt32(morningMilk[1]);

                var multiplyMundValueMorning = Convert.ToInt32(morningMilk[0]) * Convert.ToInt32(comissionRate);
                addMundAndKgValueMorning = multiplyKgValueMorning + multiplyMundValueMorning;
            }
            else
            {
                miltiplyMundValueMorning = Convert.ToInt32(comissionRate) * Convert.ToInt32(morningMilk[0]);
            }
            //Afternoon Milk
            var regexAfternoon = (Convert.ToDecimal(Regex.Replace(afternoon, "[^0-9.]+", string.Empty)));
            var afternoonMilk = regexAfternoon.ToString(CultureInfo.InvariantCulture).Split('.');

            var multiplyKgValueAfternoon = 0;
            var mutiplyMundValueMorning = 0;
            var multiplyMundValueAfternoon = 0;
            var addMundAndKgValueAfternoon = 0;
            if (afternoonMilk.Length != 1)
            {
                multiplyKgValueAfternoon =
                   40 * Convert.ToInt32(comissionRate) /
                   Convert.ToInt32(afternoonMilk[1]); // please this formula again
                multiplyMundValueAfternoon = Convert.ToInt32(afternoonMilk[0]) * Convert.ToInt32(comissionRate);
                addMundAndKgValueAfternoon = multiplyKgValueAfternoon + multiplyMundValueAfternoon;
            }
            else
            {
                mutiplyMundValueMorning = Convert.ToInt32(comissionRate) * Convert.ToInt32(afternoonMilk[0]);
            }

            //Total Calculations                                                                                                           
            var addMorningComissionAllUnits = addMundAndKgValueMorning + miltiplyMundValueMorning;
            var addAfternoonComissionAllUnits = addMundAndKgValueAfternoon + mutiplyMundValueMorning;
            var addAllComissionValues = addMorningComissionAllUnits + addAfternoonComissionAllUnits;
            return addAllComissionValues;
        }
    }
}
