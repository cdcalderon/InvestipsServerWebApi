using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Investips.Core.Models
{
    public class Security
    {
        public Security()
        {
            WidgetShapes = new Collection<SecurityWidgetShape>();
            WidgetMultipointShapes = new List<SecurityWidgetMultipointShape>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Symbol { get; set; }
        public DateTime? LastUpdate { get; set; }

        public ICollection<SecurityWidgetShape> WidgetShapes { get; set; }
        public ICollection<SecurityWidgetMultipointShape> WidgetMultipointShapes { get; set; }

    }
}
