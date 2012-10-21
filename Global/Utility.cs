using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HelloSLC.Global
{
    class Utility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static async Task<string> GetData(string Url, string token)
        {
            string response = null;
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Url);
                if (token != null) {
                    Request.Headers[HttpRequestHeader.Authorization] = string.Format("bearer {0}", token);
                }
                Request.Accept = "application/vnd.slc+json";
                Request.ContentType = "application/vnd.slc+json";
                HttpWebResponse Response = (HttpWebResponse)await Request.GetResponseAsync();
                StreamReader ResponseDataStream = new StreamReader(Response.GetResponseStream());
                response = await ResponseDataStream.ReadToEndAsync();
            }
            catch (Exception Err)
            {

            }
            return response;
        }
    }
}
