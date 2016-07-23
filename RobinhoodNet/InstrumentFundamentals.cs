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
	public class InstrumentFundamentals
	{
        
        public decimal? Open { get; set; }
        public decimal? High { get; set; }
        public decimal? Low { get; set; }
        public decimal Volume { get; set; }
        public decimal AverageVolume { get; set; }
        public decimal High52Weeks { get; set; }
        public decimal? DividendYield { get; set; }
        public decimal Low52Weeks { get; set; }
        public decimal MarketCap { get; set; }
        public decimal? PERatio { get; set; }
        public string Description { get; set; }
        public Url<Instrument> Instrument { get; set; }

        public InstrumentFundamentals() { }

        internal InstrumentFundamentals(Newtonsoft.Json.Linq.JToken json) : this()
        {
            Open = (decimal?)json["open"];
            High = (decimal?)json["high"];
            Low = (decimal?)json["low"];
            Volume = (decimal)json["volume"];
            AverageVolume = (decimal)json["average_volume"];
            High52Weeks = (decimal)json["high_52_weeks"];
            DividendYield = (decimal?)json["dividend_yield"];
            Low52Weeks = (decimal)json["low_52_weeks"];
            MarketCap = (decimal)json["market_cap"];
            PERatio = (decimal?)json["pe_ratio"];
            Description = (string)json["description"];
            Instrument = new Url<Instrument>((string)json["instrument"]);
        }

    }
}
