using System;
using System.Collections.Generic;
using System.Text;

namespace Investips.Core.Models
{
    public class Chart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Symbol { get; set; }
        public string Resolution { get; set; }
        public DateTime LastUpdate { get; set; }
        
    }
}
