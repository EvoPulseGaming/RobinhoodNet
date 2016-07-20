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
    public class MarginBalance
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? MarkedPatternDayTraderDate { get; set; }

        public decimal DayTradeBuyingPower { get; set; }
        public decimal DayTradeBuyingPowerHeldForOrders { get; set; }
        public decimal OvernightBuyingPower { get; set; }
        public decimal OvernightBuyingPowerHeldForOrders { get; set; }

        public decimal Cash { get; set; }
        public decimal CashHeldForOrders { get; set; }
        public decimal CashAvailableForWithdrawal { get; set; }
        public decimal UnallocatedMarginCash { get; set; }
        public decimal MarginLimit { get; set; }
        public decimal UnsettledFunds { get; set; }
        public decimal UnclearedDeposits { get; set; }

        public decimal DayTradeRatio { get; set; }
        public decimal OvernightRatio { get; set; }

        public MarginBalance()
        {

        }

        internal MarginBalance(Newtonsoft.Json.Linq.JToken json)
        {
            this.CreatedAt = (DateTime)json["created_at"];
            this.UpdatedAt = (DateTime)json["updated_at"];
            this.MarkedPatternDayTraderDate = (DateTime?)json["marked_pattern_day_trader_date"];

            this.DayTradeBuyingPower = (decimal)json["day_trade_buying_power"];
            this.DayTradeBuyingPowerHeldForOrders = (decimal)json["day_trade_buying_power_held_for_orders"];
            this.OvernightBuyingPower = (decimal)json["overnight_buying_power"];
            this.OvernightBuyingPowerHeldForOrders = (decimal)json["overnight_buying_power_held_for_orders"];

            this.Cash = (decimal)json["cash"];
            this.CashHeldForOrders = (decimal)json["cash_held_for_orders"];
            this.CashAvailableForWithdrawal = (decimal)json["cash_available_for_withdrawal"];
            this.UnallocatedMarginCash = (decimal)json["unallocated_margin_cash"];
            this.MarginLimit = (decimal)json["margin_limit"];
            this.UnsettledFunds = (decimal)json["unsettled_funds"];
            this.UnclearedDeposits = (decimal)json["uncleared_deposits"];

            this.DayTradeRatio = (decimal)json["day_trade_ratio"];
            this.OvernightRatio = (decimal)json["overnight_ratio"];
        }
    }

}
