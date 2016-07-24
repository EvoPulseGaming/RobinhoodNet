using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicallyMe.RobinhoodNet
{
    class UserInvestmentProfile
    {
        string AnnualIncome { get; set; }
        string InvestmentExperience { get; set; }
        DateTime UpdatedAt { get; set; }
        string RiskTolerence { get; set; }
        string TotalNetWorth { get; set; }
        string LiquidityNeeds { get; set; }
        string InvestmentObj { get; set; }
        string SourceOfFunds { get; set; }
        Url<User> User { get; set; }
        bool SuitabilityVerified { get; set; }
        string TaxBracket { get; set; }
        string TimeHorizon { get; set; }
        string LiquidNetWorth { get; set; }

        public UserInvestmentProfile() { }

        internal UserInvestmentProfile(Newtonsoft.Json.Linq.JToken json) : this()
        {
            AnnualIncome = (string)json["annual_income"];
            InvestmentExperience = (string)json["investment_experience"];
            UpdatedAt = (DateTime)json["updated_at"];
            RiskTolerence = (string)json["risk_tolerence"];
            TotalNetWorth = (string)json["total_net_worth"];
            LiquidityNeeds = (string)json["liquidity_needs"];
            InvestmentObj = (string)json["investment_obj"];
            SourceOfFunds = (string)json["source_of_funds"];
            User = new Url<User>((string)json["user"]);
            SuitabilityVerified = (bool)json["suitability_verified"];
            TaxBracket = (string)json["tax_bracket"];
            TimeHorizon = (string)json["time_horizon"];
            LiquidNetWorth = (string)json["liquid_net_worth"];
        }
    }
}
