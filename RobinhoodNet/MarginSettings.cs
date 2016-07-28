
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BasicallyMe.RobinhoodNet
{

    public class MarginSettings
    {
        public bool Leverage { get; set; }
        public bool AdvancedBuyingPower { get; set; }
        public string DayTrades { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public MarginSettings() { }

        internal MarginSettings(Newtonsoft.Json.Linq.JToken json) : this()
        {
            AdvancedBuyingPower = (bool)json["advanced_buying_power"];
            Leverage = (bool)json["leverage"];
            DayTrades = (string)json["day_trades"];
            CreatedAt = (DateTime)json["created_at"];
            UpdatedAt = (DateTime)json["updated_at"];
        }
    }
}
