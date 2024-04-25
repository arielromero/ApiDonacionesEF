using Microsoft.AspNetCore.Mvc;
using apiNetDonacionesEF.Models;
using apiNetDonacionesEF.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace apiNetDonaciones.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class DonacionController : ControllerBase
    {
      private readonly ILogger<DonacionController> _logger;
    private readonly DonacionesContext _context;

    public DonacionController(ILogger<DonacionController> logger, DonacionesContext context)
    {
        _logger = logger;
        _context = context; 
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Donacion>>> Get()
    {
        return await _context.Donaciones.ToListAsync();
    }

    // GET api/<DonacionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donacion>> Get(int id)
        {
            
            var p = await _context.Donaciones.FindAsync(id);
            
            if(p != null)
            {
                return p;
            }            
            else
            {
                return NotFound();
            }
        }

        // POST api/<DonacionController>
        [HttpPost]
        public async Task<ActionResult<Donacion>> Post(Donacion p)
        {
            _context.Add(p);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = p.DonacionId }, p);
            
        }

        // PUT api/<DonacionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Donacion p, int id)
        {
            if (id != p.DonacionId)
            {
                return BadRequest();
            }

            _context.Entry(p).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonacionExists(id))
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

        // DELETE api/<DonacionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var p = await _context.Donaciones.FindAsync(id);
            if (p == null)
            {
                return NotFound();
            }

            _context.Donaciones.Remove(p);
            await _context.SaveChangesAsync();

            return NoContent();

            
            
            
        }

         private bool DonacionExists(int id)
        {
            return _context.Donaciones.Any(e => e.DonacionId == id);
        } 
    }
