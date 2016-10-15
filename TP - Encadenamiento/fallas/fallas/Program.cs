using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fallas
{
    class Program
    {

        static void Main(string[] args)
        {
            var regla1 = new Regla(new List<string> { "p", "q" }, "s");
            var regla2 = new Regla(new List<string> { "r" }, "t");
            var regla3 = new Regla(new List<string> { "s", "t" }, "u");
            var regla4 = new Regla(new List<string> { "s", "r" }, "v");

            var reglas = new List<Regla>{ regla1, regla2, regla3, regla4 };

            while(true)
            {
                Console.WriteLine("Elija la opción");
                Console.WriteLine("1 - Encadenamiento hacia adelante");
                Console.WriteLine("2 - Encadenamiento hacia atras");

                var hechos = new List<string> { "p", "q", "r" };
                var baseDeConocimientos = new BaseDeConocimiento(reglas, hechos);

                int opcion = Convert.ToInt32(Console.ReadLine());
                if (opcion == 1)
                {
                    EncadenamientoHaciaAdelante(baseDeConocimientos);
                }
                else if (opcion == 2)
                {
                    EncadenamientoHaciaAtras(baseDeConocimientos, "v");
                }
            }
        }

        //Utilizamos como estrategia ver si la primera condicion se cumple
        private static bool EncadenamientoHaciaAtras(BaseDeConocimiento bdc, string premisaHipotesis)
        {
            Console.WriteLine("Encadenamiento hacia atras para la hipotesis " + premisaHipotesis);

            if (bdc.Hechos.Contains(premisaHipotesis))
            {
                Console.WriteLine("Hipótesis " + premisaHipotesis + " verificada");
                return true;
            }

            var reglasParaHipotesis = bdc.reglas.Where(x => x.Premisa.Equals(premisaHipotesis)).ToList();
            foreach(var regla in reglasParaHipotesis)
            {
                foreach (var condicion in regla.Condiciones)
                {
                    Console.WriteLine("Verificando Condicion " + condicion);
                    if (!bdc.Hechos.Contains(condicion))
                    {
                        if (EncadenamientoHaciaAtras(bdc, condicion) == false)
                        {
                            Console.WriteLine("No se pudo verificar la hipotesis " + premisaHipotesis);
                            return false;
                        }
                    }
                }
            }

            bdc.Hechos.Add(premisaHipotesis);
            Console.WriteLine("Hipótesis " + premisaHipotesis + " verificada");
            return true;
        }

        //Utilizamos la estrategia la primera regla dispara
        private static void EncadenamientoHaciaAdelante(BaseDeConocimiento bdc)
        {
            var reglasParaDisparar = bdc.reglas.Where(x => x.Condiciones.All(y => bdc.Hechos.Contains(y) && !x.Disparada)).ToList();

            while(reglasParaDisparar.Count > 0)
            {
                var regla = reglasParaDisparar.First();

                Console.WriteLine("Disparando regla con condiciones" + regla.Condiciones.ToString());
                
                regla.Disparada = true;
                bdc.Hechos.Add(regla.Premisa);

                Console.WriteLine("Agrego a los hechos la premisa " + regla.Premisa);
                Console.WriteLine("Hechos:");
                foreach(var hecho in bdc.Hechos)
                {
                    Console.WriteLine(hecho);
                }

                reglasParaDisparar = bdc.reglas.Where(x => x.Condiciones.All(y => bdc.Hechos.Contains(y) && !x.Disparada)).ToList();
            }

            Console.WriteLine("No hay mas reglas que disparar");
            Console.WriteLine("");
        }
    }

}
