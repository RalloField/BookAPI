using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookWebAPI.Data;
using BookWebAPI.Models;
using BookWebAPI.DTOs;
using AutoMapper;
using System.Data.Common;

namespace BookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ShopsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Shops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopsDTO>>> GetShops()
        {
            var shops = await _context.Shops.ToListAsync();
            var shopDTOs = _mapper.Map<List<ShopsDTO>>(shops);
            return shopDTOs;
        }

        // GET: api/Shops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopsDTO>> GetShop(int id)
        {
            var shop = await _context.Shops.FindAsync(id);
          
            if (shop == null)
          {
              return NotFound();
          }
            var shopDTO = _mapper.Map<ShopsDTO>(shop);
            return shopDTO;
        }

        // PUT: api/Shops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShop(int id, ShopsDTO shopDTO)
        {
            var shop = await _context.Shops.FindAsync(id);

            if (shop == null)
            {
                return NotFound();
            }

            _mapper.Map(shopDTO, shop);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopExists(id))
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

        // POST: api/Shops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopsDTO>> PostShop(ShopsDTO shopDTO)
        {
            var shop = _mapper.Map<Shop>(shopDTO);
            _context.Shops.Add(shop);
            await _context.SaveChangesAsync();

            var createdShopDTO = _mapper.Map<ShopsDTO>(shop);
            return CreatedAtAction("GetShop", new { id = shop.Id }, createdShopDTO);
        }

        // DELETE: api/Shops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(int id)
        {
            if (_context.Shops == null)
            {
                return NotFound();
            }
            var shop = await _context.Shops.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }

            _context.Shops.Remove(shop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShopExists(int id)
        {
            return (_context.Shops?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
