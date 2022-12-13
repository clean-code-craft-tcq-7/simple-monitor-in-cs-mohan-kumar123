using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment4
{
    public class Temperature : IRange
    {
        private readonly float _temp;
        public Temperature(float temp)
        {
            _temp = temp;
        }

        public bool CheckRange()
        {
            if (_temp < AppConstantRange.tempLowerRange || _temp > AppConstantRange.tempUpperRange)
            {
                string temp_writeLine = string.Empty;
                temp_writeLine.WriteLineForRange("Temperature");
                return false;
            }
            return true;
        }
    }
}
