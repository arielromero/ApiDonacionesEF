using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace apiNetDonacionesEF.Models;

public class Proyecto
{   
    public int ProyectoId {get;set;}
    public string Titulo {get;set;}
    public string Descripcion {get;set;}
    public double Monto {get;set;}
    //public virtual List<Donacion> Donaciones {get;set;}

    public Proyecto()
    {
        //Donaciones = new List<Donacion>();
        }

  

    public override string ToString()
    {
        return Titulo;
    }
}

