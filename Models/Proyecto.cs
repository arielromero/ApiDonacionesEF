﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace apiNetDonacionesEF.Models;

public class Proyecto
{   [Key]
    public int ProyectoId {get;set;}
    [Required]
    [MaxLength(150)]
    public string Titulo {get;set;}
    public string Descripcion {get;set;}
    public double Monto {get;set;}
    public List<Donacion> Donaciones {get;set;}

    public Proyecto()
    {
        Donaciones = new List<Donacion>();
     }

  

    public override string ToString()
    {
        return Titulo;
    }
}

