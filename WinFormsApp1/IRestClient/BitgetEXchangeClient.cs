using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitget.Net.Clients;
using Bitget.Net.Interfaces.Clients;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1.IRestClient
{
    public class BitgetEXchangeClient : IExchangeClient
    {
        private BitgetRestClient client;

        public BitgetEXchangeClient()
        {
            client = new BitgetRestClient();
        }
        public async Task<decimal> GetLastPriceAsync()
        {
            var ticker = await client.SpotApi.ExchangeData.GetTickerAsync("ETHUSDT_SPBL");
            return ticker.Data.ClosePrice;
        }
    }
}
