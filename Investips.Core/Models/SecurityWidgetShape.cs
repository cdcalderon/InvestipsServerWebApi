using System;
using System.Collections.Generic;
using System.Text;

namespace Investips.Core.Models
{
    public class SecurityWidgetShape
    {
        public int SecurityId { get; set; }
        public int WidgetShapeId { get; set; }
        public Security Security { get; set; }
        public WidgetShape WidgetShape { get; set; }
    }
}
