using System.ComponentModel;
namespace BatteryManamgement
{ 

    partial class BMS
    {

        public enum BMS_KeyParams
        {
            Temperature,
            State_of_Charge,
            Charge_Rate
        }
        public class Language
        {
            public const string EN = "EN" ;
            public const string DE = "DE";

            public enum BMS_WarningMessage
            {
                [Description("LOW_BREACH")]
                ENG_LOW_BREACH ,
                [Description("LOW_WARNING")]
                ENG_LOW_WARNING,
                [Description("HIGH_BREACH")]
                ENG_HIGH_BREACH,
                [Description("HIGH_WARNING")]
                ENG_HIGH_WARNING,
                [Description("NORMAL")]
                ENG_NORMAL,

                [Description("LOW_BREACH")]
                DE_LOW_BREACH,
                [Description("NIEDRIG_WARNUNG")]
                DE_LOW_WARNING,
                [Description("HIGH_BREACH")]
                DE_HIGH_BREACH,
                [Description("HIGH_WARNUNG")]
                DE_HIGH_WARNING,
                [Description("NORMAL")]
                DE_NORMAL,

            }

        }

    }
}


