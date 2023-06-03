using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSpecController : ControllerBase
    {   IProductSpecLogic _logic=new ProductSpecLogic();
        [HttpPost("add/specs")]
        public IActionResult AddSpecs([FromBody] List<ProductSpec_m> specList)
        {
            _logic.AddSpec(specList);
            return Ok();
        }

        [HttpGet("get/speclist/{productId}")]
        public IActionResult GetSpecs([FromRoute] string productId)
        {
            if(_logic.GetSpecs(productId).Count!=0) {
            
                return Ok(_logic.GetSpecs(productId));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("update/specs")]
        public IActionResult UpdateSpecs([FromBody] List<ProductSpec_m> specList)
        {
            _logic.UpdateSpecs(specList);
            return Ok();
        }

        [HttpDelete("delete/spec/{productId}")]
        public IActionResult DeleteSpecs([FromRoute] string productId)
        {
            _logic.RemoveSpec(productId);
            return Ok();
        }


    }
}
