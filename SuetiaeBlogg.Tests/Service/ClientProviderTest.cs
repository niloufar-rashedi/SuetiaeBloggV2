using System;
using System.Collections.Generic;
using System.Text;
using SuetiaeBlogg.Services;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;


namespace SuetiaeBlogg.Tests.Service
{
    public class ClientProviderTest
    {
        public HttpClient Client { get; set; }
        public ClientProviderTest()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();

        }

    }
}
