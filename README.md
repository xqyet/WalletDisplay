# Bulk Wallet Manager

A C# WPF application that allows you to manage multiple wallets in a single interface. You can load wallet addresses and private keys from a JSON file, view each wallet’s BNB balance, and toggle visibility of private keys. The application is designed with a dark theme and provides basic functionalities for bulk wallet management.


## Features

- **Bulk Wallet Loading**: Load wallet data from a JSON file.
- **Balance Retrieval**: Automatically fetches and displays the BNB balance for each wallet.
- **Toggle Private Key Visibility**: Option to hide/show private keys in the interface.

## GUI 

Below is a preview of the Wallet Manager's interface:

![Wallet Manager GUI](manager_gui.png)

## Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/yourusername/BulkWalletManager.git
   cd BulkWalletManager/WalletManager
 
 
2. **Install Required NuGet Packages**:
   - Open the **NuGet Package Manager** in Visual Studio and install the following packages:
     - `Newtonsoft.Json` for JSON parsing.
     - `Nethereum.Web3` for interacting with the Binance Smart Chain.

   Alternatively, you can install these packages using the **Package Manager Console**:
   ```powershell
   Install-Package Newtonsoft.Json
   Install-Package Nethereum.Web3
 
 3. **Add `wallets.json` File**:
   - Create a `wallets.json` file in the same directory as the executable (`bin/Debug/netcoreapp3.1/` or similar).
   - Use the following format for your `wallets.json` file:
     ```json
     [
       {
         "address": "0xYourWalletAddress1",
         "privateKey": "YourPrivateKey1"
       },
       {
         "address": "0xYourWalletAddress2",
         "privateKey": "YourPrivateKey2"
       }
     ]
     ```

## Usage

1. **Run the Application**:
   - Start the application in Visual Studio by pressing **F5** or selecting **Start Debugging**.

2. **Load Wallet Data**:
   - The application will automatically load wallet data from the `wallets.json` file.

3. **View and Manage Wallets**:
   - The GUI will display each wallet’s address, balance, and private key. Use the "Show Private Keys" checkbox to toggle the visibility of private keys.

  
