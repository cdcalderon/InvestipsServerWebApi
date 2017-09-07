using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Investips.Core.Models
{
    public class WidgetShape
    {
        public int Id { get; set; }
        public Collection<WidgetShapePoint> WidgetShapePoints { get; set; }
        public string ShapeType { get; set; }
        public string Text { get; set; }

        public Security Security { get; set; }
        public int SecurityId { get; set; }
    }
}
