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
    public class Position
    {
        [JsonProperty("account")] //"": "https://api.robinhood.com/accounts/5QR41236/",
        public Url<Account> AccountUrl
        {
            get;
            set;
        }

        [JsonProperty("instrument")] //: "https://api.robinhood.com/instruments/f74acd18-c8a1-4851-abd3-7b6e82d0cbce/",
        public Url<Instrument> InstrumentUrl
        {
            get;
            set;
        }

        [JsonProperty("url")] //: "https://api.robinhood.com/accounts/5QR41236/positions/f74acd18-c8a1-4851-abd3-7b6e82d0cbce/",
        public Url<Position> PositionUrl
        {
            get;
            set;
        }

        [JsonProperty("created_at")] //: "2015-10-23T15:32:33.886255Z",
        public DateTime CreatedAt
        {
            get;
            set;
        }

        [JsonProperty("updated_at")] //: "2015-10-23T16:31:36.949434Z",
        public DateTime UpdatedAt
        {
            get;
            set;
        }


        [JsonProperty("intraday_quantity")] //: "0.0000",
        public decimal IntradayQuantity
        {
            get;
            set;
        }

        [JsonProperty("cost_basis")] //: "90.5000",
        public decimal CostBasis
        {
            get;
            set;
        }

        [JsonProperty("average_buy_price")] //: "18.1000",
        public decimal AverageBuyPrice
        {
            get;
            set;
        }

        [JsonProperty("quantity")] //: "5.0000"
        public decimal Quantity
        {
            get;
            set;
        }

        [JsonProperty("shares_held_for_buys")] //: "0.0000",
        public decimal SharesHeldForBuys
        {
            get;
            set;
        }

        [JsonProperty("shares_held_for_sells")] //: "5.0000",
        public decimal SharesHeldForSells
        {
            get;
            set;
        }

        public Position()
        {
        }

        internal Position(Newtonsoft.Json.Linq.JToken json) : this()
        {

            AccountUrl = new Url<Account>((string)json["account"]);
            InstrumentUrl = new Url<Instrument>((string)json["instrument"]);
            Url = new Url<Position>((string)json["url"]);

            CreatedAt = (DateTime)json["created_at"];
            UpdatedAt = (DateTime)json["updated_at"];

            IntradayQuantity = (decimal)json["intraday_quantity"];
            AverageBuyPrice = (decimal)json["average_buy_price"];
            Quantity = (decimal)json["quantity"];
            SharesHeldForBuys = (decimal)json["shares_held_for_buys"];
            SharesHeldForSells = (decimal)json["shares_held_for_sells"];
        }
    }
}
