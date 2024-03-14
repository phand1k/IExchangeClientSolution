using Binance.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.IRestClient
{
    public class BinanceExchangeClient : BinanceRestClient, IExchangeClient
    {
        private BinanceRestClient client;

        public BinanceExchangeClient()
        {
            client = new BinanceRestClient();
        }

        public async Task<decimal> GetLastPriceAsync()
        {
            var ticker = await client.SpotApi.ExchangeData.GetTickerAsync("ETHUSDT");
            return ticker.Data.LastPrice;
        }
    }

}
