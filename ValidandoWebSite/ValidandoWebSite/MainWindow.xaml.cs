using System;
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
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        HttpWebResponse response = await Task<WebResponse>.Factory.FromAsync(
                            request.BeginGetResponse,
                            request.EndGetResponse,
                            request) as HttpWebResponse;

                        list.Add(new ListaRequisicoes()
                        {
                            Url = item,
                            Status = response.StatusCode.ToString()
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }
        DispatcherTimer timer = new DispatcherTimer();

        private void Window_Loaded(object sender, RoutedEventArgs e)

        {
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 0, 500);
            timer.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            txtStatusReport.Clear();
            foreach (ListaRequisicoes item in list)
            {
                txtStatusReport.AppendText($"Url: {item.Url} \r\nStatus Code: {item.Status}");
            }
        }

        public class ListaRequisicoes
        {
            public string Url { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
        }

        private void TxtUrl_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}