using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicallyMe.RobinhoodNet
{
    class UserAdditionalInfo
    {
        string ScurityAffiliatedFirmRelationship { get; set; }
        bool SecurityAffiliatedEmployee { get; set; }
        string SecurityAffiliatedAddress { get; set; }
        bool ObjectToDisclosure { get; set; }
        DateTime UpdatedAt { get; set; }
        bool ControlPerson { get; set; }
        bool SweepConsent { get; set; }
        Url<User> User { get; set; }
        string ControlPersonSecuritySymbol { get; set; }
        string SecurityAffiliatedFirmName { get; set; }
        string SecurityAffiliatedPersonName { get; set; }

        public UserAdditionalInfo() { }


        internal UserAdditionalInfo(Newtonsoft.Json.Linq.JToken json) : this()
        {
            ScurityAffiliatedFirmRelationship = (string)json["security_affiliated_firm_relationship"];
            SecurityAffiliatedEmployee = (bool)json["security_affiliated_employee"];
            SecurityAffiliatedAddress = (string)json["security_affiliated_address"];
            ObjectToDisclosure = (bool)json["object_to_disclosure"];
            UpdatedAt = (DateTime)json["updated_at"];
            ControlPerson = (bool)json["control_person"];
            SweepConsent = (bool)json["sweep_consent"];
            User = new Url<User>((string)json["user"]);
            ControlPersonSecuritySymbol = (string)json["control_person_security_symbol"];
            SecurityAffiliatedFirmName = (string)json["security_affiliated_firm_name"];
            SecurityAffiliatedPersonName = (string)json["security_affiliated_person_name"];
        }
    }
}
