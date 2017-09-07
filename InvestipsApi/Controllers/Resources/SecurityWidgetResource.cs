using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Investips.Core.Models;

namespace InvestipsApi.Controllers.Resources
{
    public class SecurityWidgetResource
    {
        public SecurityWidgetResource()
        {
            WidgetShapes = new Collection<WidgetShapeResource>();
        }
        public string Symbol { get; set; }
        public Collection<WidgetShapeResource> WidgetShapes { get; set; }
    }
}
