using System;
using System.Collections.Generic;
using System.Text;

namespace Investips.Core.Models
{
    public class ShapeDefinition
    {
        public int Id { get; set; }
        public string Shape { get; set; }
        public bool Lock { get; set; }
        public bool DisableSelection { get; set; }
        public bool DisableSave { get; set; }
        public bool DisableUndo { get; set; }
        public string ZOrder { get; set; }
        public string Text { get; set; }
        public WidgetShapeOverrides Overrides { get; set; }
    }
}
