using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly DataContext _context;
        public ManufacturerController(DataContext context) { 
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> Get()
        {
            var result = await _context.Manufacturers.ToListAsync();
            return Ok(result);
        }
    }
}
