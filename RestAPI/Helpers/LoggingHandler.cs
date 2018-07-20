using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace RestAPI.Helpers
{

    public class LoggingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string path = HostingEnvironment.MapPath(@"~/App_Data/Log.txt");
            
            //Log request
            string requestBody = await request.Content.ReadAsStringAsync();
            File.AppendAllText(path, request.ToString()+"\n\n");
            
            //Send request for further processing
            var result = await base.SendAsync(request, cancellationToken);

            if (result != null)
            {
                //Log response
                File.AppendAllText(path, result.ToString() + "\n\n");
            }

            return result;
        }
    }
}