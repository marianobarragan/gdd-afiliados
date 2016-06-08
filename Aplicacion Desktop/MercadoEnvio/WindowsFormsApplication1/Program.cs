using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

using MercadoEnvio.Login;
using MercadoEnvio.ABM_Usuario;



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
            Application.Run(new MercadoEnvio.ABM_Rol.ListadoRol());
            //Application.Run(new MercadoEnvio.Templates.ABM());
            
        }

        public static String ip()
        {
            return ConfigurationManager.AppSettings["ip"];

        }

        public static String puerto()
        {
            return ConfigurationManager.AppSettings["puerto"];
        }


        public static String nuevaFechaSistema()
        {
            return ConfigurationManager.AppSettings["FechaGlobal"];
        }
    }
}
