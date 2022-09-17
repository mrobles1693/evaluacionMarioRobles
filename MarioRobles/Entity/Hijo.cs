using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Hijo
    {
        int idHijo { get; set; }
        int idPersonal { get; set; }
        string TipoDoc { get; set; }
        string NumeroDoc { get; set; }
        string ApPaterno { get; set; }
        string ApMaterno { get; set; }
        string Nombre1 { get; set; }
        string Nombre2 { get; set; }
        string NombreCompleto { get => (Nombre1 + " " + Nombre2 + " " + ApPaterno + " " + ApMaterno); }
        DateTime FechaNac { get; set; }

    }
}
