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
using Newtonsoft.Json;

namespace BasicallyMe.RobinhoodNet
{

    public class NewOrderSingle
    {
        [JsonProperty("account")]
        [JsonConverter(typeof(TypedUrlConverter<Account>))]
        public Url<Account> AccountUrl { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("instrument")]
        [JsonConverter(typeof(TypedUrlConverter<Instrument>))]
        public Url<Instrument> InstrumentUrl { get; set; }

        [JsonProperty("time_in_force")]
        public TimeInForce TimeInForce { get; set; }

        [JsonProperty("trigger")]
        public string Trigger { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(OrderTypeConverter))]
        public OrderType OrderType { get; set; }

        [JsonProperty("side")]
        [JsonConverter(typeof(SideConverter))]
        public Side Side { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("price")]
        public decimal? Price { get; set; }

        public NewOrderSingle ()
        {
            TimeInForce = TimeInForce.GoodForDay;
            Side = Side.Buy;
            Trigger = "immediate";
            OrderType = OrderType.Limit;
        }

        public NewOrderSingle (Instrument instrument)
            : this()
        {
            Symbol = instrument.Symbol;
            InstrumentUrl = instrument.InstrumentUrl;
        }

        internal IDictionary<string, string> ToDictionary ()
        {
            // TODO: Base this off the JsonProperty attributes
            //       or just call the serializer. JObject should
            //       implement IDictionary

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

            d.Add("trigger", this.Trigger);
            d.Add("type", this.OrderType.ToString().ToLowerInvariant());
            d.Add("side", this.Side.ToString().ToLowerInvariant());
            d.Add("quantity", this.Quantity.ToString());

            if (this.Price.HasValue)
            {
                d.Add("price", this.Price.Value.ToString());
            }

            return d;
        }

    }

}
