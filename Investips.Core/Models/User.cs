using System;
using System.Collections.Generic;
using System.Text;

namespace Investips.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TradingProfileId { get; set; }
        public TradingProfile Profile { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
