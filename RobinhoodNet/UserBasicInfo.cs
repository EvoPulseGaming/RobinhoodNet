using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicallyMe.RobinhoodNet
{
    class UserBasicInfo
    {
        string PhoneNumber { get; set; }
        string City { get; set; }
        int NumberDependents { get; set; }
        string Citizenship { get; set; }
        DateTime UpdatedAt { get; set; }
        string MaritalStatus { get; set; }
        string Zipcode { get; set; }
        string CountryOfResidence { get; set; }
        string State { get; set; }
        DateTime DateOfBirth { get; set; }
        Url<User> User { get; set; }
        string Address { get; set; }
        string TaxIDSSN { get; set; }

        public UserBasicInfo() { }

        internal UserBasicInfo(Newtonsoft.Json.Linq.JToken json) : this()
        {
            PhoneNumber = (string)json["phone_number"];
            City = (string)json["city"];
            NumberDependents = (int)json["number_dependents"]; ;
            Citizenship = (string)json["citizenship"];
            UpdatedAt = (DateTime)json["updated_at"];
            MaritalStatus = (string)json["marital_status"];
            Zipcode = (string)json["zipcode"];
            CountryOfResidence = (string)json["country_of_residence"];
            State = (string)json["state"];
            DateOfBirth = (DateTime)json["date_of_birth"];
            User = new Url<User>((string)json["user"]);
            Address = (string)json["address"];
            TaxIDSSN = (string)json["tax_id_ssn"];
        }
    }
}
