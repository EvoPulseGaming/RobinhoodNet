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
	public class InstrumentSplit
	{        
        [JsonProperty("url")] //: "https://api.robinhood.com/instruments/450dfc6d-5510-4d40-abfb-f633b7d9be3e/splits/93657cb7-478b-42b0-a23c-9a64042cb694/",
        public Url<InstrumentSplit> InstrumentSplitUrl
        {
            get;
            set;
        }

        [JsonProperty("instrument")] //: "https://api.robinhood.com/instruments/450dfc6d-5510-4d40-abfb-f633b7d9be3e/",
        public Url<Instrument> InstrumentUrl
        {
            get;
            set;
        }
            
        [JsonProperty("execution_date")] //: "2014-06-09",
        public DateTime ExecutionDate
        {
            get;
            set;
        }

        [JsonProperty("divisor")] //: "1.00000000",
        public decimal Divisor
        {
            get;
            set;
        }

        [JsonProperty("multiplier")] //: "7.00000000"
        public decimal Multiplier
        {
            get;
            set;
        }
	}
}
