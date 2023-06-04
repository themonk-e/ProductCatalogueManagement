using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using Models;
namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductLogic _logic=new ProductLogic();
        [HttpGet("get/all/Products")]
        public IActionResult GetAllProducts()
        {
            try
            {
                if (_logic.GetAllProducts().Count != 0)
                {
                    return Ok(_logic.GetAllProducts());
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpPost("add/new/product")]
        public IActionResult AddNewProduct([FromBody] Product_m product)
        {
            try
            {
                Product_m pr = _logic.AddProducts(product);
                if (pr != null)
                {
                    return Ok(pr);
                }
                else { return BadRequest(); }

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/product")]
        public IActionResult UpdateAProduct([FromBody] Product_m product)
        {
            try
            {

                Product_m pr = _logic.UpdateProduct(product);
                if (pr != null)
                {
                    return Ok(pr);
                }
                else { return BadRequest(); }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("get/product/{product_id}")]

        public IActionResult GetAProduct([FromRoute] string product_id)
        {
            try
            {
                Product_m pr = _logic.GetProduct(product_id);
                if (pr != null)
                {
                    return Ok(pr);
                }
                else return BadRequest();
            }
            catch(Exception ex) { 

                return BadRequest(ex.Message);
            }

        }


        [HttpGet("get/byBrand/{brand}")]
        public IActionResult GetByBrand([FromRoute] string brand)
        {
            try
            {
                return Ok(_logic.filterByBrand(brand));

            }
            catch(Exception ex) {
                return BadRequest();
            }
        }

        [HttpGet("get/byCategory/{category}")]
        public IActionResult GetByCategory([FromRoute] string category)
        {
            try
            {
                return Ok(_logic.filterByCategory(category));
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpDelete("Delete/product/{product_id}")]

        public IActionResult Delete([FromRoute] string product_id) {

            try
            {
                _logic.DeleteProduct(product_id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

        }

    }
}
