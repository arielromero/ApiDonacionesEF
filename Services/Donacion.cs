using apiNetDonacionesEF.Context;
using apiNetDonacionesEF.Models;
using Microsoft.EntityFrameworkCore;


namespace apiNetDonacionesEF.Services;
public class DonacionService:IDonacionService
{
   private readonly DonacionesContext _context;
  public DonacionService(DonacionesContext context){
    _context = context;
  }

  // Crear un nuevo donacion
  public async Task<Donacion> Save(Donacion donacion)
  {
      _context.Donaciones.Add(donacion);
      await _context.SaveChangesAsync();
      return donacion;
  }

   // Obtener todos los donacions
    public async Task<IEnumerable<Donacion>> GetAll()
    {
        return await _context.Donaciones.Include(p => p.Proyecto).Include(p => p.Donante).ToListAsync();
    }


    // Obtener un donacion por id
    public async Task<Donacion> GetById(int id)
    {
        return await _context.Donaciones.FindAsync(id);
    }

    // Actualizar un donacion
    public async Task<Donacion> Update(Donacion donacion)
    {
        _context.Entry(donacion).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return donacion;
    }

    // Eliminar un donacion
    public async Task<bool> Delete(int id)
    {
        var donacion = await _context.Donaciones.FindAsync(id);
        if (donacion == null)
        {
            return false;
        }

        _context.Donaciones.Remove(donacion);
        await _context.SaveChangesAsync();
        return true;
    }



}

public interface IDonacionService
{
  public Task<IEnumerable<Donacion>> GetAll();
  public Task<Donacion> GetById(int id); 
  public Task<Donacion> Save(Donacion donacion);

  public Task<bool> Delete(int id);
  public Task<Donacion> Update(Donacion donacion);


}