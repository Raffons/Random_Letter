using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RandomNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        private string[] Alfabeto = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];

        string parola;
        string estrazioneCasuale;
        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                estrazioneCasuale = Alfabeto[rnd.Next(0, 25)];
                lblLetteraEstratta.Content = estrazioneCasuale;

                await Task.Delay(100);
            }
        }
        private void btnEstrazione_Click(object sender, RoutedEventArgs e)
        {
            parola += estrazioneCasuale;
            lblElenco.Content = parola;

            if (parola.Length > 5)
            {
                lstParoleFinite.DataContext = parola;
            }
        }


    }
}