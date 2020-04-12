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
	public class InstrumentFundamentals
	{        
        [JsonProperty("open")] //: "103.9000",
        public decimal Open
        {
            get;
            set;
        }

        [JsonProperty("high")] //: "104.4800",
        public decimal High
        {
            get;
            set;
        }
            
        [JsonProperty("low")] //: "102.9200",
        public decimal Low
        {
            get;
            set;
        }


        [JsonProperty("volume")] //: "24081515.0000",
        public decimal Volume
        {
            get;
            set;
        }


        [JsonProperty("average_volume")] //: "28043669.7610",
        public decimal AverageVolume
        {
            get;
            set;
        }


        [JsonProperty("high_52_weeks")] //: "104.4800",
        public decimal High52Weeks
        {
            get;
            set;
        }


        [JsonProperty("dividend_yield")] //: "0.0000",
        public decimal DividendYield
        {
            get;
            set;
        }


        [JsonProperty("low_52_weeks")] //: "72.0000",
        public decimal Low52Weeks
        {
            get;
            set;
        }


        [JsonProperty("market_cap")] //: "292008780000.0000",
        public decimal MarketCap
        {
            get;
            set;
        }


        [JsonProperty("pe_ratio")] //: "105.8900",
        public decimal PERatio
        {
            get;
            set;
        }


        [JsonProperty("description")] //: "Facebook, Inc. is a social networking service and website. Its website allows people to communicate with their family, friends, and coworkers. The company offers advertisers a combination of reach, relevance, social context, and engagement to enhance the value of their ads. Its services include timeline, news feed, messages, lists, ticker and mobile apps. Facebook was founded by Mark Elliot Zuckerberg, Dustin Moskovitz, Chris R. Hughes, Andrew McCollum and Eduardo P. Saverin on February 4, 2004 and is headquartered in Menlo Park, CA."
        public string Description
        {
            get;
            set;
        }
        public Url<Instrument> Instrument { get; set; }

        public InstrumentFundamentals() { }

        internal InstrumentFundamentals(Newtonsoft.Json.Linq.JToken json) : this()
        {
            Open = (decimal)json["open"];
            High = (decimal)json["high"];
            Low = (decimal)json["low"];
            Volume = (decimal)json["volume"];
            AverageVolume = (decimal)json["average_volume"];
            High52Weeks = (decimal)json["high_52_weeks"];
            DividendYield = (decimal)json["dividend_yield"];
            Low52Weeks = (decimal)json["low_52_weeks"];
            MarketCap = (decimal)json["market_cap"];
            PERatio = (decimal)json["pe_ratio"];
            Description = (string)json["description"];
            Instrument = new Url<Instrument>((string)json["instrument"]);
        }

    }
}
