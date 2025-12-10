using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHS_Validator.NHS.Regions
{
    public sealed class EnglandRegion : Region
    {
        public override bool ContainsNumber(string nhsNumber)
        {
            return nhsNumber.StartsWith("4") || nhsNumber.StartsWith("5");
        }
    }
}
