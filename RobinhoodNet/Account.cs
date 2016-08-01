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

    public class Account
    {
        public bool IsDeactivated { get; set; }
        public bool IsWithdrawalHalted { get; set; }
        public bool IsSweepEnabled { get; set; }
        public bool OnlyPositionClosingTrades { get; set; }
        public bool DepositHalted { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string AccountType { get; set; }

        // Special Memorandum Account; Both of these values can be null if not using margin
        public decimal? Sma { get; set; }
        public decimal? SmaHeldForOrders { get; set; }
        public decimal BuyingPower { get; set; }
        public decimal Cash { get; set; }
        public decimal CashHeldForOrders { get; set; }
        public decimal UnclearedDeposits { get; set; }
        public decimal UnsettledFunds { get; set; }

        public MarginBalance MarginBalance { get; set; }
        public CashBalance CashBalance { get; set; }

        public Url<AccountPortfolio> PortfolioUrl { get; set; }

        public Url<User> UserUrl { get; set; }

        public Url<Account> AccountUrl { get; set; }
        public Url<AccountPositions> PositionsUrl { get; set; }

        public string AccountNumber { get; set; }

        public decimal MaxAchEarlyAccessAmount { get; set; }
        
        public decimal? DTBP
        {
            get
            {
                if (MarginBalance != null)
                {
                    return (MarginBalance.DayTradeBuyingPower);
                }
                else return null;
            }
        }

        // If on cash account, only count settled funds
        public decimal EffectiveCash
        {
            get
            {
            if (MarginBalance != null)
            {
                return (MarginBalance.UnallocatedMarginCash);
            }
            else return Cash;
            }
        }

        // Returns how much buying power is available to buy shares
        // Uses the lower of buying power or available funds.

        /*
        todo: adjust effective buying power to the lowest of the following:
         - BuyingPower
         - EffectiveCash
         - DTBP / Instrument.DayTradeRatio (if DTBP != null)
         - Portfolio.ExcessMargin / Instrument.InitialMarginRatio
         - MarginLimit + Portfolio.Equity - Portfolio.MarketValue

         - input: Instrument
         
        */
        public decimal EffectiveBuyingPower
        {
            get
            {
                if (MarginBalance != null)
                {
                    return Math.Min(MarginBalance.UnallocatedMarginCash, BuyingPower);
                }
                else return CashBalance.BuyingPower;
            }
        }
         
        // cashonly = if true, use settled funds to calculate buyable shares
        public decimal GetBuyableShares(decimal price, bool cashonly = false)
        {
            // Zero or negative priced shares cannot be bought
            if (price <= 0) return 0;

            decimal cash_available = Cash;
            if (cashonly)
            {
                cash_available = Cash;
            }
            else
            {
                cash_available = EffectiveBuyingPower;
            }

            decimal shares = Decimal.Floor(cash_available / price);

            return shares;
        }

        public Account()
        {
            CashBalance = new CashBalance();
        }

        internal Account(Newtonsoft.Json.Linq.JToken json) : this()
        {
            IsDeactivated = (bool)json["deactivated"];
            IsWithdrawalHalted = (bool)json["withdrawal_halted"];
            IsSweepEnabled = (bool)json["sweep_enabled"];
            DepositHalted = (bool)json["deposit_halted"];
            OnlyPositionClosingTrades = (bool)json["only_position_closing_trades"];

            UpdatedAt = (DateTime)json["updated_at"];

            AccountUrl = new Url<Account>((string)json["url"]);
            PortfolioUrl = new Url<AccountPortfolio>((string)json["portfolio"]);
            UserUrl = new Url<User>((string)json["user"]);
            PositionsUrl = new Url<AccountPositions>((string)json["positions"]);

            AccountNumber = (string)json["account_number"];
            AccountType = (string)json["type"];

            Sma = (decimal?)json["sma"];
            SmaHeldForOrders = (decimal?)json["sma_held_for_orders"];
            BuyingPower = (decimal)json["buying_power"];
            Cash = (decimal)json["cash"];
            CashHeldForOrders = (decimal)json["cash_held_for_orders"];
            UnclearedDeposits = (decimal)json["uncleared_deposits"];
            UnsettledFunds = (decimal)json["unsettled_funds"];

            // mark MarginBalance, CashBalance null if they do not exist

            try { CashBalance = new CashBalance(json["cash_balances"]); }
            catch { CashBalance = null; }

            try { MarginBalance = new MarginBalance(json["margin_balances"]); }
            catch { MarginBalance = null; }

            MaxAchEarlyAccessAmount = (decimal)json["max_ach_early_access_amount"];
        }
    }
    
}
