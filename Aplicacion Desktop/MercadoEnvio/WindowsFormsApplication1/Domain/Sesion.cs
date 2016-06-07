using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MercadoEnvio.Controller;
namespace MercadoEnvio.Domain
{
    public class Sesion
    {
        public Sesion(int usuario_id, string nombre, Rol rolActual){
            this.usuarioActual = new Usuario(usuario_id, nombre);
            this.rolActual = rolActual;
            traerListaDeFuncionesDelRol();
        }
        
        public Usuario usuarioActual;
        public Rol rolActual;
        public List<Funcionalidad> listaFuncionalidades;


        public void traerListaDeFuncionesDelRol(){
            this.listaFuncionalidades = new Controller.Controller().traerListaDeFuncionesDelRol(this.rolActual.rol_id);
        }

    }
}
