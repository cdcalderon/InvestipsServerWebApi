using System;
using System.Collections.Generic;
using System.Text;

namespace Investips.Core.Models
{
    public class SecurityWidgetMultipointShape
    {
        public int SecurityId { get; set; }
        public int WidgetMultipointShapeId { get; set; }
        public Security Security { get; set; }
        public WidgetMultipointShape WidgetMultipointShape { get; set; }
    }
}

