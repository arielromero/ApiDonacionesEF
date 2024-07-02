using Microsoft.AspNetCore.Mvc;
using apiNetDonacionesEF.Models;
using apiNetDonacionesEF.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apiNetDonacionesEF.Services;

namespace apiNetDonaciones.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class DonacionController : ControllerBase
    {
    private readonly ILogger<DonacionController> _logger;
    private readonly IDonacionService _donacionService;

    public DonacionController(ILogger<DonacionController> logger, IDonacionService donacionService)
    {
        _logger = logger;
        _donacionService = donacionService; 
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Donacion>>> GetDonaciones()
    {
        var donacions = await _donacionService.GetAll();
        return Ok(donacions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Donacion>> GetDonacion(int id)
    {
        var donacion = await _donacionService.GetById(id);
        if (donacion == null)
        {
            return NotFound();
        }
        return Ok(donacion);
    }

    [HttpPost]
    public async Task<ActionResult<Donacion>> CreateDonacion(Donacion donacion)
    {
        var newDonacion = new Donacion
        {
            DonanteId = donacion.DonanteId,
            ProyectoId = donacion.ProyectoId,
            Monto = donacion.Monto
        };
        var createdDonacion  = await _donacionService.Save(newDonacion);
        return CreatedAtAction(nameof(GetDonacion), new { id = createdDonacion.DonacionId }, createdDonacion);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDonacion(int id, Donacion donacion)
    {
        if (id != donacion.DonacionId)
        {
            return BadRequest();
        }

        await _donacionService.Update(donacion);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDonacion(int id)
    {
        var result = await _donacionService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    }
