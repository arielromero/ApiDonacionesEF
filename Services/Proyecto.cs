using apiNetDonacionesEF.Context;
using apiNetDonacionesEF.Models;
using Microsoft.EntityFrameworkCore;


namespace apiNetDonacionesEF.Services;
public class ProyectoService:IProyectoService
{
   private readonly DonacionesContext _context;
  public ProyectoService(DonacionesContext context){
    _context = context;
  }

  // Crear un nuevo proyecto
  public async Task<Proyecto> Save(Proyecto proyecto)
  {
      _context.Proyectos.Add(proyecto);
      await _context.SaveChangesAsync();
      return proyecto;
  }

   // Obtener todos los proyectos
    public async Task<IEnumerable<Proyecto>> GetAll()
    {
        return await _context.Proyectos.ToListAsync();
    }

    // Obtener un proyecto por id
    public async Task<Proyecto> GetById(int id)
    {
        return await _context.Proyectos.FindAsync(id);
    }

    // Actualizar un proyecto
    public async Task<Proyecto> Update(Proyecto proyecto)
    {
        _context.Entry(proyecto).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return proyecto;
    }

    // Eliminar un proyecto
    public async Task<bool> Delete(int id)
    {
        var proyecto = await _context.Proyectos.FindAsync(id);
        if (proyecto == null)
        {
            return false;
        }

        _context.Proyectos.Remove(proyecto);
        await _context.SaveChangesAsync();
        return true;
    }



}

public interface IProyectoService
{
  public Task<IEnumerable<Proyecto>> GetAll();
  public Task<Proyecto> GetById(int id); 
  public Task<Proyecto> Save(Proyecto proyecto);

  public Task<bool> Delete(int id);
  public Task<Proyecto> Update(Proyecto proyecto);


}