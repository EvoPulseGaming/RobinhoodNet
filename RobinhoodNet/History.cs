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
using Newtonsoft.Json.Linq;

namespace BasicallyMe.RobinhoodNet
{
    public class Historicals
    {
        public DateTime BeginsAt { get; set; }

        public decimal OpenPrice { get; set; }
        public decimal ClosePrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }

        public int Volume { get; set; }

        public string Session { get; set; }

        public bool Interpolated { get; set; }


        public Historicals ()
        {
        }

        internal Historicals (JToken json)
        {
            if (json ["begins_at"] != null)
                this.BeginsAt = (DateTime)json ["begins_at"];

            if (json ["open_price"] != null)
                this.OpenPrice = (decimal)json ["open_price"];

            if (json ["close_price"] != null)
                this.ClosePrice = (decimal)json ["close_price"];

            if (json ["high_price"] != null)
                this.HighPrice = (decimal)json ["high_price"];

            if (json ["low_price"] != null)
                this.LowPrice = (decimal)json ["low_price"];

            if (json ["volume"] != null)
                this.Volume = (int)json ["volume"];

            if (json ["session"] != null)
                this.Session = (string)json ["session"];

            if (json ["interpolated"] != null)
                this.Interpolated = (bool)json ["interpolated"];
        }
    }



    public class History
	{
        public string Symbol { get; set; }
        public string BeginsAt { get; set; }

        public string Interval { get; set; }
        public string     Span  { get; set; }

        public string Bounds { get; set; }

        public Url<Instrument> Instrument { get; set; }

        public List<Historicals> HistoricalInfo { get; set; }

        public History ()
        {
        }

        internal History (JToken json)
        {
          if(json["symbol"]!=null)
            this.Symbol = (string)json["symbol"];

          if (json["interval"] != null)
            this.Interval = (string)json["interval"];

          if (json["span"] != null)
            this.Span = (string)json["span"];

          if (json["bounds"] != null)
            this.Bounds = (string)json["bounds"];

          if (json["instrument"] != null)
                this.Instrument = new Url<Instrument>((string)json["instrument"]);

          if (json ["historicals"] != null) 
          {
              HistoricalInfo = new List<Historicals> ();
              foreach (var o in (JArray)(json ["historicals"])) 
              {
                  Historicals h = null;
                  if (o != null && o.HasValues) 
                  {
                      h = new Historicals (o);
                      HistoricalInfo.Add (h);
                  }
              }
          }         
       }
	}
}
