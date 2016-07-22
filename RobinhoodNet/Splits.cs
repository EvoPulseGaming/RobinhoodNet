using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BasicallyMe.RobinhoodNet
{

    public class Splits
    {
        public Url<Splits> Url { get; set; }
        public Url<Instrument> Instrument { get; set; }
        public DateTime Execution_Date{ get; set; }
        public decimal Divisor { get; set; }
        public decimal Multiplier { get; set; }

        public Splits() { }

        internal Splits(Newtonsoft.Json.Linq.JToken json) : this()
        {
            Url = new Url<Splits>((string)json["url"]);
            Instrument = new Url<Instrument>((string)json["instrument"]);
            Execution_Date = (DateTime)json["execution_date"];
            Divisor = (decimal)json["divisor"];
            Multiplier = (decimal)json["multiplier"];
        }
    }
}
