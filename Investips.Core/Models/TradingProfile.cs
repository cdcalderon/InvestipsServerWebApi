using System;
using System.Collections.Generic;
using System.Text;

namespace Investips.Core.Models
{
    public class TradingProfile
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int TradingExperience { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
