using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Domain
{
    public class Rubro
    {

        public uint rubro_id;
        public string descripcion_corta;

        public Rubro(string rubro_texto, string text){
            rubro_id = UInt32.Parse(rubro_texto);
            descripcion_corta = text;
        }
    }
}
