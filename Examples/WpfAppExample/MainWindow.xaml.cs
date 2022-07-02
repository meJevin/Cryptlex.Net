using Cryptlex.Net.Core;
using Cryptlex.Net.Factories;
using Cryptlex.Net.Licenses;
using System.Linq;
using System.Windows;

namespace WpfAppExample
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

        private async void FetchLicensesButton_Click(object sender, RoutedEventArgs e)
        {
            var cryptlexClientSettings = new CryptlexClientSettings() { AccessToken = "YOUR_TOKEN" };

            var cryptlexClient = CryptlexClientFactory.Create(cryptlexClientSettings);

            FetchLicensesButton.IsEnabled = false;
            FetchLicensesButton.Content = "Loading...";

            var licenses = await cryptlexClient.Licenses.ListAsync(new ListLicensesData() { Page = 1 });

            FetchLicensesButton.IsEnabled = true;
            FetchLicensesButton.Content = "Fetch Licenses";

            LicensesListView.ItemsSource = licenses.Select(a => a.Id!);
        }
    }
}
