using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MercadoEnvio.Controller
{
    class Encriptador
    {
        public String getHash(String input)
        {
            
            SHA256Managed encriptador = new SHA256Managed();
            byte[] inputEnBytes = Encoding.UTF8.GetBytes(input);
            byte[] inputHashBytes = encriptador.ComputeHash(inputEnBytes);
            return BitConverter.ToString(inputHashBytes).Replace("-", String.Empty).ToLower();
            
        }

        public bool cadenaSoloContieneNumeros(String str)
        {

            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;

            
        }
    }
}
