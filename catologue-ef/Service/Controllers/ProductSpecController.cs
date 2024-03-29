﻿using BusinessLogic;
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
            try
            {
                _logic.AddSpec(specList);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/speclist/{productId}")]
        public IActionResult GetSpecs([FromRoute] string productId)
        {
            try
            {
                if (_logic.GetSpecs(productId).Count != 0)
                {

                    return Ok(_logic.GetSpecs(productId));
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/specs")]
        public IActionResult UpdateSpecs([FromBody] List<ProductSpec_m> specList)
        {
            try
            {
                _logic.UpdateSpecs(specList);
                return Ok();
            }
            catch(Exception ex) {
             return BadRequest(ex.Message);
            }

        }

        [HttpDelete("delete/spec/{productId}")]
        public IActionResult DeleteSpecs([FromRoute] string productId)
        {
            try
            {
                _logic.RemoveSpec(productId);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
