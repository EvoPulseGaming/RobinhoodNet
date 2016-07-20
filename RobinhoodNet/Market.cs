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
    // TODO: Implement me!
	public class Market
    {
        public string       Website { get; set; }
        public string       City { get; set; }
        public string       Name { get; set; }
        public Url<Market>  Url { get; set; }
        public string       Country { get; set; }
        public Url<Hours>   TodaysHours { get; set; }
        public string       OperatingMic { get; set; }
        public string       Acronym { get; set; }
        public string       Timezone { get; set; }
        public string       Mic { get; set; }
        
        public Market()
        {
        }

        internal Market(Newtonsoft.Json.Linq.JToken json) : this()
        {
            Website      = (string)json["website"];
            City         = (string)json["city"];
            Name         = (string)json["name"];
            Url          = new Url<Market>((string)json["url"]);
            Country      = (string)json["country"];
            TodaysHours  = new Url<Hours>((string)json["todays_hours"]);
            OperatingMic = (string)json["operating_mic"];
            Acronym      = (string)json["acronym"];
            Timezone     = (string)json["timezone"];
            Mic = (string)json["mic"];
        }
    }
}
