using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment4
{
    public class ChargeRate : IRange
    {
        private readonly float _chargeRate;
        public ChargeRate(float chargeRate)
        {
            _chargeRate = chargeRate;
        }
        public bool CheckRange()
        {
            if (_chargeRate > AppConstantRange.chargeRateUpperRange)
            {
                string c_Rate_writeLine = string.Empty;
                c_Rate_writeLine.WriteLineForRange("Charge Rate");
                return false;
            }
            return true;
        }
    }
}
