using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Domain
{
    public class Funcionalidad
    {
        public Funcionalidad(int funcionalidad_id, string descripcion) {
            this.funcionalidad_id = funcionalidad_id;
            this.descripcion = descripcion;

        }

        public int funcionalidad_id;
        public string descripcion;



        public string getDescripcion() {
            return descripcion;
        }
    }
}
