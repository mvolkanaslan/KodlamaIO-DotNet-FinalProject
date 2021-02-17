using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    //BU isteği yaparken kullanıcının nasıl ulaşacağı
    [Route("api/[controller]")]
    [ApiController]// c# da  Attributes - java da annotation
    public class ProductsController : ControllerBase
    {
        //Loosely Couple
        //IoC Container - Inversion of Control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Dependecy chain

            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);//200
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int v)
        {
            var result = _productService.GetById(v);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
