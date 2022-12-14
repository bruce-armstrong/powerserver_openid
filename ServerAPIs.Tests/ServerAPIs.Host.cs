using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace ServerAPIs.Tests
{
    [CollectionDefinition(TestHost.CollectionName)]
    public class TestHost : ICollectionFixture<TestHost>, IDisposable
    {
        public const string CollectionName = "ServerAPI";

        public TestServer Server { get; }

        // Start server
        public TestHost()
        {
            var host = Program
                .CreateHostBuilder(Array.Empty<string>())
                .ConfigureWebHost(builder => builder.UseTestServer())
                .Build();

            host.Start();

            this.Server = host.GetTestServer();
        }

        public void Dispose()
        {
            this.Server.Dispose();
        }
    }
}
