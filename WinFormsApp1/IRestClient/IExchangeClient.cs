﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.IRestClient
{
    public interface IExchangeClient
    {
        Task<decimal> GetLastPriceAsync();
    }
}