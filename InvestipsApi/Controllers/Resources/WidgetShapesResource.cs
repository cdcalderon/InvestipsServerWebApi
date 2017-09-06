using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApi.Controllers.Resources
{
    public class WidgetShapesResource
    {
        public WidgetShapesResource()
        {
            SinglePointShapes = new Collection<ShapeResource>();
            MultipointShapes = new Collection<MultipointShapeResource>();
        }
        public string Symbol { get; set; }
        public ICollection<ShapeResource> SinglePointShapes { get; set; }
        public ICollection<MultipointShapeResource> MultipointShapes { get; set; }
    }
}
