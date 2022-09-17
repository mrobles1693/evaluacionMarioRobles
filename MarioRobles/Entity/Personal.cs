using System;
using System.Collections.Generic;

namespace Entity
{
    public class Personal
    {
        int idPersonal { get; set; }
        string TipoDoc { get; set; }
        string NumeroDoc { get; set; }
        string ApPaterno { get; set; }
        string ApMaterno { get; set; }
        string Nombre1 { get; set; }
        string Nombre2 { get; set; }
        string NombreCompleto { get => (Nombre1 + " " + Nombre2 + " " + ApPaterno + " " + ApMaterno); }
        DateTime FechaNac { get; set; }
        DateTime FechaIngreso { get; set; }
        List<Hijo> Hijos { get; set; }
    }
}
