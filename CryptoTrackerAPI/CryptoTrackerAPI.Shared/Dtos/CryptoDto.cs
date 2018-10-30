using System.Collections.Generic;

namespace CryptoTrackerAPI.Shared.Dtos
{
    public class CryptoDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public List<MarketDto> Markets { get; set; }
    }
}
