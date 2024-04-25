using Microsoft.AspNetCore.Mvc;
using apiNetDonacionesEF.Models;
using apiNetDonacionesEF.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace apiNetDonacionesEF.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class DonanteController : ControllerBase
    {
    private readonly ILogger<DonanteController> _logger;
    private readonly DonacionesContext _context;

    public DonanteController(ILogger<DonanteController> logger, DonacionesContext context)
    {
        _logger = logger;
        _context = context; 
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Donante>>> Get()
    {
        return await _context.Donantes.ToListAsync();
    }

    // GET api/<DonanteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donante>> Get(int id)
        {
            
            var p = await _context.Donantes.FindAsync(id);
            
            if(p != null)
            {
                return p;
            }            
            else
            {
                return NotFound();
            }
        }

        // POST api/<DonanteController>
        [HttpPost]
        public async Task<ActionResult<Donante>> Post(Donante p)
        {
            _context.Add(p);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = p.DonanteId }, p);
            
        }

        // PUT api/<DonanteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Donante p, int id)
        {
            if (id != p.DonanteId)
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
                if (!DonanteExists(id))
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

        // DELETE api/<DonanteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var p = await _context.Donantes.FindAsync(id);
            if (p == null)
            {
                return NotFound();
            }

            _context.Donantes.Remove(p);
            await _context.SaveChangesAsync();

            return NoContent();

            
            
            
        }

         private bool DonanteExists(int id)
        {
            return _context.Donantes.Any(e => e.DonanteId == id);
        }
        
    }

