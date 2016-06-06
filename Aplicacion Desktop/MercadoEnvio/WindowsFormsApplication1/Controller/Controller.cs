using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


using MercadoEnvio.Domain;


namespace MercadoEnvio.Controller
{
    class Controller
    {
        public Usuario loginUsuario(String usuario, String contraseña){
            
            string comando = "execute dbme.loginUsuario '" + usuario + "', '" + new Encriptador().getHash(contraseña) + "'";
            DataTable data = (new ConexionSQL()).cargarTablaSQL(comando);

            // acafalta obtener el objeto usuario a partir de la data
            
            Usuario usuario2 = new Usuario();
            return usuario2;


        }
        
        public List<Rol> obtenerRolesDelUsuario(Usuario u)
        {
            string comando = "execute dbme.getFuncionalidadesDeUsuario '" + u.usuario_id + "'";
            DataTable data = (new ConexionSQL()).cargarTablaSQL(comando);

            var roles = new List<Rol>();

            //obtener los roles de la data
            return roles;
        }
    }
}
