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

using System.Linq;
using Newtonsoft.Json.Linq;
using BasicallyMe.RobinhoodNet.DataTypes;

namespace BasicallyMe.RobinhoodNet
{
    public partial class RobinhoodClient
    {
        Raw.RawRobinhoodClient _rawClient;


        public RobinhoodClient ()
        {
            _rawClient = new Raw.RawRobinhoodClient();
        }

        public RobinhoodClient(string token)
        {
            _rawClient = new Raw.RawRobinhoodClient();
            Authenticate(token);
        }
        public string AuthToken
        {
            get { return _rawClient.AuthToken; }
        }

        public string RefreshToken
        {
            get { return _rawClient.RefreshToken; }
        }

        public string GenerateDeviceToken()
        {
            return _rawClient.GenerateDeviceToken();
        }

        public (bool, ChallengeInfo) Authenticate (string userName, string password, string deviceToken, string challengeID)
        {
            return _rawClient.Authenticate(userName, password, deviceToken, challengeID).Result;
        }

        public bool Authenticate(string token)
        {
            return _rawClient.Authenticate(token).Result;
        }

        public (bool, ChallengeInfo) ChallengeResponse(string id, string code)
        {
            return _rawClient.ChallengeResponse(id, code).Result;
        }

        public bool isAuthenticated
        {
            get
            {
                if (_rawClient.AuthToken != null) return true;
                else return false;
            }
        }

        async Task<IList<TResult>>
        downloadAll<TResult>(Func<PagedResponse<TResult>.Cursor, Task<PagedResponse<TResult>>> downloadSingle)
        {
            var all = new List<TResult>();

            PagedResponse<TResult>.Cursor cursor = null;
            PagedResponse<TResult> r = null;
            do
            {
              r = await downloadSingle(cursor).ConfigureAwait(continueOnCapturedContext: false);
                all.AddRange(r.Items);
                cursor = r.Next;

            } while (cursor != null);

            return all;
        }

        async Task<PagedResponse<TResult>>
        downloadPagedResult<TResult> (
            PagedResponse<TResult>.Cursor cursor,
            Func<string, Task<JToken>> downloader,
            Func<JToken, TResult> decoder)
        {
            var resp = await downloader(cursor == null ? null : cursor.Uri.ToString()).ConfigureAwait(continueOnCapturedContext: false);
            var result = new PagedJsonResponse<TResult>(resp, decoder);
            return result;
        }

        public IList<Position>
          DownloadPositions(string url, PagedResponse<Position>.Cursor cursor = null)
        {
          cursor = new PagedResponse<Position>.Cursor(url);
          List<Position> list = new List<Position>();
          while(true)
          {
            var result = downloadPagedResult<Position>(cursor, _rawClient.DownloadPositions, json => new Position(json));
            if (result.Result != null && result.Result.Items != null)
              list.AddRange(result.Result.Items);
            if (result.Result == null || result.Result.Next == null)
              break;
            cursor = result.Result.Next;
          }

          return list;
        }

        public async Task<Position>
        DownloadSinglePosition(string account, string instrument)
        {
            var json = await _rawClient.DownloadSinglePosition(account, instrument).ConfigureAwait (false);
            return new Position(json);
        }


        public async Task<AccountPortfolio>
        DownloadSinglePortfolio(string account)
        {
            var json = await _rawClient.DownloadPortfolio(account).ConfigureAwait (false);
            return new AccountPortfolio(json);
        }


        public Task<IList<Account>>
        DownloadAllAccounts ()
        {
            return downloadAll<Account>(this.DownloadAccounts);
        }

        public Task<PagedResponse<Account>>
        DownloadAccounts(PagedResponse<Account>.Cursor cursor = null)
        {
            return downloadPagedResult<Account>(
                cursor,
                _rawClient.DownloadAccounts,
                json => json.ToObject<Account>());
        }


        public Task<IList<OrderSnapshot>>
        DownloadAllOrders ()
        {
            return downloadAll<OrderSnapshot>(this.DownloadOrders);
        }

        public async Task<IList<OrderSnapshot>>
        DownloadOrders(DateTime updatedAt)
        {
            var json = await _rawClient.DownloadOrders(updatedAt).ConfigureAwait (false);
            var result = new PagedJsonResponse<OrderSnapshot>(json, item => new OrderSnapshot(item));
            return result.Items;
        }

        public Task<PagedResponse<OrderSnapshot>>
        DownloadOrders (PagedResponse<OrderSnapshot>.Cursor cursor = null)
        {
            return downloadPagedResult<OrderSnapshot>(
                cursor,
                _rawClient.DownloadOrders,
                json => json.ToObject<OrderSnapshot>());
        }

        public async Task<OrderSnapshot>
        DownloadSingleOrder(string Order)
        {
            var json = await _rawClient.DownloadOrder(Order).ConfigureAwait (false);
            return new OrderSnapshot(json);
        }

        public async Task<OrderSnapshot>
        PlaceOrder (NewOrderSingle newOrderSingle)
        {
            var json = await _rawClient.PlaceOrder(newOrderSingle.ToDictionary());
            return json.ToObject<OrderSnapshot>();
        }

        public Task
        CancelOrder (Url<OrderCancellation> cancellationUrl)
        {
            return _rawClient.CancelOrder(cancellationUrl.Uri.ToString());
        }


        public async Task<Instrument>
        DownloadInstrument (Url<Instrument> instrumentUrl)
        {
            var json = await _rawClient.DownloadInstrument(instrumentUrl.Uri.ToString()).ConfigureAwait (false);
            return new Instrument(json);
        }

        public async Task<IList<Instrument>>
        FindInstrument (string symbol)
        {
            var resp = await _rawClient.FindInstrument(symbol).ConfigureAwait (false);
            var result = new PagedJsonResponse<Instrument>(resp, item => new Instrument(item));
            return result.Items;
        }

        public async Task<Quote>
        DownloadQuote (string symbol)
        {
            var q = await _rawClient.DownloadQuote(symbol).ConfigureAwait (false);
            return q.ToObject<Quote>();
        }

        public async Task<Quote>
          DownloadInstrument(string InstrumentURL)
        {
          var q = await _rawClient.DownloadInstrument(InstrumentURL).ConfigureAwait (false);
          return new Quote(q);
        }

        public async Task<IList<Quote>>
        DownloadQuote (IEnumerable<string> symbols)
        {
            var qq = await _rawClient.DownloadQuote(symbols).ConfigureAwait (false);

            List<Quote> quotes = new List<Quote>();
            foreach (var o in (JArray)qq)
            {
                Quote q = null;
                if (o != null && o.HasValues)
                {
                    q = o.ToObject<Quote>();
                }
                quotes.Add(q);
            }

            return quotes;
        }

        public Task<IList<Quote>>
        DownloadQuote (params string[] symbols)
        {
            return DownloadQuote((IEnumerable<string>)symbols);
        }


        public async Task<History>
        DownloadHistory (string symbol, string interval = "10minute", string span = "day", string bounds = "trading")
        {
            var q = await _rawClient.DownloadHistory (symbol, interval, span, bounds).ConfigureAwait (false);
            return new History (q);
        }

        public async Task<IList<History>>
        DownloadHistory (IEnumerable<string> symbols, string interval = "10minute", string span="day", string bounds = "trading")
        {
            var qq = await _rawClient.DownloadHistory (symbols, interval, span, bounds).ConfigureAwait (false);

            List<History> histories = new List<History> ();
            foreach (var o in (JArray)qq) {
                History h = null;
                if (o != null && o.HasValues) {
                    h = new History (o);
                }
                histories.Add (h);
            }

            return histories;
        }
    }
}
