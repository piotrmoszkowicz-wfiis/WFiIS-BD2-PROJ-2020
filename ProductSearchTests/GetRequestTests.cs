using NUnit.Framework;
using RestSharp;
using System.Net;

namespace ProductSearchTests
{
    [TestFixture]
    public class GetRequestTests
    {
        [Test]
        public void StatusCodeTest()
        {
            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("product", Method.GET);
            var request2 = new RestRequest("product/1", Method.GET);
                
            var response = client.Execute(request);
            var response2 = client.Execute(request2);
                
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response2.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ContentTypeTest()
        {
            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("product", Method.GET);
            var request2 = new RestRequest("product/1", Method.GET);
                
            var response = client.Execute(request);
            var response2 = client.Execute(request2);
                
            Assert.That(response.ContentType, Is.EqualTo("application/json; charset=utf-8"));
            Assert.That(response2.ContentType, Is.EqualTo("application/json; charset=utf-8"));

        }
    }
}