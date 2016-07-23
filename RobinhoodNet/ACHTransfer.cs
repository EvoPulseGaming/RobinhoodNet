
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BasicallyMe.RobinhoodNet
{
    public class ACHTransfer
    {

        public bool Scheduled { get; set; }
        public string Direction { get; set; }
        public Url<ACHTransfer> Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public string State { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal Amount { get; set; }
        public decimal EarlyAccessAmount { get; set; }
        public decimal Fees { get; set; }
        public Url<ACHCancellation> Cancel { get; set; }
        public Url<ACHRelationship> ACHRelationship { get; set; }
        public DateTime ExpectedLandingDate { get; set; }
        public string StatusDescription { get; set; }
        public string Id { get; set; }

        public ACHTransfer()
        {
        }

        internal ACHTransfer(Newtonsoft.Json.Linq.JToken json) : this()
        {

            Scheduled = (bool)json["scheduled"];
            Direction = (string)json["direction"];
            Url = new Url<ACHTransfer>((string)json["url"]);
            CreatedAt = (DateTime)json["created_at"];
            State = (string)json["state"];
            UpdatedAt = (DateTime)json["updated_at"];
            Amount = (decimal)json["amount"];
            EarlyAccessAmount = (decimal)json["early_access_amount"];
            Fees = (decimal)json["fees"];
            Cancel = new Url<ACHCancellation>((string)json["cancel"]);
            ACHRelationship = new Url<ACHRelationship>((string)json["ach_relationship"]);
            ExpectedLandingDate = (DateTime)json["expected_landing_date"];
            StatusDescription = (string)json["status_description"];
            Id = (string)json["id"];
        }
    }
}
