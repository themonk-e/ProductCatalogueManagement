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
            return Ok(_logic.AddCategory(category));
        }


        [HttpGet("get/all/Categories")]

        public IActionResult GetAllCategories()
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

        [HttpPut("update/category")]
        public IActionResult GetAllCategories([FromBody]Category_m category)
        {
            return Ok(_logic.UpdateCategory(category));
        }

        [HttpGet("category/product/count/{categoryId}")]
        public IActionResult GetProductCout([FromRoute]string categoryId)
        {
            return Ok(_logic.GetPoductCount(categoryId));
        }


        [HttpPut("category/update/product/count/{categoryId}")]
        public IActionResult IncrementProductCount([FromRoute]string categoryId)
        {
            _logic.UpdatePoductCount(categoryId);
            return Ok();
        }
    }
}
