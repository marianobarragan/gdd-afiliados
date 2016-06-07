using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Domain
{
    public class Usuario
    {
        public string nombreUsuario;
        public int usuario_id;

        public Usuario(int usuario_id, string nombre) {
            this.nombreUsuario = nombre;
            this.usuario_id = usuario_id;

        }
    }
}
