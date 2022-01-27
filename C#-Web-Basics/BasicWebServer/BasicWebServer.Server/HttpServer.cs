using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        public HttpServer(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            serverListener = new TcpListener(this.ipAddress, port);
        }

        public void Start()
        {
            serverListener.Start();

            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine("Listening fro request...");

            while (true)
            {
                var connection = serverListener.AcceptTcpClient();

                var networkStream = connection.GetStream();

                var requestText = ReadRequest(networkStream);

                string content = "Hello from the server!";

                Console.WriteLine(requestText);

                WriteResponse(networkStream, content);

                connection.Close();

            }
        }

        private void WriteResponse(NetworkStream networkStream, string content)
        {
            int contentLength = Encoding.UTF8.GetByteCount(content);

            string response = $@"HTTP/1.1 200 OK
                     Content-Type: text/plain; charset=UTF-8
                     Content-Length: {contentLength}

                     {content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);

            networkStream.Write(responseBytes);
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var requestBuilder = new StringBuilder();
            var totalBytes = 0;

            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLength);

                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large.");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead)); ;

            } while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }

    }
}
