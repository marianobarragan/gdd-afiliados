using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Domain
{
    public class Rol
    {
        
        public Rol(string rol_id,string nombre_rol)
        {
            //this.rol_id = rol_id.to;
            this.rol_id = Int32.Parse(rol_id);
            nombre=nombre_rol;
            habilitado = true;
        }

        public int rol_id;
        public string nombre;
        public bool habilitado;

        public string getNombre(){
            return nombre;
        }
}
}
