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
          DownloadPositions(string cursor = null)
        {
            string url = cursor ?? POSITIONS_URL;
            return doGet(url);
        }

        // positions for an instrument can be downloaded via the following:
        // accounts/{account}/positions/instrument/

        public Task<JToken>
          DownloadSinglePosition(string account, string instrument)
        {
            var b = new UriBuilder(ACCOUNTS_URL);
            b.Path += account + "/positions/" + instrument + "/";
            //b.Query = "instrument=" + instrument;
            return doGet(b.Uri);
        }

        public Task<JToken>
          DownloadSinglePosition(string url)
        {
            return doGet(url);
        }
    }
}
