using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelListing.API.Core.Contracts;
using HotelListing.API.Core.Exceptions;
using HotelListing.API.Core.Models.Country;
using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Core.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListingDbContext _context;
        private readonly IMapper mapper;

        public CountriesRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }

        public async Task<CountryDTO> GetDetails(int id)
        {
            var country = await _context.Countries
                .Include(c => c.Hotels)
                .ProjectTo<CountryDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                throw new NotFoundException(nameof(Country), id);
            }

            return country;
        }

        Task<Country> ICountriesRepository.GetDetails(int id)
        {
            throw new NotImplementedException();
        }
    }

}
