using Microsoft.EntityFrameworkCore;
using apiNetDonacionesEF.Models;
namespace apiNetDonacionesEF.Context;


public class DonacionesContext: DbContext
{
  public DbSet<Donante> Donantes { get; set; }
  public DbSet<Proyecto> Proyectos { get; set; }
  public DbSet<Donacion> Donaciones { get; set;}  

  public DonacionesContext(DbContextOptions<DonacionesContext> options) : base(options){}

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Donante>( donante => 
    {
      donante.ToTable("Donante");
      donante.HasKey(d => d.DonanteId);
      donante.Property(d => d.Nombre).IsRequired().HasMaxLength(150);
      donante.Property(d => d.Apellido).IsRequired().HasMaxLength(150);
      donante.Property(d => d.Dni).IsRequired().HasMaxLength(8);
      
    });

    modelBuilder.Entity<Proyecto>( proyecto => 
    {
      proyecto.ToTable("Proyecto");
      proyecto.HasKey(d => d.ProyectoId);
      proyecto.Property(d => d.Titulo).IsRequired().HasMaxLength(200);
      proyecto.Property(d => d.Descripcion).IsRequired(false);
      proyecto.Property(d => d.Monto).IsRequired();
      
    });

    modelBuilder.Entity<Donacion>( donacion => 
    {
      donacion.ToTable("Donacion");
      donacion.HasKey(d => d.DonacionId);
      donacion.Property(d => d.ProyectoId).IsRequired();
      donacion.Property(d => d.DonacionId).IsRequired();
      donacion.Property(d => d.Monto).IsRequired();
      donacion.HasOne(d => d.Donante).WithMany().HasForeignKey(d => d.DonanteId);
      donacion.HasOne(d => d.Proyecto).WithMany().HasForeignKey(d => d.ProyectoId);
    });
  }


}