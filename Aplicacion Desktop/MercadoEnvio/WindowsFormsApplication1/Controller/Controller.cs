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

            Usuario usuario2 = new Usuario(Int32.Parse(data.Rows[0][0].ToString()), usuario);
            return usuario2;


        }
        
        public List<Rol> obtenerRolesDelUsuario(Usuario u)
        {
            string comando = "SELECT r.rol_id,nombre_rol FROM DBME.rol r JOIN DBME.rol_x_usuario rxu ON (r.rol_id=rxu.rol_id) WHERE r.es_rol_habilitado = 1 AND rxu.usuario_id = '" + u.usuario_id + "'";
            DataTable dataroles = (new ConexionSQL()).cargarTablaSQL(comando);

            var roles = new List<Rol>();

            //obtener los roles HABILITADOS de la data

            for (int i = 0; i <= (dataroles.Rows.Count - 1); i++)
            {
                roles.Add(obtenerRol(dataroles.Rows[i][0].ToString(), dataroles.Rows[i][1].ToString()));
            }

            return roles;
        }

        public Rol obtenerRol(string rol_id , string nombre_rol)
        {
            
            return new Rol(rol_id, nombre_rol);
        }

        public List<Funcionalidad> traerListaDeFuncionesDelRol(int rol_id){
            string comando = "SELECT f.funcionalidad_id,descripcion FROM DBME.funcionalidad f JOIN DBME.rol_x_funcionalidad rxf ON (f.funcionalidad_id=rxf.funcionalidad_id) WHERE rol_id = " + rol_id;
                //"SELECT r.rol_id,nombre_rol FROM DBME.rol r JOIN DBME.rol_x_usuario rxu ON (r.rol_id=rxu.rol_id) WHERE r.es_rol_habilitado = 1 AND rxu.usuario_id = '" + u.usuario_id + "'";
            DataTable dataroles = (new ConexionSQL()).cargarTablaSQL(comando);

            var funcionalidades = new List<Funcionalidad>();

            //obtener los roles HABILITADOS de la data

            for (int i = 0; i <= (dataroles.Rows.Count - 1); i++)
            {
                
                funcionalidades.Add(new Funcionalidad( Int32.Parse( dataroles.Rows[i][0].ToString()), dataroles.Rows[i][1].ToString()));
                
            }

            return funcionalidades;
        }
    }
}
