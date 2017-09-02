using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Investips.Core.Models
{
    public class WidgetMultipointShape
    {
        public Collection<WidgetShapePoint> WidgetShapePoints { get; set; }
        public ShapeDefinition ShapeDefinition { get; set; }
    }
}
