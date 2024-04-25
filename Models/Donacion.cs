using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiNetDonacionesEF.Models;
    
public class Donacion
{
    public int DonacionId {get;set;}
    
    public int ProyectoId{get;set;}
    
    public int DonanteId {get;set;}
    public virtual Donante Donante {get;set;}
    public virtual Proyecto Proyecto {get;set;}
    
    public double Monto{get;set;}

    



    public Donacion()
    { }

    public Donacion(int id, Donante donante,  double monto, Proyecto proyecto)
    {
        DonacionId = DonacionId;
        this.Donante = donante;
        this.Proyecto = proyecto;
        Monto = monto;
    }


}

