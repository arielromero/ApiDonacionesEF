using apiNetDonacionesEF.Context;
using apiNetDonacionesEF.Models;
using Microsoft.EntityFrameworkCore;


namespace apiNetDonacionesEF.Services;
public class DonanteService:IDonanteService
{
   private readonly DonacionesContext _context;
  public DonanteService(DonacionesContext context){
    _context = context;
  }

  // Crear un nuevo donante
  public async Task<Donante> Save(Donante donante)
  {
      _context.Donantes.Add(donante);
      await _context.SaveChangesAsync();
      return donante;
  }

   // Obtener todos los donantes
    public async Task<IEnumerable<Donante>> GetAll()
    {
        return await _context.Donantes.ToListAsync();
    }

    // Obtener un donante por id
    public async Task<Donante> GetById(int id)
    {
        return await _context.Donantes.FindAsync(id);
    }

    // Actualizar un donante
    public async Task<Donante> Update(Donante donante)
    {
        _context.Entry(donante).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return donante;
    }

    // Eliminar un donante
    public async Task<bool> Delete(int id)
    {
        var donante = await _context.Donantes.FindAsync(id);
        if (donante == null)
        {
            return false;
        }

        _context.Donantes.Remove(donante);
        await _context.SaveChangesAsync();
        return true;
    }



}

public interface IDonanteService
{
  public Task<IEnumerable<Donante>> GetAll();
  public Task<Donante> GetById(int id); 
  public Task<Donante> Save(Donante donante);

  public Task<bool> Delete(int id);
  public Task<Donante> Update(Donante donante);


}