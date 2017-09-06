using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Investips.Core.Models;

namespace InvestipsApi.Controllers.Resources
{
    public class MultipointShapeResource
    {
        public MultipointShapeResource()
        {
            ShapePoints = new Collection<WidgetShapePoint>();
        }
        public ICollection<WidgetShapePoint> ShapePoints { get; set; }
        public string ShapeType { get; set; }
    }
}
