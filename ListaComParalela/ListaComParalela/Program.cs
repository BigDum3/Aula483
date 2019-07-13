using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaComParalela
{
    class Program
    {
        static List<ParalleListTeste> ListaDeItens = new List<ParalleListTeste>();

        static void Main(string[] args)
        {
            var inicioDaoperacao = DateTime.Now;
            CarregaLista();
            var tempoTotal = DateTime.Now - inicioDaoperacao;

            Console.WriteLine($"Tempo Total para executar a operacao: {tempoTotal}");
            Console.ReadKey();
        }

        public static void CarregaLista()
        {
            for (int i = 0; i < 1000; i++)
            {
                ListaDeItens.Add(new ParalleListTeste()
                {
                    Numero = i
                });
            }
        }
    }

    public class ParalleListTeste
    {
        /// <summary>
        /// Numero que indica a ordem de criacao deste item;
        /// </summary>
        public int Numero { get; set; } = 0;
        /// <summary>
        /// Indicador Booleano que mostra se foi atualizado ou não.
        /// </summary>
        public bool Atualizado { get; set; } = false;
    }
}
