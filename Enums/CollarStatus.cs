using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HalterExercise.Enums
{
    public enum CollarStatus
    {
        [Description("Heathy")]
        Heathy = 0,
        [Description("Broken")]
        Broken = 1
    }
}
