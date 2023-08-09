using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private readonly DataContext _context;
        public BikeController(DataContext context) { 
            _context = context;
        }

        // GET: api/<BikeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bike>>> Get()
        {
            var result = await _context.Bikes.ToListAsync();
            return Ok(result);
        }

        // POST api/<BikeController>
        [HttpPost]
        public async Task<ActionResult<Bike>> Post([FromBody] BaseBikeEntityDto bike)
        {
           try {

                Bike newBike = new Bike
                {
                    FrameSize = bike.FrameSize,
                    Manufacturer = bike.Manufacturer,
                    Model = bike.Model,
                    Price = bike.Price
                };

                await _context.Bikes.AddAsync(newBike);
                _context.SaveChanges();

                return Ok(newBike);

           } catch(Exception ex)
            {
                return BadRequest("Unable to add bike");
            }
        }

        // PUT api/<BikeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Bike>> Put(int id, [FromBody] BikeEntityDto bike)
        {
            try
            {

                var result = await _context.Bikes.SingleOrDefaultAsync(bEntity => bEntity.Id == id);
                if (result != null)
                {
                    result.Manufacturer = bike.Manufacturer;
                    result.Model = bike.Model;
                    result.FrameSize = bike.FrameSize;
                    result.Price = bike.Price;
                    _context.SaveChanges();

                    return Ok(result);
                }
                else
                {
                    return BadRequest("Update Failed");
                }

            } catch(Exception ex)
            {
                return BadRequest("Server Error");
            }
        }

        // DELETE api/<BikeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _context.Bikes.FirstAsync(bike => bike.Id == id);
            if (result != null)
            {
                _context.Bikes.Remove(result);
                _context.SaveChanges();
                return Ok();
            } else
            {
                return BadRequest("Delete failed");
            }

            
        }
    }
}
