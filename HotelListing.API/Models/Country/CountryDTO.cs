﻿using HotelListing.API.Models.Hotel;

namespace HotelListing.API.Models.Country
{
    public class CountryDTO : BaseCountryDTO
    {
        public int Id { get; set; }        
        public List<HotelsDTO> Hotels { get; set; }
    }
}
