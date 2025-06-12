using HotelListing.API.Core.Models.Hotel;

namespace HotelListing.API.Core.Models.Country
{
    public class CountryDTO : BaseCountryDTO
    {
        public int Id { get; set; }        
        public List<HotelsDTO> Hotels { get; set; }
    }
}
