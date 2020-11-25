using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.API;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using SuetiaeBlogg.Tests.Service;
using SuetiaeBlogg.Tests.Helper;
using SuetiaeBlogg.Core.Models.Glossary;

namespace SuetiaeBlogg.Tests
{
    public class GlossaryControllerTests : ControllerTestsBase
    {
        public GlossaryControllerTests(WebApiTesterFactory factory) : base(factory) { }

        [Fact]
        public async Task should_return_list_of_glossary_items_without_need_for_token()
        {
            var response = await client.GetAsync("/api/glossary");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<GlossaryItem>>(json);
            data.Count().Should().BeGreaterThan(0);
            data.First().Term.Should().Be("AccessToken");
        }

        [Fact]
        public async Task should_return_glossary_item_without_need_for_token()
        {
            var response = await client.GetAsync("/api/glossary/accesstoken");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<GlossaryItem>(json);
            data.Should().NotBeNull();
            data.Term.Should().Be("AccessToken");
        }
        [Fact]
        public async Task should_throw_unauthorized_if_token_is_not_provided_upon_delete()
        {
            var response = await client.DeleteAsync("/api/glossary/jwt");

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        [Fact]
        public async Task should_create_glossary_item()
        {
            client.SetFakeBearerToken((object)token);
            var item = new GlossaryItem
            {
                Term = "Suetiae",
                Definition = "A multi-cultural blog"
            };
            string json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/glossary", content);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
