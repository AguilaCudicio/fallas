using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fallas
{
    public class BaseDeConocimiento
    {
        public IList<Regla> reglas { get; set; }
        public IList<string> Hechos { get; set; }

        public BaseDeConocimiento(IList<Regla> reglas, IList<string> hechos)
        {
            this.reglas = reglas;
            this.Hechos = hechos;
        }
    }
}
