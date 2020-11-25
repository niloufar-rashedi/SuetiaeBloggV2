using SuetiaeBlogg.Tests.Helper;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace SuetiaeBlogg.Tests.Service
{
    public class ControllerTestsBase : IClassFixture<WebApiTesterFactory>
    {
        protected readonly WebApiTesterFactory factory;
        protected HttpClient client;
        protected dynamic token;

        public ControllerTestsBase(WebApiTesterFactory factory)
        {
            this.factory = factory;
            client = factory.CreateClient();

            token = new ExpandoObject();
            token.sub = Guid.NewGuid();
            token.role = new[] { "sub_role", "admin" };
        }
    }
}
