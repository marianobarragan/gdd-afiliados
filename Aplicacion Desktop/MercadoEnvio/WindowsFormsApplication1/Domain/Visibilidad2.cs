using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Domain
{
    public class Visibilidad2
    {
        public string descripcion;
        public int precio;
        public int porcentaje;
        public int costo_envio;
        public int precioDecimal;
        public int costo_envioDecimal;
        public int id;

        public Visibilidad2 (string descripcionNueva, string precioNuevo, string porcentajeNuevo, string costo_envioNuevo,string id)
        {
            string[] datos = precioNuevo.Split(',');
            string[] datos2 = costo_envioNuevo.Split(',');
            string[] datos3 = porcentajeNuevo.Split(',');
            descripcion = descripcionNueva;
            precio = Int32.Parse(datos[0]);
            porcentaje = Int32.Parse(datos3[1]);
            costo_envio = Int32.Parse(datos2[0]);
            precioDecimal = Int32.Parse(datos[1]);
            costo_envioDecimal = Int32.Parse(datos2[1]);

        }


    }
}
