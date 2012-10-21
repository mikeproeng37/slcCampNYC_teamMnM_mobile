using HelloSLC.Global;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.Web;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloSLC
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        const string clientId = "kLFafZgwmJ";
        const string clientSecret = "UiyOPRbuuALUngj4T95OSIwfVePuqEFYhlcPq8zOx7Xm3Euc";

        string _slcAuthorizeUrl = "https://api.sandbox.slcedu.org/api/oauth/authorize";
        string _slcTokenUrl = "https://api.sandbox.slcedu.org/api/oauth/token";
        string _redirectUri = "http://localhost:49611/start.aspx";

        public MainPage()
        {
            this.InitializeComponent();

            // manually force the authentication on load
            Authenticate_Click(null, null);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async Task<string> SendData(String Url)
        {
            string response = null;
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Url);
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

        private async void Authenticate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string authorizeUrl = string.Format(_slcAuthorizeUrl + "?client_id={0}&client_secret{1}&redirect_uri={2}", clientId, clientSecret, _redirectUri);
                WebAuthenticationResult WebAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(
                                                       WebAuthenticationOptions.None,
                                                       new Uri(authorizeUrl),
                                                       new Uri(_redirectUri));
                var response = WebAuthenticationResult.ResponseData.ToString();
                var codeInd = response.IndexOf("code");
                var code = response.Substring(codeInd);
                string getTokenUrl = string.Format(_slcTokenUrl + "?client_id={0}&client_secret={1}&grant_type=authorization_code&redirect_uri={2}&{3}", clientId, clientSecret, _redirectUri, code);
                var result = await Utility.GetData(getTokenUrl, null);
                JsonObject token = JsonObject.Parse(result);
                string tokenString = token.GetNamedString("access_token");
                App.ACCESSTOKEN = tokenString;

                this.Frame.Navigate(typeof(HomePage));
                //var studentsResult = await Utility.GetData(Constants.API_URI + Constants.Student.STUDENTS, tokenString);
                //JsonArray studentsArray = JsonArray.Parse(studentsResult);
                /*HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.slc+json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, getTokenUrl);
                var response2 = await httpClient.GetAsync(getTokenUrl);*/
                

              
                
            }
            catch (Exception Err)
            {
                throw;
            }
        }
    }
}
