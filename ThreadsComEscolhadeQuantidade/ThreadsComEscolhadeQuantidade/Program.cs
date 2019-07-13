using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsComEscolhadeQuantidade
{
    class Program
    {
        static List<ListaThreads> listaThreads = new List<ListaThreads>();
        static long indice = 0;

        static void Main(string[] args)
        {
            Thread t1 = new Thread(IncrementIdex);
            t1.Start();

            Thread t2 = new Thread(IncrementIdex);
            t2.Start();

            Thread t3 = new Thread(IncrementIdex);
            t3.Start();

            var inicio = DateTime.Now;

            while(indice < 1000) { }

            var tempoTotal = DateTime.Now - inicio;

            Console.WriteLine($"Tempo para execução: {tempoTotal}");
            Console.ReadKey();
        }

        public static void IncrementIdex()
        {
            while (indice < 1000)
                indice++;
        }

        public static void CarregaLista()
        {
            for (long i = 0; i < 1000; i++)
            {
                try
                {
                    listaThreads.Add(new ListaThreads()
                    {
                        Numero = indice++
                    });
                }
                catch
                {
                    ///EstourouIndice
                }
            }
        }
    }

    public class ListaThreads
    {
        /// <summary>
        /// Numero que define a ordem de criacao
        /// </summary>
        public long Numero { get; set; } = 0;
        /// <summary>
        /// Identificador booleano que mostra se foi atualizado
        /// </summary>
        public bool Atualizado { get; set; } = false;
    }
}
