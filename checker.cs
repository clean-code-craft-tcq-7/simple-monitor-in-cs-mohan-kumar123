using System;
using System.Diagnostics;
namespace Assignment4
{
    public class Checker
    {
        private static IRange range;
        public static bool batteryIsOk(float temperature, float soc, float chargeRate)
        {
            return (CheckTemperatureRange(temperature) && CheckSocRange(soc) && CheckChargeRateRange(chargeRate));
        }

        static bool CheckTemperatureRange(float temperature)
        {
            range = new Temperature(temperature);
            bool IsTempInRange = range.CheckRange();
            return IsTempInRange;
        }

        static bool CheckSocRange(float soc)
        {
            range = new Soc(soc);
            bool IsSocInRange = range.CheckRange();
            return IsSocInRange;
        }

        static bool CheckChargeRateRange(float chargeRate)
        {
            range = new ChargeRate(chargeRate);
            bool IsChargeRateInRange = range.CheckRange();
            return IsChargeRateInRange;
        }

        /// <summary>
        /// expectedBatterycond is true when actualBatteryCond is true
        /// expectedBatterycond is false when actualBatteryCond is false
        /// </summary>
        /// <param name="actualBatteryCond">true/false</param>
        /// <param name="expectedBatterycond">true/false</param>
        public static void ExpectedConditionOfBattery(bool actualBatteryCond, bool expectedBatterycond)
        {
            if (actualBatteryCond != expectedBatterycond)
            {
                Console.WriteLine("Expected {0}, but got {1}", expectedBatterycond, actualBatteryCond);
                Environment.Exit(1);
            }
        }

        static int Main()
        {
            ExpectedConditionOfBattery(batteryIsOk(25, 70, 0.7f), true);
            ExpectedConditionOfBattery(batteryIsOk(50, 85, 0.0f), false);
            ExpectedConditionOfBattery(batteryIsOk(50, 85, 0.9f), false);
            Console.WriteLine("All ok");
            return 0;
        }
    }
}