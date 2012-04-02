using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SO_Dailymotion_Upload
{
    public class OAuthResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
    }
}
