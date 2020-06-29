using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductSearch.Models;
using ProductSearch.Repositories;

namespace ProductSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return _productRepository.GetSingle(id);
        }

        [HttpGet("search/{query}")]
        public IEnumerable<Product> GetSearch(string query)
        {
            return _productRepository.GetBySearchDesc(query);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Product product)
        {
            try
            {
                if (product == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _productRepository.Add(product);

                var save = _productRepository.Save();

                if (save > 0)
                {
                    return Ok(product);
                }

                return BadRequest();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var product = _productRepository.GetSingle(id);

                if (product == null) return BadRequest();

                _productRepository.Delete(product);

                var save = _productRepository.Save();

                if (save > 0) return Ok();

                return BadRequest(); 
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}