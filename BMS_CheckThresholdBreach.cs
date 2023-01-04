using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static BatteryManamgement.BMS;
using static BMS;

namespace BatteryManamgement
{
 
    partial class BMS
    {
        public static bool trackBreach = false;
        public static string bmsWarningMessage = string.Empty;
        public static string userPreferredLanguage = Language.EN;

        static float find_WarningTolerance(float maxThreshold)
        {
            float Tolerance = ((5f / 100f) * maxThreshold);
            return Tolerance;
        }


        //Temp, SOC and Charge rate checks whether the value is under limit (same functionality for different criteria)
        //Avoid duplication - functions that do nearly the same thing by segregating the generic approach
        static bool isUnderLimit(BMS_KeyParams bmsCriteria, float value, float maxThreshold, float minThreshold = float.NegativeInfinity)
        {
            float ToleranceValue = find_WarningTolerance(maxThreshold);
            bmsWarningMessage = generateBMS_printMessage(value, maxThreshold, minThreshold, ToleranceValue, bmsCriteria, userPreferredLanguage);
            
            if (value < minThreshold || value > maxThreshold)
            {
                return false;
            }
            else
                return true;
        }
        //Check whether Temperature is under limit
        static bool isTemperatureValid(float value)
        {
            return isUnderLimit(BMS_KeyParams.Temperature, value, BMS_Threshold.TemperatureMax, BMS_Threshold.TemperatureMin);
        }
        //Check whether SOC is under limit
        static bool isSOCValid(float value)
        {
            return isUnderLimit(BMS_KeyParams.State_of_Charge, value, BMS_Threshold.SocMax, BMS_Threshold.SocMin);
        }
        //Check whether Charge Rate is under limit
        static bool isChargeRateValid(float value)
        {
            return isUnderLimit(BMS_KeyParams.Charge_Rate, value, BMS_Threshold.ChargeRateMax);
        }
        //Check whether Battery condition is safe
        static bool batteryIsOk(float tempValue, float socValue, float chargerateValue, string preferredLanguage)
        {
            userPreferredLanguage = preferredLanguage;
            bool isTemperatureUnderRange = isTemperatureValid(tempValue);
            bool isSOCUnderRange = isSOCValid(socValue);
            bool isChargeRateUnderRange = isChargeRateValid(chargerateValue);
            Console.WriteLine("***");
            return isTemperatureUnderRange && isSOCUnderRange && isChargeRateUnderRange;
        }


    }


    /// <summary>
    /// To Map the Enum value with Description
    /// </summary>
    public static class DescriptionExtensions
    {
        public static string GetDescriptionValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            DescriptionAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].Description : null;
        }
    }

    /// <summary>
    /// The 'Language' interface
    /// </summary>
    public interface ILanguage
    {

        string isValueinLowBreachRange(float value, float minThreshold = float.NegativeInfinity);

        string isValueinHighBreachRange(float value, float maxThreshold);

        string isValueinLowWarningRange(float value, float minThreshold, float warning_tolerance);

        string isValueinHighWarningRange(float value, float maxThreshold, float warning_tolerance);

        string isValueinNormalRange();

    }

    /// <summary>
    /// A 'ConcreteLanguage' class for English
    /// </summary>
    public class English : ILanguage
    {
        public static bool trackBreach = false;
        public static string bmsWarningMessage = string.Empty;
        public string isValueinLowBreachRange(float value, float minThreshold = float.NegativeInfinity)
        {
            trackBreach = false;
            //Language.BMS_WarningMessage bmsWarningMessage = new Language.BMS_WarningMessage();
            if (value < minThreshold)
            {
                ////low_breach
                bmsWarningMessage = string.Empty;
                bmsWarningMessage = Language.BMS_WarningMessage.ENG_LOW_BREACH.GetDescriptionValue();
                trackBreach = true;
            }
            return bmsWarningMessage;
        }
        public string isValueinHighBreachRange(float value, float maxThreshold)
        {

            if (value > maxThreshold && !trackBreach)
            {
                bmsWarningMessage = string.Empty;
                bmsWarningMessage = Language.BMS_WarningMessage.ENG_HIGH_BREACH.GetDescriptionValue();
                trackBreach = true;

            }
            return bmsWarningMessage;
        }
        public string isValueinLowWarningRange(float value, float minThreshold, float warning_tolerance)
        {

            if (value >= minThreshold && value <= minThreshold + warning_tolerance)
            {
                //low_warnin g Warning : Approaching discharge
                bmsWarningMessage = string.Empty;
                bmsWarningMessage = Language.BMS_WarningMessage.ENG_LOW_WARNING.GetDescriptionValue();
                trackBreach = true;

            }
            return bmsWarningMessage;
        }
        public string isValueinHighWarningRange(float value, float maxThreshold, float warning_tolerance)
        {
            if (value <= maxThreshold && value >= maxThreshold - warning_tolerance)
            {
                //high warning  Warning : Approaching charge peak
                bmsWarningMessage = string.Empty;
                bmsWarningMessage = Language.BMS_WarningMessage.ENG_HIGH_WARNING.GetDescriptionValue();
                trackBreach = true;
            }
            return bmsWarningMessage;
        }
        public string isValueinNormalRange()
        {
            if (!trackBreach)
            {
                ////low_breach
                bmsWarningMessage = string.Empty;
                bmsWarningMessage = Language.BMS_WarningMessage.ENG_NORMAL.GetDescriptionValue();

            }
            return bmsWarningMessage;
        }
    }

    /// <summary>
    /// A 'ConcreteLanguage' class for German
    /// </summary>
    public class German : ILanguage
    {
        public static bool trackBreach = false;
        public static string bmsWarningMessage = string.Empty;
        public string isValueinLowBreachRange(float value, float minThreshold = float.NegativeInfinity)
        {
            trackBreach = false;
            //Language.BMS_WarningMessage bmsWarningMessage = new Language.BMS_WarningMessage();
            if (value < minThreshold)
            {
                ////low_breach
                bmsWarningMessage = string.Empty;
                bmsWarningMessage = Language.BMS_WarningMessage.DE_LOW_BREACH.GetDescriptionValue();
                trackBreach = true;
            }
            return bmsWarningMessage;
        }
        public string isValueinHighBreachRange(float value, float maxThreshold)
        {

            if (value > maxThreshold && !trackBreach)
            {
                bmsWarningMessage = string.Empty;
                bmsWarningMessage = Language.BMS_WarningMessage.DE_HIGH_BREACH.GetDescriptionValue();
                trackBreach = true;

            }
            return bmsWarningMessage;
        }
        public string isValueinLowWarningRange(float value, float minThreshold, float warning_tolerance)
        {

            if (value >= minThreshold && value <= minThreshold + warning_tolerance)
            {
                //low_warnin g Warning : Approaching discharge
                bmsWarningMessage = string.Empty;
                bmsWarningMessage = Language.BMS_WarningMessage.DE_LOW_WARNING.GetDescriptionValue();
                trackBreach = true;

            }
            return bmsWarningMessage;
        }
        public string isValueinHighWarningRange(float value, float maxThreshold, float warning_tolerance)
        {
            if (value <= maxThreshold && value >= maxThreshold - warning_tolerance)
            {
                //high warning  Warning : Approaching charge peak
                bmsWarningMessage = string.Empty;
                bmsWarningMessage = Language.BMS_WarningMessage.DE_HIGH_WARNING.GetDescriptionValue();
                trackBreach = true;
            }
            return bmsWarningMessage;
        }
        public string isValueinNormalRange()
        {
            if (!trackBreach)
            {
                ////low_breach
                bmsWarningMessage = string.Empty;
                bmsWarningMessage = Language.BMS_WarningMessage.DE_NORMAL.GetDescriptionValue();

            }
            return bmsWarningMessage;
        }
    }

    /// <summary>
    /// The LanguageCheck Abstract Class
    /// </summary>
    public abstract class LanguageCheck
    {
        public abstract ILanguage GetLanguage(string Language);

    }

    /// <summary>
    /// A 'ConcreteLanguageValidator' class
    /// </summary>
    public class ConcreteLanguageValidator : LanguageCheck
    {
        public override ILanguage GetLanguage(string Language)
        {
            switch (Language)
            {
                case "EN":
                    return new English();
                case "DE":
                    return new German();
                default:
                    throw new ApplicationException(string.Format("Language '{0}' warnings cannot be displayed. Kindly make Language configurations !", Language));
            }
        }

    }
}
















