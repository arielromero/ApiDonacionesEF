using Microsoft.AspNetCore.Mvc;
using apiNetDonacionesEF.Models;
using apiNetDonacionesEF.Context;
using Microsoft.EntityFrameworkCore;
using apiNetDonacionesEF.Services;

namespace apiNetDonaciones.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProyectoController : ControllerBase
{
 

    private readonly ILogger<ProyectoController> _logger;
    private readonly IProyectoService _proyectoService;

    public ProyectoController(ILogger<ProyectoController> logger, IProyectoService proyectoService)
    {
        _logger = logger;
        _proyectoService = proyectoService; 
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyectos()
    {
        var proyectos = await _proyectoService.GetAll();
        return Ok(proyectos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Proyecto>> GetProyecto(int id)
    {
        var proyecto = await _proyectoService.GetById(id);
        if (proyecto == null)
        {
            return NotFound();
        }
        return Ok(proyecto);
    }

    [HttpPost]
    public async Task<ActionResult<Proyecto>> CreateProyecto(Proyecto proyecto)
    {
        var newProyecto = await _proyectoService.Save(proyecto);
        return CreatedAtAction(nameof(GetProyecto), new { id = newProyecto.ProyectoId }, newProyecto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProyecto(int id, Proyecto proyecto)
    {
        if (id != proyecto.ProyectoId)
        {
            return BadRequest();
        }

        await _proyectoService.Update(proyecto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProyecto(int id)
    {
        var result = await _proyectoService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    }
