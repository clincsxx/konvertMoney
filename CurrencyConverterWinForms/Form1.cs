using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CurrencyConverterWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Заполнение выпадающих списков валютами при загрузке формы
            fromCurrencyComboBox.Items.AddRange(new string[] { "USD", "EUR", "GBP", "JPY", "CAD" });
            toCurrencyComboBox.Items.AddRange(new string[] { "USD", "EUR", "GBP", "JPY", "CAD" });
        }

        private async void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Получение введенных пользователем данных
                decimal amount = decimal.Parse(amountTextBox.Text);
                string fromCurrency = fromCurrencyComboBox.Text.ToUpper();
                string toCurrency = toCurrencyComboBox.Text.ToUpper();

                // Проверка корректности введенных валют
                if (!IsValidCurrency(fromCurrency) || !IsValidCurrency(toCurrency))
                {
                    MessageBox.Show("Пожалуйста, выберите корректные коды валют.");
                    return;
                }

                // Выполнение конвертации
                decimal convertedAmount = await ConvertCurrency(amount, fromCurrency, toCurrency);

                // Отображение результата
                resultLabel.Text = $"{amount} {fromCurrency} = {convertedAmount} {toCurrency}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректную сумму.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private bool IsValidCurrency(string currency)
        {
            // Список поддерживаемых валют
            var supportedCurrencies = new List<string> { "USD", "EUR", "GBP", "JPY", "CAD" };
            return supportedCurrencies.Contains(currency);
        }

        private async Task<decimal> ConvertCurrency(decimal amount, string fromCurrency, string toCurrency)
        {
            using (var client = new HttpClient())
            {
                string apiUrl = $"https://api.frankfurter.app/latest?from={fromCurrency}&to={toCurrency}";
                try
                {
                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (string.IsNullOrEmpty(content))
                        {
                            throw new Exception("Пустой ответ от API.");
                        }

                        var rates = JsonConvert.DeserializeObject<ExchangeRatesResponse>(content);

                        if (rates.Rates != null && rates.Rates.ContainsKey(toCurrency))
                        {
                            decimal conversionRate = rates.Rates[toCurrency];
                            return amount * conversionRate;
                        }
                        else
                        {
                            throw new Exception($"Не удалось получить курс валюты {toCurrency}.");
                        }
                    }
                    else
                    {
                        throw new Exception($"Ошибка получения курса валют: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    throw new Exception($"Ошибка подключения: {ex.Message}");
                }
            }
        }

        public class ExchangeRatesResponse
        {
            public Dictionary<string, decimal> Rates { get; set; }
        }
    }
}
