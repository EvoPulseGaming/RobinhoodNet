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
                    "Token",
                    _authToken);
            }
        }

        public async Task<bool>
        Authenticate (string userName, string password)
        {
            try
            {
                var auth = await doPost(LOGIN_URL, new Dictionary<string, string>
                {
                    { "username", userName },
                    { "password", password }
                });

                this.AuthToken = auth["token"].ToString();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Authenticate (string token)
        {
            this.AuthToken = token;

            // Test to see if the token is valid
            try
            {
                await doGet(API_URL);
            }
            catch
            {
                token = null;
                return false;
            }
            return true;
        }
    }
}
