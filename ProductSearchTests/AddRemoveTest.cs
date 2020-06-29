using NUnit.Framework;
using RestSharp;
using System.Net;
using ProductSearchTests.Models;
using RestSharp.Serialization.Json;

namespace ProductSearchTests
{
    [TestFixture]
    public class AddRemoveTest
    {
        [Test]
        public void SearchForExistingProduct()
        {
            var client = new RestClient("http://localhost:5000");
            var request = new RestRequest("product", Method.POST);
            
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                products_name = "SA-E20 EDGE Carbine Replica - Black",
                producs_price = 949.00,
                products_description = "SA-E20 EDGE Carbine Replica\n\nEDGE is a line of replicas by Specna Arms that combines an array of solutions and technologies hard to find in other replicas on the market. It is a series that puts stress on very good craftsmanship of the exterior, solutions that improve upon the versatility of the replica, prolong its lifetime, simplify the diagnostics of a malfunction as well as facilitate the possibility of a power tuning. Straight out of the box you get a replica that does not require any modification, however, if needed - they will be extremely simple."
            });

            var response = client.Execute(request);

            var productResponse =
                new JsonDeserializer().
                    Deserialize<ProductResponse>(response);

            Assert.That(productResponse.ProductsName, Is.EqualTo("SA-E20 EDGE Carbine Replica - Black"));
            
            var request2 = new RestRequest("product/2", Method.DELETE);

            var response2 = client.Execute(request2);
            
            Assert.That(response2.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}