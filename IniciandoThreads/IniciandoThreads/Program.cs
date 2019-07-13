using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniciandoThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            //Classe do .net que trabalha com Threads paralelas com funções basicas de repeticao
            Parallel.For(0, 3, i => 
            {
                ImprimeOCafeEstaPronto(i);
                ImprimeOAlmocoEstaPronto(i);
            });

            /*Parallel.For(0, 5, i =>
            {
                ImprimeOAlmocoEstaPronto(i);
            });*/

            Console.ReadKey(); //Esperar precionar Tecla para dar continuidade
        }

        public  static void ImprimeOCafeEstaPronto(int numero)
        {
            Console.WriteLine($"O café esta Pronto {numero} ");
        }

        public static void ImprimeOAlmocoEstaPronto(int numero)
        {
            Console.WriteLine($"O Almoço esta Pronto {numero}");
        }
    }
}
