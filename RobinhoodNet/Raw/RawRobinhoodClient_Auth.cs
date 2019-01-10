using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BasicallyMe.RobinhoodNet.Raw
{
    public partial class RawRobinhoodClient
    {
        string _authToken;
        public string AuthToken
        {
            get { return _authToken; }
            private set
            {
                _authToken = value;
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Bearer",
                    _authToken);
            }
        }

        public string RefreshToken;

        public async Task<bool>
        Authenticate (string userName, string password)
        {
            try
            {
                var auth = await doPost(LOGIN_URL, new Dictionary<string, string>
                {
                    { "username", userName },
                    { "password", password },
                    { "grant_type", "password" },
                    { "client_id", "c82SH0WZOsabOXGP2sxqcj34FxkvfnWRZBKlBjFS" }
                }).ConfigureAwait (false);

                this.AuthToken = auth["access_token"].ToString();
                this.RefreshToken = auth["refresh_token"].ToString();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Authenticate (string token)
        {
            try
            {
                var auth = await doPost(LOGIN_URL, new Dictionary<string, string>
                {
                    { "refresh_token", token },
                    { "grant_type", "refresh_token" },
                    { "client_id", "c82SH0WZOsabOXGP2sxqcj34FxkvfnWRZBKlBjFS" }
                }).ConfigureAwait(false);

                this.AuthToken = auth["access_token"].ToString();
                this.RefreshToken = auth["refresh_token"].ToString();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
