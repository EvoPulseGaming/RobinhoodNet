
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BasicallyMe.RobinhoodNet
{
    public class ACHRelationship
    {
        public Url<Account> Account { get; set; }
        public string VerificationMethod { get; set; }
        public bool? VerifyMicroDeposits { get; set; }
        public Url<ACHRelationship> Url { get; set; }
        public string BankAccountNickname { get; set; }
        public DateTime CreatedAt { get; set; }
        public string BankAccountHolderName { get; set; }
        public int BankAccountNumber { get; set; }
        public string BankAccountType { get; set; }
        public DateTime? UnlinkedAt { get; set; }

        // Not sure what variable initialdesposit is
        public dynamic InitialDeposit { get; set; }

        public bool Verified { get; set; }
        public Url<BankUnlink> Unlink { get; set; }
        public string BankRoutingNumber { get; set; }
        public string Id { get; set; }

        public ACHRelationship()
        {
        }

        internal ACHRelationship(Newtonsoft.Json.Linq.JToken json) : this()
        {

            Account = new Url<Account>((string)json["account"]);
            VerificationMethod = (string)json["verification_method"];
            VerifyMicroDeposits = (bool?)json["verify_micro_deposits"];
            Url = new Url<ACHRelationship>((string)json["url"]);
            BankAccountNickname = (string)json["bank_account_nickname"];
            CreatedAt = (DateTime)json["created_at"];
            BankAccountHolderName = (string)json["bank_account_holder_name"];
            BankAccountNumber = (int)json["bank_account_number"];
            BankAccountType = (string)json["bank_account_type"];
            UnlinkedAt = (DateTime?)json["unlinked_at"];
            InitialDeposit = json["initial_deposit"];
            Verified = (bool)json["verified"];
            Unlink = new Url<BankUnlink>((string)json["unlink"]);
            BankRoutingNumber = (string)json["bank_routing_number"];
            Id = (string)json["id"];
        }
    }
}
