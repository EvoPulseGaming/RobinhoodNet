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
        DownloadOrders(string cursor = null)
        {
            string url = cursor ?? ORDERS_URL;
            return doGet(url);
        }

        public async Task<JToken>
        DownloadOrders(DateTime updateAt)
        {
            var b = new UriBuilder(ORDERS_URL);
            b.Query = "updated_at=" + updateAt.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
            return await doGet(b.Uri);
        }

        public Task<JToken>
        DownloadOrder(string order)
        {
            var b = new UriBuilder(ORDERS_URL);
            b.Path = b.Path + order + "/";
            return doGet(b.Uri);
        }

        public async Task
        CancelOrder(string orderCancelUrl)
        {
            var r = await doPost_NativeResponse(orderCancelUrl).ConfigureAwait (false);
            r.EnsureSuccessStatusCode();
        }

        public Task<JToken>
        PlaceOrder(IDictionary<string, string> newOrderSingle)
        {
            return doPost(ORDERS_URL, newOrderSingle);
        }
    }
}
