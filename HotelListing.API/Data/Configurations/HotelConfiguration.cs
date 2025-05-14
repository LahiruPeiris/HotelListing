using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HotelListing.API.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Hotel California",
                    Address = "123 Main St, Los Angeles, CA",
                    Rating = 4.5,
                    CountryId = 1
                },
                new Hotel
                {
                    Id = 2,
                    Name = "The Ritz London",
                    Address = "150 Piccadilly, London W1J 9BR, UK",
                    Rating = 5.0,
                    CountryId = 2
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Fairmont Banff Springs",
                    Address = "405 Spray Ave, Banff, AB T1L 1J4, Canada",
                    Rating = 4.8,
                    CountryId = 3
                },
                new Hotel
                {
                    Id = 4,
                    Name = "Sydney Opera House Hotel",
                    Address = "Bennelong Point, Sydney NSW 2000, Australia",
                    Rating = 4.7,
                    CountryId = 4
                },
                new Hotel
                {
                    Id = 5,
                    Name = "Hotel Adlon Kempinski",
                    Address = "Unter den Linden 77, 10117 Berlin, Germany",
                    Rating = 4.9,
                    CountryId = 5
                },
                new Hotel
                {
                    Id = 6,
                    Name = "Le Meurice",
                    Address = "228 Rue de Rivoli, 75001 Paris, France",
                    Rating = 4.6,
                    CountryId = 6
                },
                new Hotel
                {
                    Id = 7,
                    Name = "Hotel Danieli",
                    Address = "Riva degli Schiavoni, 4196, 30122 Venezia VE, Italy",
                    Rating = 4.8,
                    CountryId = 7
                }
            );
        }
    }
}
