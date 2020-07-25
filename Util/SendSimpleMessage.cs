using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportService.Util
{
    public class SendSimpleMessage
    {
        public static IRestResponse SendComplexMessage()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                                            "1cf884147e120dc923df90a3c535755c-9dda225e-6d5c3937");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "YOUR_DOMAIN_NAME", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "TH SUPPORT <mailgun@YOUR_DOMAIN_NAME>");
            request.AddParameter("to", "bar@example.com");
            request.AddParameter("to", "YOU@YOUR_DOMAIN_NAME");
            request.AddParameter("subject", "Hello");
            request.AddParameter("text", "Testing some Mailgun awesomness!");
            request.Method = Method.POST;
            return client.Execute(request);
        }

    }

}

