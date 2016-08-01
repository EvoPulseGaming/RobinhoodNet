using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace BasicallyMe.RobinhoodNet.Raw
{
    public partial class RawRobinhoodClient
    {
        public Task<JToken>
        DownloadPortfolio(string account)
        {
            string url = PORTFOLIOS_URL + account + "/";
            return doGet(url);
        }
    }
}
