using System.Diagnostics;
using static BMS;

namespace BatteryManamgement
{
    partial class BMS
    {
        public static void BMS_Test()
        {
            //Fail when Temp <0 >45 ; SOC <20 >80 ; CR > 0.8
            //Battery condition test
            string preferredLanguage = Language.DE;
            Debug.Assert(batteryIsOk(25, 70, 0.7f, preferredLanguage) == true); //Battery okay
            Debug.Assert(batteryIsOk(100, 60, 0.5f, preferredLanguage) == false);//Battery not okay - MaxTemp breached, SOC ok, CR ok
            Debug.Assert(batteryIsOk(-1, 60, 0.5f, preferredLanguage) == false);//Battery not okay - MinTemp breached, SOC ok, CR ok
            Debug.Assert(batteryIsOk(100, 85, 0.5f, preferredLanguage) == false);//Battery not okay - MaxTemp breached, MaxSOC breached, CR ok
            Debug.Assert(batteryIsOk(-1, 5, 0.5f, preferredLanguage) == false);//Battery not okay - MinTemp breached, MinSOC breached, CR ok
            Debug.Assert(batteryIsOk(100, 50, 1f, preferredLanguage) == false);//Battery not okay - MaxTemp breached, SOC ok, MaxCR breached
            Debug.Assert(batteryIsOk(-1, 30, 2.5f, preferredLanguage) == false);//Battery not okay - MinTemp breached, SOC ok, MaxCR breached
            Debug.Assert(batteryIsOk(90, 90, 0.9f, preferredLanguage) == false);//Battery not okay - Temp, SOC, Charge rate breached

            Debug.Assert(batteryIsOk(45, 85, 0.1f, preferredLanguage) == false);//Battery not okay - Temp ok, MaxSOC breached, CR ok
            Debug.Assert(batteryIsOk(30, 5, 0.79f, preferredLanguage) == false);//Battery not okay - Temp ok, MinSOC breached, CR high warning
            Debug.Assert(batteryIsOk(45, 85, 1.1f, preferredLanguage) == false);//Battery not okay - Temp high warning, MaxSOC breached, MaxCR breached
            Debug.Assert(batteryIsOk(30, 5, 1.01f, preferredLanguage) == false);//Battery not okay - Temp ok, MinSOC breached, MaxCR breached
            Debug.Assert(batteryIsOk(0, 79, 0.9f, preferredLanguage) == false);//Battery not okay - Temp low warning, SOC high warning, MaxCharge rate breached



            //Temperature test
            Debug.Assert(isTemperatureValid(BMS_Threshold.TemperatureMin) == true);//Temp = minthreshold
            Debug.Assert(isTemperatureValid(BMS_Threshold.TemperatureMax) == true);//Temp = maxthreshold
            Debug.Assert(isTemperatureValid(BMS_Threshold.TemperatureMin - 0.1f) == false);//Temp < minthreshold
            Debug.Assert(isTemperatureValid(BMS_Threshold.TemperatureMax + 5f) == false);//Temp > maxthreshold

            //SOC test
            Debug.Assert(isSOCValid(BMS_Threshold.SocMin) == true);     //SOC = minthreshold
            Debug.Assert(isSOCValid(BMS_Threshold.SocMax) == true);    //SOC = maxthreshold
            Debug.Assert(isSOCValid(BMS_Threshold.SocMin - 5f) == false); //SOC < minthreshold
            Debug.Assert(isSOCValid(BMS_Threshold.SocMax + 5f) == false);//SOC > maxthreshold

            //Charge Rate test
            Debug.Assert(isChargeRateValid(BMS_Threshold.ChargeRateMax) == true);     //ChargeRate = minthreshold
            Debug.Assert(isChargeRateValid(BMS_Threshold.ChargeRateMax - 5f) == true); //ChargeRate < minthreshold
            Debug.Assert(isChargeRateValid(BMS_Threshold.ChargeRateMax + 5f) == false);//ChargeRate > maxthreshold

        }
    }
}
