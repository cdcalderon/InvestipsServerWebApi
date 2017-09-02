using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Investips.Core.Models
{
    public class WidgetShape
    {
        public int Id { get; set; }
        public WidgetShapePoint ShapePoint { get; set; }
        public ShapeDefinition ShapeDefinition { get; set; }
    }
}
