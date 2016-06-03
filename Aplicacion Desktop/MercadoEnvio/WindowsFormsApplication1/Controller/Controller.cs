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
        public Usuario obtenerUsuario(String usuario, String contraseña){
            
            // mando la query y obetengo el usuario
            // verifico q la query me trajo un usuario valido
            // devuelvo el usuario

            string comando = "execute dbme.loginUsuario '" + usuario + "', '" + contraseña + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);

            // acafalta hacer banda de cosas
            
            Usuario usuario2 = new Usuario();
            return usuario2;


        }

        public List<string> obtenerRolesDelUsuario(String usuario, String contraseña)
        {
            return List<string> rolesUsuario = new List<string>();

            public List<String> pasajes = new List<String>();
        }
    }
}
