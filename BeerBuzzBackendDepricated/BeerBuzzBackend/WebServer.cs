using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeerBuzzBackend
{
    public class WebServer
    {
        HttpListener httpListener;

        public WebServer(int portNumber = 1234)
        {
            httpListener = new HttpListener();
            httpListener.Prefixes.Add(@"http://*:" + portNumber + @"/");
        }

        public async Task Listen(CancellationToken cancel)
        {
            httpListener.Start();

            // watch for cancellation
            while(!cancel.IsCancellationRequested)
            {
                var result = httpListener.BeginGetContext(callback =>
                {
                    var listener = (HttpListener)callback.AsyncState;
                    if(!listener.IsListening) return;

                    HttpListenerContext httpContext = listener.EndGetContext(callback);
                    // handle the request in httpContext, some requests can take some time to complete

                    var httpRequest = httpContext.Request;

                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];

                        var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);

                        postedFile.SaveAs(filePath);
                    }

                }, httpListener);

                while(result.IsCompleted == false)
                {
                    if(cancel.IsCancellationRequested) break;
                    await Task.Delay(100); // sleep and recheck
                }
            }
            httpListener.Stop();
        }
    }
}
