using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Investips.Core.Models
{
    [Table("Portfolios")]
    public class Portfolio
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Comments { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<PortfolioSecurity> Securities { get; set; }
        public Portfolio()
        {
            Securities = new Collection<PortfolioSecurity>();
        }
    }
}
