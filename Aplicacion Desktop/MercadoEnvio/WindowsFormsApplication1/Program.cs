using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoEnvio.Login;

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
            Application.Run(new MercadoEnvio.ABM_Rol.AltaRol());
            //Application.Run(new MercadoEnvio.Templates.ABM());
            
        }
    }
}
