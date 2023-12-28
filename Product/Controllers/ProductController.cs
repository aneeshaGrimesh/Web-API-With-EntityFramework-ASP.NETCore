using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.DAL;
using Product.Models;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProducrDBContext _context;


        public ProductController(ProducrDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProductsList()
        {
            try
            {
                var product = _context.Products.ToList();
                if (product.Count == 0)
                {
                    return NotFound("Product not found.");
                }
                else
                {
                    return Ok(product);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
         public IActionResult GetProduct(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound($"Product not avilable with this ID{id}");
                }
                else
                {
                    return Ok(product);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult AddProducts(Products product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok("Product created");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct(Products product)
        {
            if(product ==  null || product.Id == 0)
            {
                if(product == null)
                {
                    return BadRequest("Product not valid");
                }
                else
                {
                    return BadRequest($"Product not avilable with the id{product.Id}");
                }
            }


            try
            {
                var productData = _context.Products.Find(product.Id);
                if (productData == null)
                {
                    return NotFound($"Product not avilable with the id{product.Id}");

                }
                else
                {
                    productData.ProductName = product.ProductName;
                    productData.Quantity = product.Quantity;
                    productData.Prize = product.Prize;
                    _context.SaveChanges();
                    return Ok("Product Details Updated");

                }
            }
            catch (Exception ex )
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound($"Product not found at the id {id}");
                }
                _context.Products.Remove(product);
                _context.SaveChanges();
                return Ok("Product Deleted.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
