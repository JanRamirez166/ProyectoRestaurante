using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Restaurante
    {
        public int IdRestaurante { get; set; }
        public string Nombre { get; set; }
        public byte[] Imagen { get; set; }
        public DateTime HorarioApertura { get; set; }
        public DateTime HorarioCierre { get; set; }
        public string Descripcion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool Estatus { get; set; }
    }
}
