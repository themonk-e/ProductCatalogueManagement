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
            if (_logic.GetAllProducts().Count != 0)
            {
                return Ok(_logic.GetAllProducts());
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("add/new/product")]
        public IActionResult AddNewProduct([FromBody] Product_m product)
        {
            Product_m pr = _logic.AddProducts(product);
            if (pr!= null)
            {
                return Ok(pr);
            }
            else { return BadRequest(); }

        }

        [HttpPut("update/product")]
        public IActionResult UpdateAProduct([FromBody] Product_m product)
        {
            Product_m pr = _logic.UpdateProduct(product);
            if (pr != null)
            {
                return Ok(pr);
            }
            else { return BadRequest(); }

        }

        [HttpGet("get/product/{product_id}")]

        public IActionResult GetAProduct([FromRoute] string product_id)
        {
            Product_m pr=_logic.GetProduct(product_id);
            if (pr!=null)
            {
                return Ok(pr);
            }
            else return BadRequest();   
        }


        [HttpGet("get/byBrand/{brand}")]
        public IActionResult GetByBrand([FromRoute] string brand)
        {
            if(_logic.filterByBrand(brand).Count != 0) { 

                return Ok(_logic.filterByBrand(brand)); 
            }
            else return NotFound();
        }

        [HttpGet("get/byCategory/{category}")]
        public IActionResult GetByCategory([FromRoute] string category)
        {
            if (_logic.filterByCategory(category).Count != 0)
            {

                return Ok(_logic.filterByCategory(category));
            }
            else return NotFound();

        }

        [HttpDelete("Delete/product/{product_id}")]

        public IActionResult Delete([FromRoute] string product_id) {

            _logic.DeleteProduct(product_id);   
            return Ok();
        }

    }
}
