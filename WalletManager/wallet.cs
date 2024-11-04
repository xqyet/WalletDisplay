using Newtonsoft.Json;

namespace WalletManager
{
    public class Wallet
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("privateKey")]
        public string PrivateKey { get; set; }

        public decimal Balance { get; set; } // Stores the balance in BNB
    }
}
