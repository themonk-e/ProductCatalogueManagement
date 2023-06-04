using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    { ICategoryLogic _logic=new CategoryLogic();

        [HttpPost("add/newCategory")]

        public IActionResult AddCategory([FromBody] Category_m category)
        {
            try
            {
                return Ok(_logic.AddCategory(category));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get/all/Categories")]

        public IActionResult GetAllCategories()
        {
            try
            {
                if (_logic.GetCategories() != null)
                {
                    return Ok(_logic.GetCategories());
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpPut("update/category")]
        public IActionResult GetAllCategories([FromBody]Category_m category)
        {
            try
            {
                return Ok(_logic.UpdateCategory(category));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("category/product/count/{categoryId}")]
        public IActionResult GetProductCout([FromRoute]string categoryId)
        {
            try
            {
                return Ok(_logic.GetPoductCount(categoryId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("category/update/product/count/{categoryId}")]
        public IActionResult IncrementProductCount([FromRoute]string categoryId)
        {
            try
            {
                _logic.UpdatePoductCount(categoryId);
                return Ok();
            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("category/delete/category/{categoryId}")]
        
        public IActionResult deleteProduct([FromRoute] string categoryId) {

            try
            {
                _logic.DeleteCategory(categoryId);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPut("category/decrement/product/count/{categoryId}")]
        public IActionResult DecrementProductCount([FromRoute] string categoryId)
        {
            try
            {
                _logic.DecrementProductCount(categoryId);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
