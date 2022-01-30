﻿using BasicWebServer.Server;
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

        private const string LoginForm = @"<form action='/Login' method='POST'>
               Username: <input type='text' name='Username'/>
               Password: <input type='text' name='Password'/>
               <input type='submit' value ='Log In' /> 
            </form>";

        private const string Username = "user";
        private const string Password = "user123";


        public static async Task Main()
        {
            await DownloadSitesAsTextFile(Startup.FileName, 
                new string[] { "https://judge.softuni.org/", "https://softuni.org/" });

            var server = new HttpServer(routes => routes
                .MapGet("/", new TextResponse("Hello from the server"))
                .MapGet("/Redirect", new RedirectResponse("https://softuni.org/"))
                .MapGet("/HTML", new HtmlResponse(Startup.HtmlForm))
                .MapPost("/HTML", new TextResponse("", Startup.AddFormDataAction))
                .MapGet("/Content", new HtmlResponse(Startup.DownloadForm))
                .MapPost("/Content", new TextFileResponse(Startup.FileName))
                .MapGet("/Cookies", new HtmlResponse("", Startup.AddCookiesAction))
                .MapGet("/Session", new TextResponse("", Startup.DisplaySessionInfoAction))
                .MapGet("/Login", new HtmlResponse(Startup.LoginForm))
                .MapPost("/Login", new HtmlResponse("", Startup.LoginAction))
                .MapGet("/Logout", new HtmlResponse("", Startup.LogoutAction))
                .MapGet("/UserProfile", new HtmlResponse("", Startup.GetUserDataAction)));
            
            await server.Start();
        }

        private static void GetUserDataAction(Request request, Response response)
        {
            if (true)
            {
                response.Body = "";
                response.Body += $"<h3>Currently logged-in user " + $"is with username '{Username}'</h3>";
            }
            else
            {
                response.Body = "";
                response.Body += "<h3>You should first log in " + "- <a href='/Login'>Login</a></h3>";
            }
        }

        private static void LogoutAction(Request request, Response response)
        {
            request.Session.Clear();

            response.Body = "";
            response.Body += "<h3>Logged out successfully!</h3>";
        }
        private static void LoginAction(Request request, Response response)
        {
            request.Session.Clear();

            var bodyText = "";

            var usernameMatches = request.Form["Username"] == Startup.Username;
            var passwordMatches = request.Form["Password"] == Startup.Username;

            if (usernameMatches && passwordMatches)
            {
                request.Session[Session.SessionUserKey] = "MyUserId";

                response.Cookies.Add(Session.SessionCookieName, request.Session.Id);

                bodyText = "<h3>Logges successfully!</h3>";
            }
            else
            {
                bodyText = Startup.LoginForm;
            }
            response.Body = "";
            response.Body += bodyText;

        }

        private static void DisplaySessionInfoAction(Request request, Response response)
        {
            var sessionExist = request.Session.Contains(Session.SessionCurrentDateKey);

            var bodyText = "";

            if (sessionExist)
            {
                var currentDate = request.Session[Session.SessionCurrentDateKey];
                bodyText = $"Stored date: {currentDate}"!;
            }
            else
            {
                bodyText = "Current date stored!";
            }
            response.Body = "";
            response.Body += bodyText;
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