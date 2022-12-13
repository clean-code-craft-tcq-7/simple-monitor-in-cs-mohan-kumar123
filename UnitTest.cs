using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment4
{
    public class UnitTest
    {
        public static void Test_Postive_Case_ofBattery()
        {
            Checker.ExpectedConditionOfBattery(Checker.batteryIsOk(25, 70, 0.7f), true); //Success
            Checker.ExpectedConditionOfBattery(Checker.batteryIsOk(26, 70, 0.7f), true); //Success
            Checker.ExpectedConditionOfBattery(Checker.batteryIsOk(26, 30, 0.7f), true); //Success
            Checker.ExpectedConditionOfBattery(Checker.batteryIsOk(26, 30, 0.5f), true); //Success

        }
        public static void Test_Negative_Case_OfBattery()
        {
            Checker.ExpectedConditionOfBattery(Checker.batteryIsOk(25, 70, 0.9f), false);//CR
            Checker.ExpectedConditionOfBattery(Checker.batteryIsOk(25, 19, 0.7f), false); //soc
            Checker.ExpectedConditionOfBattery(Checker.batteryIsOk(-1, 70, 0.7f), false);//temp
            Checker.ExpectedConditionOfBattery(Checker.batteryIsOk(50, 85, 0.0f), false);//temp
        }
    }
}
