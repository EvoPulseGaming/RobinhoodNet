using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using BasicallyMe.RobinhoodNet.DataTypes;
using Newtonsoft.Json;

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

        public async Task<(bool, ChallengeInfo)>
        Authenticate(string userName, string password, string deviceToken, string challengeID)
        {

            //First login attempt, either we are already F2A or we need to generate a response(SMS)
            try
            {
                System.Net.Http.HttpResponseMessage message;
                if (challengeID == "") //Normal login
                {
                    message = await doPost_NativeResponse(LOGIN_URL, new Dictionary<string, string>
                    {
                    { "grant_type", "password" },
                    {"scope", "internal" },
                    { "client_id", "c82SH0WZOsabOXGP2sxqcj34FxkvfnWRZBKlBjFS" },
                    {"expires_in", "86400" },
                    {"device_token", deviceToken },
                    { "username", userName },
                    { "password", password }
                    }).ConfigureAwait(false);
                }
                else// Challenge based login
                {
                    _httpClient.DefaultRequestHeaders.Add("X-ROBINHOOD-CHALLENGE-RESPONSE-ID", challengeID);
                    message = await doPost_NativeResponse(LOGIN_URL, new Dictionary<string, string>
                    {
                    { "grant_type", "password" },
                    {"scope", "internal" },
                    { "client_id", "c82SH0WZOsabOXGP2sxqcj34FxkvfnWRZBKlBjFS" },
                    {"expires_in", "86400" },
                    {"device_token", deviceToken },
                    { "challenge_type", "sms" },
                    { "username", userName },
                    { "password", password }
                    }).ConfigureAwait(false);
                }

                string content = await message.Content.ReadAsStringAsync().ConfigureAwait(false);

                JObject result = JObject.Parse(content);

                if (message.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    //New device, must SMS challenge
                    if (result["detail"].ToString().Contains("challenge type required"))
                    {
                        try
                        {
                            var message_challenge = await doPost_NativeResponse(LOGIN_URL, new Dictionary<string, string>
                                {
                                { "grant_type", "password" },
                                {"scope", "internal" },
                                { "client_id", "c82SH0WZOsabOXGP2sxqcj34FxkvfnWRZBKlBjFS" },
                                {"expires_in", "86400" },
                                {"device_token", deviceToken },
                                { "username", userName },
                                { "password", password },
                                { "challenge_type", "sms" }
                                }).ConfigureAwait(false);

                            if (message_challenge.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                string content_challenge = await message_challenge.Content.ReadAsStringAsync().ConfigureAwait(false);

                                var challenge = JsonConvert.DeserializeObject<ChallengeInfo>(content_challenge);

                                //Challenge was issued, we can now SMS verify,
                                //return false+challege so SMS verify GUI and pop up
                                if (challenge.challenge.status == "issued")
                                {
                                    if (!string.IsNullOrEmpty(challengeID))
                                    {
                                        
                                    }
                                    return (false, challenge);
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    else//bad login
                    {
                        return (false, null);
                    }


                }
                else//We already have F2A from prior login. Normal login.
                {
                    this.AuthToken = result["access_token"].ToString();
                    this.RefreshToken = result["refresh_token"].ToString();
                    _httpClient.DefaultRequestHeaders.Remove("X-ROBINHOOD-CHALLENGE-RESPONSE-ID");
                    return (true, null);
                }
            }
            catch
            {
                return (false, null);
            }        
            return (false, null);
        
    }

public async Task<bool> Authenticate(string token)
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

        //public async Task<bool> SignIn_SMS_Verify(string userName, string password, string challenge_token)
        //{
        //    try
        //    {
        //        var auth = await doPost(LOGIN_URL, new Dictionary<string, string>
        //        {
        //            { "grant_type", "password" },
        //            {"scope", "internal" },
        //            { "client_id", "c82SH0WZOsabOXGP2sxqcj34FxkvfnWRZBKlBjFS" },
        //            {"expires_in", "86400" },
        //            //{"device_token", deviceToken },
        //            { "username", userName },
        //            { "password", password },
        //            { "X-ROBINHOOD-CHALLENGE-RESPONSE-ID", challenge_token },
        //        }).ConfigureAwait(false);

        //        this.AuthToken = auth["access_token"].ToString();
        //        this.RefreshToken = auth["refresh_token"].ToString();
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    return true;



        //}

        public async Task<(bool, ChallengeInfo)>
        ChallengeResponse(string id, string code)
        {
            try
            {
                var message = await doPost_NativeResponse(CHALLENGE_URL + id + "/respond/", new Dictionary<string, string>
                {
                    { "response", code },
                }).ConfigureAwait(false);

                string content = await message.Content.ReadAsStringAsync().ConfigureAwait(false);



                if (message.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var challenge = JsonConvert.DeserializeObject<ChallengeDetails>(content);
                    if (challenge.status == "validated")
                    {
                        var newChallenge = new ChallengeInfo();
                        newChallenge.challenge = challenge;
                        return (true, newChallenge);
                    }
                }
                else
                {
                    var challenge = JsonConvert.DeserializeObject<ChallengeInfo>(content);
                    return (false, challenge);
                }
            }
            catch
            {
                return (false, null);
            }
            return (false, null);
        }

        public string GenerateDeviceToken()
        {
            List<int> rands = new List<int>();
            var rng = new Random();
            for (int i = 0; i < 16; i++)
            {
                var r = rng.NextDouble();
                double rand = 4294967296.0 * r;
                rands.Add(((int)((uint)rand >> ((3 & i) << 3))) & 255);
            }

            List<string> hex = new List<string>();
            for (int i = 0; i < 256; ++i)
            {
                hex.Add(Convert.ToString(i + 256, 16).Substring(1));
            }

            string id = "";
            for (int i = 0; i < 16; i++)
            {
                id += hex[rands[i]];

                if (i == 3 || i == 5 || i == 7 || i == 9)
                {
                    id += "-";
                }
            }

            return id;
        }
    }
}
