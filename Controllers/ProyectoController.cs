using Microsoft.AspNetCore.Mvc;
using apiNetDonacionesEF.Models;
using apiNetDonacionesEF.Context;
using Microsoft.EntityFrameworkCore;
namespace apiNetDonaciones.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProyectoController : ControllerBase
{
 

    private readonly ILogger<ProyectoController> _logger;
    private readonly DonacionesContext _context;

    public ProyectoController(ILogger<ProyectoController> logger, DonacionesContext context)
    {
        _logger = logger;
        _context = context; 
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Proyecto>>> Get()
    {
        return await _context.Proyectos.ToListAsync();
    }

    // GET api/<ProyectoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> Get(int id)
        {
            
            var p = await _context.Proyectos.FindAsync(id);
            
            if(p != null)
            {
                return p;
            }            
            else
            {
                return NotFound();
            }
        }

        // POST api/<ProyectoController>
        [HttpPost]
        public async Task<ActionResult<Proyecto>> Post(Proyecto p)
        {
            _context.Add(p);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = p.ProyectoId }, p);
            
        }

        // PUT api/<ProyectoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Proyecto p, int id)
        {
            if (id != p.ProyectoId)
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
                if (!ProyectoExists(id))
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

        // DELETE api/<ProyectoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var p = await _context.Proyectos.FindAsync(id);
            if (p == null)
            {
                return NotFound();
            }

            _context.Proyectos.Remove(p);
            await _context.SaveChangesAsync();

            return NoContent();

            
            
            
        }

         private bool ProyectoExists(int id)
        {
            return _context.Proyectos.Any(e => e.ProyectoId == id);
        }
}
