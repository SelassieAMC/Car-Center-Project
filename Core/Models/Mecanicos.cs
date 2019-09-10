using System;
using System.Collections.Generic;

namespace car_center_project.Core.Models
{
    public partial class Mecanicos
    {
        public string TipoDocumento { get; set; }
        public int Documento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
    }
}
