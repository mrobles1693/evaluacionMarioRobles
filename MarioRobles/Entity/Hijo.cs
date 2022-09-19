using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Hijo
    {
        public int idHijo { get; set; }
        public int idPersonal { get; set; }
        public String TipoDoc { get; set; }
        public String NumeroDoc { get; set; }
        public String ApPaterno { get; set; }
        public String ApMaterno { get; set; }
        public String Nombre1 { get; set; }
        public String Nombre2 { get; set; }
        public String NombreCompleto { get => (Nombre1 + " " + (Nombre2 != String.Empty ? Nombre2 + " " : "") + " " + ApPaterno + " " + ApMaterno); }
        public DateTime FechaNac { get; set; }

    }
}
