using System.Collections.Generic;
using NUnit.Framework;
using RestSharp;
using ProductSearchTests.Models;
using RestSharp.Serialization.Json;

namespace ProductSearchTests
{
    [TestFixture]
    public class SearchTest
    {
        [Test]
        public void SearchForExistingProduct()
        {
            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("product/search/cm", Method.GET);

            var response = client.Execute(request);

            var productResponse =
                new JsonDeserializer().
                    Deserialize<List<ProductResponse>>(response);

            Assert.That(productResponse[0].Id, Is.EqualTo(1));
        }
        
        [Test]
        public void SearchForNonExistingProduct()
        {
            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("product/search/m4", Method.GET);

            var response = client.Execute(request);

            var productResponse =
                new JsonDeserializer().
                    Deserialize<List<ProductResponse>>(response);

            Assert.That(productResponse.Count, Is.EqualTo(0));
        }
    }
}