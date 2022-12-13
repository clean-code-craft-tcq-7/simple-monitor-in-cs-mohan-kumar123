using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment4
{
    public class Soc : IRange
    {
        private readonly float _soc;
        public Soc(float soc)
        {
            _soc = soc;
        }

        public bool CheckRange()
        {
            if (_soc < AppConstantRange.socLowerRange || _soc > AppConstantRange.socUpperRange)
            {
                string soc_writeLine = string.Empty;
                soc_writeLine.WriteLineForRange("State of Charge");
                return false;
            }
            return true;
        }
    }
}
