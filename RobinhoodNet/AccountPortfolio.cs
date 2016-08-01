// The MIT License (MIT)
// 
// Copyright (c) 2015 Filip Frącz
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BasicallyMe.RobinhoodNet
{
	public class AccountPortfolio
    {
        public Url<Account> Account { get; set; }
        public Url<AccountPortfolio> Url { get; set; }
        public decimal AdjustedEquityPreviousClose { get; set; }
        public decimal MarketValue { get; set; }
        public decimal LastCoreMarketValue { get; set; }
        public decimal? ExtendedHoursEquity { get; set; }
        public decimal ExcessMargin { get; set; }
        public decimal ExcessMarginWithUnclearedDeposits { get; set; }
        public decimal Equity { get; set; }
        public decimal LastCoreEquity { get; set; }
        public decimal EquityPreviousClose { get; set; }
        public DateTime StartDate { get; set; }
        public decimal? ExtendedHoursMarketValue { get; set; }

        public AccountPortfolio()
        {
        }

        internal AccountPortfolio(Newtonsoft.Json.Linq.JToken json) : this()
        {
            Account = new Url<Account>((string)json["account"]);
            Url = new Url<AccountPortfolio>((string)json["url"]);
            AdjustedEquityPreviousClose = (decimal)json["adjusted_equity_previous_close"];
            MarketValue = (decimal)json["market_value"];
            LastCoreMarketValue = (decimal)json["last_core_market_value"];
            ExtendedHoursEquity = (decimal?)json["extended_hours_equity"];
            ExcessMargin = (decimal)json["excess_margin"];
            ExcessMarginWithUnclearedDeposits = (decimal)json["excess_margin_with_uncleared_deposits"];
            Equity = (decimal)json["equity"];
            LastCoreEquity = (decimal)json["last_core_equity"];
            EquityPreviousClose = (decimal)json["equity_previous_close"];
            StartDate = (DateTime)json["start_date"];
            ExtendedHoursMarketValue = (decimal?)json["extended_hours_market_value"];
        }
    }
}
