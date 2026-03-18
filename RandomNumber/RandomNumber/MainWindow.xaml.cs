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
        int numeroInserito = 4;  // Metto che di base la parola si forma arrivati a 4 lettere, ma poi questa variabile va a cambiare quando l'utente mette il numero di lettere che forma la parola

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                estrazioneCasuale = Alfabeto[rnd.Next(0, 26)]; // Estraggo una lettera casuale dall'alfabeto
                lblLetteraEstratta.Content = estrazioneCasuale;

                await Task.Delay(100);
            }
        }
        private void btnEstrazione_Click(object sender, RoutedEventArgs e)
        {
            parola += estrazioneCasuale; // Aggiungo la lettera estratta alla parola che sto formando
            lblElenco.Content = parola;  // Aggiungo la parola alla Label che mostra la parola che sto formando


            if (numeroInserito == 0)
            {
                MessageBox.Show("Il numero di lettere della parola non deve essere inferiore a 0");    
            }
            
            else if (parola.Length >= numeroInserito)
            {
                lstParoleFinite.Items.Add(parola); // Aggiungo la parola alla ListBox
                parola = ""; // Resetto la parola per iniziare a formare una nuova parola
            }
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Legge il contenuto della TextBox
            bool isValid = int.TryParse(txtInput.Text, out numeroInserito);  // Converto il testo in un numero intero
            
            if (!isValid || numeroInserito < 0 || numeroInserito > 20) 
            {
                MessageBox.Show("Per favore, inserisci un numero valido maggiore di 0 e inferiore a 20.");
                txtInput.Text = "1"; // In caso ci sia un problema con l'input dell'utente, metto un 1 simbolico e basta
            }
        }
    }
}