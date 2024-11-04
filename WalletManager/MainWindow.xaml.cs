using Newtonsoft.Json;
using Nethereum.Web3;
using System.Collections.ObjectModel;
using System.IO;
using System.Numerics; // For BigInteger
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace WalletManager
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Wallet> Wallets { get; set; } = new ObservableCollection<Wallet>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadWalletsAsync();
        }

        private async Task LoadWalletsAsync()
        {
            string filePath = @"C:\Users\giova\source\repos\WalletManager\WalletManager\wallets.json";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("The wallets.json file was not found at the specified path.");
                return;
            }

            // Read and deserialize the JSON file
            var json = File.ReadAllText(filePath);
            var wallets = JsonConvert.DeserializeObject<List<Wallet>>(json);

            if (wallets == null || wallets.Count == 0)
            {
                MessageBox.Show("No wallets found in the JSON file.");
                return;
            }

            foreach (var wallet in wallets)
            {
                // Validate address format before fetching balance
                if (IsValidAddress(wallet.Address))
                {
                    wallet.Balance = await GetBalanceAsync(wallet.Address);
                }
                else
                {
                    MessageBox.Show($"Invalid address format: {wallet.Address}");
                    wallet.Balance = 0; // Set balance to 0 for invalid addresses
                }
                Wallets.Add(wallet);
                Console.WriteLine($"Loaded wallet: {wallet.Address}, Balance: {wallet.Balance}");
            }
        }

        private async Task<decimal> GetBalanceAsync(string address)
        {
            try
            {
                var web3 = new Web3("https://bsc-dataseed.binance.org/");
                var balanceWei = await web3.Eth.GetBalance.SendRequestAsync(address);

                // Use BigInteger for higher precision and convert to BNB
                BigInteger balanceInWei = balanceWei.Value;
                decimal balanceBNB = (decimal)balanceInWei / (decimal)Math.Pow(10, 18);

                // Round to 18 decimal places for consistency with BNB Scan
                return Math.Round(balanceBNB, 18);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error fetching balance for {address}: {ex.Message}");
                return 0; // Return 0 if there is an error
            }
        }

        // Helper function to validate Ethereum-compatible address format
        private bool IsValidAddress(string address)
        {
            return address.StartsWith("0x") && address.Length == 42 && Regex.IsMatch(address.Substring(2), @"\A\b[0-9a-fA-F]+\b\Z");
        }
    }
}
