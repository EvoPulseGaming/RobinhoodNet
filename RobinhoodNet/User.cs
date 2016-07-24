// The MIT License (MIT)
// 
// Copyright (c) 2015 Filip Frącz
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BasicallyMe.RobinhoodNet
{
    // TODO: Implement me!
	public class User
	{
        public string Username { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        Url<UserIdInfo> IdInfo { get; set; }
        Url<User> UserURL { get; set; }
        DateTime CreatedAt { get; set; }
        Url<UserBasicInfo> BasicInfo { get; set; }
        string email { get; set; }
        Url<UserInvestmentProfile> InvestmentProfile { get; set; }
        string id { get; set; }

        // returns not found
        //Url<UserInternationalInfo> InternationalInfo { get; set; }

        Url<UserEmployment> Employment { get; set; }
        Url<UserAdditionalInfo> AdditionalInfo { get; set; }
        
        public User() { }

        internal User(Newtonsoft.Json.Linq.JToken json) : this()
        {

            Username = (string)json["username"];
            FirstName = (string)json["first_name"];
            LastName = (string)json["last_name"];
            IdInfo = new Url<UserIdInfo>((string)json["id_info"]);
            UserURL = new Url<User>((string)json["user"]);
            CreatedAt = (DateTime)json["created_at"];
            BasicInfo = new Url<UserBasicInfo>((string)json["basic_info"]);
            email = (string)json["email"];
            InvestmentProfile = new Url<UserInvestmentProfile>((string)json["investment_profile"]);
            id = (string)json["id"];
            Employment = new Url<UserEmployment>((string)json["employment"]);
            AdditionalInfo = new Url<UserAdditionalInfo>((string)json["additional_info"]);
        }
}
}
