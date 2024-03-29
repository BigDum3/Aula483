﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ValidandoWebSite
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<ListaRequisicoes> list = new List<ListaRequisicoes>();

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var listaDeSite = txtUrl.Text.Split(',');

            foreach (var item in listaDeSite)
            {
                string url = txtUrl.Text;
                if (!String.IsNullOrEmpty(url))
                {
                    try
                    {
                        //CRIA UMA REQUISICAO DENTRO DO NOSSO METODO BOTAO, IGUAL A UM NAVEGADOR FAZ QUANDO DIGITAMOS UMA URL

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        //ESPERA TRAZER OS ARQUIVOS DA NUVEM "HEADERS" INDICANDO O STATUS CODE DO SITE
                        HttpWebResponse response = await Task<WebResponse>.Factory.FromAsync(
                            request.BeginGetResponse,
                            request.EndGetResponse,
                            request) as HttpWebResponse;

                        // ADICIONA NA NOSSA LISTA AS INFORMACOES
                        list.Add(new ListaRequisicoes()
                        {
                            Url = item,
                            Status = response.StatusCode.ToString()
                        });
                    }
                    catch (Exception ex)
                    {
                        list.Add(new ListaRequisicoes()
                        {
                            Url = item,
                            Status = "Erro"
                        });
                        
                    }
                }
            }

        }
        DispatcherTimer timer = new DispatcherTimer();

        private void Window_Loaded(object sender, RoutedEventArgs e)

        {
            //SETAMOS O EVENTO TICK DO TIMER QUE E EXECUTADO EM UM TEMPO DETERMINADO COM O EVENTO QUE CONTEM NOSSAS OPERACOES
            timer.Tick += new EventHandler(timer_tick);
            //AQUI DEFINIMOS O CLICK DE EXECUCAO QUE NOSSO TIMER IRA FAZER EM UM LOOP ATE QUE EU FALE PARA ELE PARAR 
            // OU A APLICACAO SEJA FINALIZADA
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            //AQUI NESTE PONTO INDICO QUE O TIMER JA PODE EXECUTAR COM A THREAD PRINCIPAL
            timer.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            //AQUI EU LIMPO TODA VEZ QUE ELE ENTRAR NO METODO O QUE JA FOI ESCRITO NA AREA DE TEXTO
            txtStatusReport.Clear();
            //PERCORRO MINHA LISTA DE SITES JA ADICIONADOS PARA MOSTRAR
            foreach (ListaRequisicoes item in list)
            {//APRESENTO AS INFORMACOES DE FORMA FORMATADA
                txtStatusReport.AppendText($"Url: {item.Url} \r\nStatus Code: {item.Status}");
            }
        }

        public class ListaRequisicoes
        {
            //URL DO SITE QUE QUEREMOS VERIFICAR SE ESTA ONLINE
            public string Url { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
        }

        private void TxtUrl_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}