using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicallyMe.RobinhoodNet
{
    class UserIdInfo
    {
        // id info
        Url<User> Url { get; set; }
        string Username { get; set; }
        string Id { get; set; }

        public UserIdInfo() { }

        internal UserIdInfo(Newtonsoft.Json.Linq.JToken json) : this()
        {
            Url = new Url<User>((string)json["user"]);
            Username = (string)json["username"];
            Id = (string)json["id"];
        }
    }
}
