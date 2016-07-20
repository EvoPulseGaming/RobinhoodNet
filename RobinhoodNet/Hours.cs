using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicallyMe.RobinhoodNet
{
    // DateTime values can be null on a date the market is not open.
    public class Hours
    {
        public DateTime   Date { get; set; }
        public DateTime?  OpensAt { get; set; }
        public DateTime?  ClosesAt { get; set; }
        public DateTime?  ExtendedOpensAt { get; set; }
        public DateTime?  ExtendedClosesAt { get; set; }
        public Url<Hours> NextOpenHours { get; set; }
        public Url<Hours> PreviousOpenHours { get; set; }
        public bool IsOpen { get; set; }

        public Hours()
        {
        }

        internal Hours(Newtonsoft.Json.Linq.JToken json) : this()
        {
            Date              = (DateTime) json["date"];
            OpensAt           = (DateTime) json["opens_at"];
            ClosesAt          = (DateTime) json["closes_at"];
            ExtendedOpensAt   = (DateTime) json["extended_opens_at"];
            ExtendedClosesAt  = (DateTime) json["extended_closes_at"];
            NextOpenHours     = new Url<Hours>((string)json["next_open_hours"]);
            PreviousOpenHours = new Url<Hours> ((string)json["previous_open_hours"]);
        }

    }
}

