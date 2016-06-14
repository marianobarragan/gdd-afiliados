using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace MercadoEnvio.Domain
{
    public class Visibilidad
    {
 
        public string descripcion;
        public int precio;
        public int porcentaje;
        public int costo_envio;
        public int precioDecimal;
        public int costo_envioDecimal;

        public Visibilidad(DataTable dataVisibilidad)
        {
            string [] datos = dataVisibilidad.Rows[0][1].ToString().Split(',');
            string[] datos2 = dataVisibilidad.Rows[0][3].ToString().Split(',');
            descripcion=dataVisibilidad.Rows[0][0].ToString();
            precio =Int32.Parse(datos[0]);
            precioDecimal =Int32.Parse(datos[1]);
            porcentaje =Int32.Parse(dataVisibilidad.Rows[0][2].ToString().Split(',')[1]);
            costo_envio =Int32.Parse(datos2[0]);
            costo_envioDecimal = Int32.Parse(datos2[1]);
        }

        
    }
}