using AcessandoDadosDoBancoAsync.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

namespace AcessandoDadosDoBancoAsync
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

        Model1 context = new Model1();

        List<User> usuarios = new List<User>();

        DateTime time = new DateTime();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    time = DateTime.Now;
                }
            });
        }

        public async void CallTeacher()
        {
            usuarios = await Task.Run(() => usuarios = (from s in context.User
                                                        where s.Id > 0
                                                        select s).ToList<User>());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*foreach (var item in usuarios)
            {
                MessageBox.Show(item.Usuario);*/

                MessageBox.Show(time.ToString("hh:mm:ss.fff"));
        }
    }
}
