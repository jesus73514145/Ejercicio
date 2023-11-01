using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace registrar_listar_estudiante.Models {
    public class Estudiante {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string TieneTarjetaCredito { get; set; } // Nuevo atributo
        public List<string> ColoresFavoritos { get; set; }
    }
}