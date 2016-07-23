
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BasicallyMe.RobinhoodNet
{
    public class Dividend
    {
        Url<Account> Account { get; set; }
        Url<Dividend> Url { get; set; }
        decimal Amount { get; set; }
        DateTime PayableDate { get; set; }
        Url<Instrument> Instrument { get; set; }
        decimal Rate { get; set; }
        DateTime RecordDate { get; set; }
        decimal Position { get; set; }
        decimal Withholding { get; set; }
        string Id { get; set; }
        DateTime? PaidAt { get; set; }
        
    public Dividend()
        {
        }

        internal Dividend(Newtonsoft.Json.Linq.JToken json) : this()
        {
            Account = new Url<Account>((string)json["account"]);
            Url = new Url<Dividend>((string)json["url"]);
            Amount = (decimal)json["amount"];
            PayableDate = (DateTime)json["payable_date"];
            Instrument = new Url<Instrument>((string)json["instrument"]);
            Rate = (decimal)json["rate"];
            RecordDate = (DateTime)json["record_date"];
            Position = (decimal)json["position"];
            Withholding = (decimal)json["withholding"];
            Id = (string)json["id"];
            PaidAt = (DateTime?)json["paid_at"];
        }
    }
}
