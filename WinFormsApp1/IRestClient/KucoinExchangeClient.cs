using Binance.Net.Clients;
using Kucoin.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.IRestClient
{
    public class KucoinExchangeClient : IExchangeClient
    {
        private KucoinRestClient client;

        public KucoinExchangeClient()
        {
            client = new KucoinRestClient();
        }
        public async Task<decimal> GetLastPriceAsync()
        {
            var ticker = await client.SpotApi.ExchangeData.GetTickerAsync("ETH-USDT");
            return (decimal)ticker.Data.LastPrice;
        }
    }
}
