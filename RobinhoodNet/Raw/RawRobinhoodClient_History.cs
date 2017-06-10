using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace BasicallyMe.RobinhoodNet.Raw
{
    public partial class RawRobinhoodClient
    {
        // History Intervals { "week", "day", "10minute", "5minute" };
        // History Spans { "day", "week", "year", "all" };

        public async Task<JToken>
        DownloadHistory (string symbol, string interval, string span )
        {
            var b = new UriBuilder (HISTORY_URL);
            b.Query = "symbols=" + symbol + 
                      "&interval=" + interval +
                      "&span=" + span;

            var json = await doGet (b.Uri).ConfigureAwait (false);
            return json ["results"] [0];
        }    

        public async Task<JToken>
        DownloadHistory (IEnumerable<string> symbols, string interval, string span)
        {
            var b = new UriBuilder (HISTORY_URL);
            b.Query = "symbols=" + String.Join (",", symbols) +
                      "&interval=" + interval +
                      "&span=" + span;

            var json = await doGet (b.Uri).ConfigureAwait (false);

            return json ["results"];
        } 
    }
}
