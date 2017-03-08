using System;
using System.Net.Http;
using System.Threading;


//using Newtonsoft;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

namespace DP_dashboard
{
    public class LicenceSupport
    {

        private static string licenseServerUrl = Properties.Settings.Default.LicenseServerURL;
        private static bool ready = false;
        private static byte[] license = null;
        private static string licenseType = "";
        private static string dpMac = "";


        public LicenceSupport(string Url = "")
        {
            if(Url != "")
            licenseServerUrl = Url;
        }

        /// <summary>
        /// Return license as byte[] or null if timeout 
        /// </summary>
        /// <returns></returns>
        public byte [] GetKey(string licTypy, string mac)
        {
             if (licTypy != "")
            {
                licenseType = licTypy;
                dpMac = mac;

                int i = 0;
                new Thread(Generate).Start();
                while (!ready)
                {
                    Thread.Sleep(10);
                    i += 10;
                    if (i > 3000)
                        break;
                }
            }           
            return license;
        }

        private static async void Generate()
        {           
            ready = false;
           
            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(licenseServerUrl + dpMac + "&capabilities=" + licenseType))
            using (HttpContent content = response.Content)
            {
                try
                {
                    string result = await content.ReadAsStringAsync();
                    key k = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<key>(result);

                    if (k.Validation)
                    {
                        license = StringToByteArray(k.Key);
                    }
                    else
                    {
                        license = null;
                    }
                }
                catch
                {
                    license = null;
                }
                ready = true;
            }
        }

        public class key
        {
            public string Key { get; set; }
            public bool Validation
            {
                get { return Key != null; }
                set { }
            }


        }
        public static byte[] StringToByteArray(string hex)
        {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        public static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            //return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }
    }
}
