using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Investips.Core.Models;

namespace InvestipsApi.Controllers.Resources
{
    public class SaveSecurityResource
    {
        public int Id { get; set; }
        public string Symbol { get; set; }

        public Collection<WidgetShape> WidgetShapes { get; set; }
        public Collection<WidgetMultipointShape> WidgetMultipointShapes { get; set; }
    }
}
