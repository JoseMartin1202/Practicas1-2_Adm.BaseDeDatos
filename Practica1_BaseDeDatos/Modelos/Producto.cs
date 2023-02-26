using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public String NombreCorto { get; set; }
        public String Descripcion { get; set; }
        public String Serie { get; set; }
        public String Color { get; set; }
        public DateTime FechaAdquision { get; set; }
        public String TipoAdquision { get; set; }
        public String Observaciones { get; set; }
        public String Areas_id { get; set; }

        public Producto(int id,String nombreCorto, String descripcion, String serie, String color, DateTime fechaAdquisicion, String tipoAdquisicion, String observaciones,String area)
        {
            Id = id;
            NombreCorto= nombreCorto;
            Descripcion= descripcion;
            Serie= serie;
            Color= color;
            FechaAdquision= fechaAdquisicion;
            TipoAdquision = tipoAdquisicion;
            Observaciones= observaciones;
            Areas_id = area;
        }

        public Producto()
        {

        }

    }
}
