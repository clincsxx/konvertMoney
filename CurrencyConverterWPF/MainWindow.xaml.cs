using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace CurrencyConverter
{
    public partial class MainWindow : Window
    {
        private const string ApiUrl = "https://api.exchangerate-api.com/v4/latest/USD"; // Замените на актуальный API
        private JObject exchangeRates;

        public MainWindow()
        {
            InitializeComponent();
            LoadCurrencies();
        }

        private async void LoadCurrencies()
        {
            exchangeRates = await GetExchangeRates();
            var currencies = exchangeRates["rates"].ToObject<Dictionary<string, decimal>>().Keys.ToList();
            FromCurrencyComboBox.ItemsSource = currencies;
            ToCurrencyComboBox.ItemsSource = currencies;
        }

        private async Task<JObject> GetExchangeRates()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(ApiUrl);
                return JObject.Parse(response);
            }
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(AmountTextBox.Text, out var amount) &&
                FromCurrencyComboBox.SelectedItem != null &&
                ToCurrencyComboBox.SelectedItem != null)
            {
                var fromCurrency = FromCurrencyComboBox.SelectedItem.ToString();
                var toCurrency = ToCurrencyComboBox.SelectedItem.ToString();

                var fromRate = exchangeRates["rates"][fromCurrency].Value<decimal>();
                var toRate = exchangeRates["rates"][toCurrency].Value<decimal>();

                var convertedAmount = amount * (toRate / fromRate);
                ResultLabel.Content = $"Результат: {convertedAmount:F2} {toCurrency}";
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные данные.");
            }
        }
    }
}
