using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Libro
    {
        public int Id { get; set; }
        public String ISBN { get; set; }
        public String Titulo { get; set; }
        public int NoEdicion { get; set; }
        public int Year { get; set; }
        public String Autor { get; set; }
        public String Pais { get; set; }
        public String Sinopsis { get; set; }
        public String Carrera { get; set; }
        public String Mareria { get; set; }

        public Libro(){}
    }
}
