using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fallas
{
    public class Regla
    {
        public IList<string> Condiciones { get; set; }
        public string Premisa { get; set; }
        public bool Disparada { get; set; }

        public Regla(IList<string> condiciones, string premisa)
        {
            this.Condiciones = condiciones;
            this.Premisa = premisa;
            this.Disparada = false;
        }
    }
}
