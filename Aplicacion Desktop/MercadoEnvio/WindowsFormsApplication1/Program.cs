using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

using MercadoEnvio.Login;
using MercadoEnvio.Domain;



namespace MercadoEnvio
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MercadoEnvio.Generar_Publicación.AltaCompraInmediata(new Sesion(1, "fabian", new Rol("1", "nombre rol"))));
            //Application.Run(new MercadoEnvio.Generar_Publicación.AltaCompraInmediata(new Sesion(1,"fabian",new Rol("1","nombre rol") )));
            //Application.Run(new MercadoEnvio.Generar_Publicación.AltaCompraInmediata());

            
        }

        public static String ip()
        {
            return ConfigurationManager.AppSettings["ip"];

        }

        public static String puerto()
        {
            return ConfigurationManager.AppSettings["puerto"];
        }


        public static String fechaSistema()
        {
            return ConfigurationManager.AppSettings["FechaDelSistema"];
        }
    }
}
