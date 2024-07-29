using Microsoft.AspNetCore.Mvc;
using apiNetDonacionesEF.Models;
using apiNetDonacionesEF.Services;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace apiNetDonacionesEF.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class DonanteController : ControllerBase
    {
    private readonly  ILogger<DonanteController> _logger;
    private readonly IDonanteService _donanteService;

    public DonanteController(ILogger<DonanteController> logger, IDonanteService donateService)    {
        _logger = logger;
        _donanteService = donateService;

    }

    [HttpGet("/api/Donantes")]
    public async Task<ActionResult<IEnumerable<Donante>>> GetDonantes([FromQuery] string apellido="")
    {
        var donantes = await _donanteService.GetAll();
        
        if(apellido != null)
            donantes = donantes.Where(d => d.Apellido.ToLower().Contains(apellido.ToLower())).ToList();
        return Ok(donantes);
    }

    [HttpGet("/api/Donantes/{id}")]
    public async Task<ActionResult<Donante>> GetDonante(int id)
    {
        var donante = await _donanteService.GetById(id);
        if (donante == null)
        {
            return NotFound();
        }
        return Ok(donante);
    }

    [HttpPost]
    public async Task<ActionResult<Donante>> CreateDonante(Donante donante)
    {
        var newDonante = await _donanteService.Save(donante);
        return CreatedAtAction(nameof(GetDonante), new { id = newDonante.DonanteId }, newDonante);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDonante(int id, Donante donante)
    {
        if (id != donante.DonanteId)
        {
            return BadRequest();
        }

        await _donanteService.Update(donante);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDonante(int id)
    {
        var result = await _donanteService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }


            
    }

