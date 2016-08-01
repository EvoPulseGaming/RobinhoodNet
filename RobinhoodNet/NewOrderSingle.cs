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

    public class NewOrderSingle
    {
        public Url<Account> AccountUrl { get; set; }

        public string Symbol { get; set; }

        public Url<Instrument> InstrumentUrl { get; set; }

        public TimeInForce TimeInForce { get; set; }

        public TriggerType Trigger { get; set; }

        public OrderType OrderType { get; set; }

        public Side Side { get; set; }

        public int Quantity { get; set; }

        private decimal _price;
        public decimal Price
        {
            get
            {
                // if order price is over 1 dollar, requires 2 decimal places of precision
                if (_price >= 1.00m)
                    _price = Math.Round(_price,2); 
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public decimal? StopPrice { get; set; }

        public NewOrderSingle()
        {
            TimeInForce = TimeInForce.GoodForDay;
            Side        = Side.Buy;
            Trigger     = TriggerType.Immediate;
            OrderType   = OrderType.Limit;
        }

        public NewOrderSingle(Instrument instrument) : this()
        {
            Symbol        = instrument.Symbol;
            InstrumentUrl = instrument.InstrumentUrl;
        }

        internal IDictionary<string, string> ToDictionary()
        {
            var d = new Dictionary<string, string>();
            d.Add("account", this.AccountUrl.ToString());
            d.Add("symbol", this.Symbol);
            d.Add("instrument", this.InstrumentUrl.ToString());

            if (this.TimeInForce == TimeInForce.GoodForDay)
            {
                d.Add("time_in_force", "gfd");
            }
            else if (this.TimeInForce == TimeInForce.GoodTillCancel)
            {
                d.Add("time_in_force", "gtc");
            }

            d.Add("trigger", this.Trigger.ToString().ToLowerInvariant());
            d.Add("type", this.OrderType.ToString().ToLowerInvariant());
            d.Add("side", this.Side.ToString().ToLowerInvariant());
            d.Add("quantity", this.Quantity.ToString());
            d.Add("price", this.Price.ToString());

            if(this.StopPrice.HasValue)
            {
              d.Add("stop_price", this.StopPrice.Value.ToString());
            }

            return d;
        }

    }
    
}
