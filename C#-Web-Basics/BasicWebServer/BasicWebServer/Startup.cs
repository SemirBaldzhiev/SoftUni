using BasicWebServer.Server;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace BsicWebServer
{
    public class Startup
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
                Name: <input type='text' name='Name'/>
                Age: <input type='number' name ='Age'/>
                <input type='submit' value ='Save' />
                </form>";

        private const string DownloadForm = @"<form action='/Content' method='POST'>
                <input type='submit' value ='Download Sites Content' /> 
                </form>";

        private const string FileName = "content.txt";
        public static async Task Main()
        {
            await DownloadSitesAsTextFile(Startup.FileName, 
                new string[] { "https://judge.softuni.org/", "https://softuni.org/" });

            var server = new HttpServer(routes => routes
                .MapGet("/", new TextResponse("Hello from the server"))
                .MapGet("/HTML", new HtmlResponse("<h1>HTML response!<h1>"))
                .MapGet("/Redirect", new RedirectResponse("https://softuni.org/"))
                .MapPost("/HTML", new TextResponse(Startup.HtmlForm))
                .MapPost("/HTML", new TextResponse("", Startup.AddFormDataAction))
                .MapGet("/Content", new HtmlResponse(Startup.DownloadForm))
                .MapPost("/Content", new TextFileResponse(Startup.FileName))
                .MapGet("/Cookies", new HtmlResponse("", Startup.AddCookiesAction)));
            
            await server.Start();
        }

        private static void AddCookiesAction(Request request, Response response)
        {
            var requestHasCookie = request.Cookies.Any();
            var bodyText = "";

            if (requestHasCookie)
            {
                var cookieText = new StringBuilder();

                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText.Append("<table> border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }

                cookieText.Append("</table>");

                bodyText = cookieText.ToString();
            }
            else
            {
                bodyText = "<h1>Cookie set!</h1>";
            }

            if (!requestHasCookie)
            {
                response.Cookies.Add("My-Cookie", "My-Value");
                response.Cookies.Add("My-Second-Cookie", "My-Second-Value");

            }
        }

        private static void AddFormDataAction(Request request, Response response)
        {
            response.Body = "";

            foreach (var (key, value) in request.Form)
            {
                response.Body += $"{key} - {value}";
                response.Body += Environment.NewLine;
            }
        }

        private static async Task DownloadSitesAsTextFile(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var responses = await Task.WhenAll(downloads);

            var responsesString = string.Join(Environment.NewLine + new string('-', 100), responses);

            await File.WriteAllTextAsync(fileName, responsesString);
        }


        private static async Task<string> DownloadWebSiteContent(string url)
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var html = await response.Content.ReadAsStringAsync();

            return html.Substring(0, 2000);
        }
    }
}