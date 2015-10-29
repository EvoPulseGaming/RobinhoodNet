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
    public class Instrument
    {
        [JsonProperty("splits")]
        [JsonConverter(typeof(TypedUrlConverter<InstrumentSplit>))]
        public Url<InstrumentSplit>  InstrumentSplitsUrl { get; set; }

        [JsonProperty("margin_initial_ratio")]
        public decimal MarginInitialRatio { get; set; }

        [JsonProperty("url")]
        [JsonConverter(typeof(TypedUrlConverter<Instrument>))]
        public Url<Instrument> InstrumentUrl { get; set; }

        [JsonProperty("quote")]
        [JsonConverter(typeof(TypedUrlConverter<Quote>))]
        public Url<Quote> QuoteUrl { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("bloomberg_unique")]
        public string BloombergUnique { get; set; }

        [JsonProperty("fundamentals")]
        [JsonConverter(typeof(TypedUrlConverter<InstrumentFundamentals>))]
        public Url<InstrumentFundamentals> InstrumentFundamentalsUrl { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("tradeable")]
        public bool IsTradeable { get; set; }

        [JsonProperty("maintenance_ratio")]
        public decimal MaintenanceRatio { get; set; }

        [JsonProperty("market")]
        [JsonConverter(typeof(TypedUrlConverter<Market>))]
        public Url<Market> MarketUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }


        public Instrument ()
        {
        }
    }


}
