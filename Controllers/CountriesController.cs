using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookWebAPI.Data;
using BookWebAPI.DTOs;
using BookWebAPI.Models;
using AutoMapper;

namespace BookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CountriesController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> GetCountry()
        {
            var countries = await _context.Country.ToListAsync();
            var countryDTOs = _mapper.Map<List<CountryDTO>>(countries);
            return countryDTOs;
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
       public async Task<ActionResult<CountryDTO>> GetCountry(int id)
       {
            var country = await _context.Country.FindAsync(id);

           if (country == null)
           {
             return NotFound();
           }

        var countryDTO = _mapper.Map<CountryDTO>(country);
        return countryDTO;
       }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, CountryDTO countryDTO)
        {
            if (id != countryDTO.Id)
            {
                return BadRequest();
            }

            var existingCountry = await _context.Country.FirstOrDefaultAsync(c => c.Id == id);

            if (existingCountry == null)
            {
                return NotFound();
            }

            _mapper.Map(countryDTO, existingCountry);
            _context.Entry(existingCountry).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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
        public async Task<ActionResult<CountryDTO>> PostCountry(CountryDTO countryDTO)
        {
            var country = _mapper.Map<Country>(countryDTO);
            _context.Country.Add(country);
            await _context.SaveChangesAsync();

            // Map the created Country entity back to CountryDTO to return it in the response.
            var createdCountryDTO = _mapper.Map<CountryDTO>(country);
            return CreatedAtAction("GetCountry", new { id = country.Id }, createdCountryDTO);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (_context.Country == null)
            {
                return NotFound();
            }
            var country = await _context.Country.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Country.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return (_context.Country?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
