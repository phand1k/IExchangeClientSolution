using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Binance.Net.Clients;
using Kucoin.Net.Clients;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using Bitget.Net.Clients;
using WinFormsApp1.IRestClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private BinanceExchangeClient BinanceExchangeClient;
        private KucoinExchangeClient KucoinExchangeClient;
        private BybitExchangeClient BybitExchangeClient;
        private BitgetEXchangeClient BitgetEXchangeClient;


        private System.Windows.Forms.Timer timer;
        private decimal? previousPrice;
        private decimal? previousPriceKucoin;
        private decimal previousPriceBybit;
        private decimal previousPricebitget;
        public Form1()
        {
            InitializeComponent();
            BinanceExchangeClient = new BinanceExchangeClient();
            KucoinExchangeClient = new KucoinExchangeClient();
            BitgetEXchangeClient = new BitgetEXchangeClient();
            BybitExchangeClient = new BybitExchangeClient();


            timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Start();
            previousPrice = 0;
            previousPriceKucoin = 0;
            previousPriceBybit = 0;

            dataGridView1.Columns.Add("Exchange", "Биржа");
            dataGridView1.Columns.Add("Price", "Цена");
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await UpdatePrice();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            await UpdatePrice();
        }

        private async Task UpdatePrice()
        {
            try
            {
                var tickerKucoin = await KucoinExchangeClient.GetLastPriceAsync();
                var tickerBybit = await BybitExchangeClient.GetLastPriceAsync();
                var tickerbitget = await BitgetEXchangeClient.GetLastPriceAsync();



                decimal? currentPriceKucoin = await KucoinExchangeClient.GetLastPriceAsync();
                decimal currentPriceBybite = await BybitExchangeClient.GetLastPriceAsync();
                decimal currentPricebitget = await BitgetEXchangeClient.GetLastPriceAsync();
                decimal? currentPriceBinance = await BinanceExchangeClient.GetLastPriceAsync();


                if (currentPriceBinance != previousPrice && currentPriceKucoin != previousPriceKucoin)
                {
                    dataGridView1.Rows.Clear();

                    dataGridView1.Rows.Add("Binance", currentPriceBinance.ToString());
                    dataGridView1.Rows.Add("Kucoin", currentPriceKucoin.ToString());
                    dataGridView1.Rows.Add("Bybit", currentPriceBybite.ToString());
                    dataGridView1.Rows.Add("BitGet", currentPricebitget.ToString());

                    label2.Text = "Информация обновлена";
                    System.Windows.Forms.Timer resetTimer = new System.Windows.Forms.Timer(); 
                    resetTimer.Interval = 2000;
                    resetTimer.Tick += (s, args) =>
                    {
                        label2.Text = ""; 
                        resetTimer.Stop(); 
                    };
                    resetTimer.Start();
                }

                previousPrice = currentPriceBinance;
                previousPriceKucoin = currentPriceKucoin;
                previousPriceBybit = currentPriceBybite;
                previousPricebitget = currentPricebitget;
            }
            catch (Exception ex)
            {
                label2.Text = "Ошибка: " + ex.Message;
            }
        }
    }
}
