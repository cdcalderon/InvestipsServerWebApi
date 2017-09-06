using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investips.Core.Models;

namespace InvestipsApi.Controllers.Resources
{
    public class ShapeResource
    {
        public WidgetShapePoint ShapePoint { get; set; }
        public string ShapeType { get; set; }
    }
}
