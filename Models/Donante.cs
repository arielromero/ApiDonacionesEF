﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiNetDonacionesEF.Models;

public class Donante
{
    public int DonanteId {get;set;}
    public string Nombre {get;set;}
    public string Apellido {get;set;}
    //public virtual List<Donacion> Donaciones {get; set;} 
    public string Dni {get;set;}
    public Donante()
    { }

    public override string ToString()
    {
        return Nombre + " "  + Apellido;
    }
}
