using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicallyMe.RobinhoodNet.DataTypes
{
    public class ChallengeDetails
    {
        public string id;
        public string user;
        public string type;
        public string alternate_type;
        public string status;
        public int remaining_retries;
        public int remaining_attempts;
        public string expires_at;
    }
}
