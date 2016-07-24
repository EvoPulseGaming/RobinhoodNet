using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicallyMe.RobinhoodNet
{
    class UserEmployment
    {
        string EmployerZipcode { get; set; }
        string EmploymentStatus { get; set; }
        DateTime UpdatedAt { get; set; }
        string EmployerName { get; set; }
        Url<User> User { get; set; }
        int? YearsEmployed { get; set; }
        string EmployerState { get; set; }
        string EmployerCity { get; set; }
        string Occupation { get; set; }

        public UserEmployment() { }

        internal UserEmployment(Newtonsoft.Json.Linq.JToken json) : this()
        {
            EmployerZipcode = (string)json["employer_zipcode"];
            EmploymentStatus = (string)json["employment_status"];
            UpdatedAt = (DateTime)json["updated_at"]; ;
            EmployerName = (string)json["employer_name"];
            User = new Url<User>((string)json["user"]);
            YearsEmployed = (int?)json["years_employed"];
            EmployerState = (string)json["employer_state"];
            EmployerCity = (string)json["employer_city"];
            Occupation = (string)json["occupation"];
        }
    }
}
