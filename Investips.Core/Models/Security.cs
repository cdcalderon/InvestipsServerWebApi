using System.ComponentModel.DataAnnotations;

namespace Investips.Core.Models
{
    public class Security
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Symbol { get; set; }
    }
}
