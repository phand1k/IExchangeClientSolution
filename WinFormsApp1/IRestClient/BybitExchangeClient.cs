using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;

namespace WinFormsApp1.IRestClient
{
    internal class BybitExchangeClient : IExchangeClient
    {
        private BybitRestClient client;

        public BybitExchangeClient()
        {
            client = new BybitRestClient();
        }
        public async Task<decimal> GetLastPriceAsync()
        {
            var ticker = await client.V5Api.ExchangeData.GetSpotTickersAsync("ETHUSDT");
            return ticker.Data.List.First().LastPrice;
        }
    }
}
