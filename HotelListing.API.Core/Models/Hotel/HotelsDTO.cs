using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.Core.Models.Hotel
{
    public class HotelsDTO : BaseHotelDTO
    {
        public int Id { get; set; }
    }
}