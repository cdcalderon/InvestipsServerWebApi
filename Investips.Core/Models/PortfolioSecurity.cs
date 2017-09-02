namespace Investips.Core.Models
{
    public class PortfolioSecurity
    {
        public int PortfolioId { get; set; }
        public int SecurityId { get; set; }
        public Portfolio Portfolio { get; set; }
        public Security Security { get; set; }
    }
}
