using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Investips.Core.Models;

namespace InvestipsApi.Controllers.Resources
{
    public class WidgetShapeResource
    {
        public Collection<WidgetShapePointResource> ShapePoints { get; set; }
        public string ShapeType { get; set; }
        public string Text { get; set; }
    }
}
