using BatteryManamgement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BatteryManamgement.BMS;

namespace BatteryManamgement
{
    partial class BMS
    {
        
        static string generateBMS_printMessage(float value, float maxThreshold, float minThreshold, float warning_tolerance, BMS_KeyParams bmsCriteria, string userPreferredLanguage)
        {
           
            LanguageCheck languageCheck = new ConcreteLanguageValidator();
            ILanguage selectedLanguage = languageCheck.GetLanguage(userPreferredLanguage);


            var bmsWarningMessage = selectedLanguage.isValueinLowBreachRange(value, minThreshold);
            bmsWarningMessage = selectedLanguage.isValueinHighBreachRange(value, maxThreshold);
            bmsWarningMessage = selectedLanguage.isValueinLowWarningRange(value, minThreshold, warning_tolerance);
            bmsWarningMessage = selectedLanguage.isValueinHighWarningRange(value, maxThreshold, warning_tolerance);
            bmsWarningMessage = selectedLanguage.isValueinNormalRange();


            printBMS_ThresholdBreach(bmsWarningMessage, bmsCriteria);
            return bmsWarningMessage;

        }
        static void printBMS_ThresholdBreach(string bmsWarningMessage, BMS_KeyParams bmsCriteria)
        {
            Console.WriteLine(string.Concat(bmsCriteria, " : ", bmsWarningMessage));           
        }


    }
}
