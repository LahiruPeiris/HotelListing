using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Core.Models.Country;
using AutoMapper;
using HotelListing.API.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using HotelListing.API.Core.Models;
using Microsoft.AspNetCore.OData.Query;

namespace HotelListing.API.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;
        private readonly ILogger<CountriesController> _logger;

        public CountriesController(IMapper mapper, ICountriesRepository countriesRepository, ILogger<CountriesController> logger)
        {
            this._countriesRepository = countriesRepository;
            this._logger = logger;
            _mapper = mapper;
        }

        // GET: api/Countries
        [HttpGet("GetAll")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<GetCountryDTO>>> GetCountries()
        {
            //var countries = await _countriesRepository.GetAllAsync();
            //var records = _mapper.Map<List<GetCountryDTO>>(countries);
            var countries = await _countriesRepository.GetAllAsync<GetCountryDTO>();
            return Ok(countries);
        }

        // GET: api/Countries/?StartIndex=0&PageSize=10&PageNumber=1
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<PageResult<GetCountryDTO>>> GetPagedCountries([FromQuery] QueryParameters queryParameters)
        {
            var pagedCountryResults = await _countriesRepository.GetAllAsync<GetCountryDTO>(queryParameters);
            // var records = _mapper.Map<List<GetCountryDTO>>(countries);
            return Ok(pagedCountryResults);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDTO>> GetCountry(int id)
        {
            //var country = _countriesRepository.GetDetails(id);

            //if (country == null)
            //{
            //    _logger.LogWarning($"Country with id {id} was not found in the database.");
            //    return NotFound();
            //}

            //var record = _mapper.Map<CountryDTO>(country);
            //return Ok(record);

            var country = await _countriesRepository.GetDetails(id);
            return Ok(country);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDTO updateCountry)
        {
            if (id != updateCountry.Id)
            {
                return BadRequest("Invalid Record Id");
            }


            try
            {
                await _countriesRepository.UpdateAsync(id, updateCountry);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CountryDTO>> PostCountry(CreateCountryDTO createCountry)
        {

            //var country = _mapper.Map<Country>(createCountry);

            //await _countriesRepository.AddAsync(country);

            var country = await _countriesRepository.AddAsync<CreateCountryDTO, CountryDTO>(createCountry);

            return CreatedAtAction(nameof(GetCountry), new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Adminstrator")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            //var country = await _countriesRepository.GetAsync(id);
            //if (country == null)
            //{
            //    return NotFound();
            //}

           await _countriesRepository.DeleteAsync(id);

           return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}
