using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using mck_prv_1_prod.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace mck_prv_1_prod.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {

        IWebHostEnvironment env;

        public ValuesController(IWebHostEnvironment _env)
        {
            env = _env;
        }

        [HttpGet]
        [Route("/catalog/products")]
        public virtual IActionResult GetAllProducts([FromQuery]int? id, [FromQuery]int? idIn, [FromQuery]int? idNotIn, [FromQuery]int? idMin, [FromQuery]int? idMax, [FromQuery]int? idGreater, [FromQuery]int? idLess, [FromQuery]string name, [FromQuery]string sku, [FromQuery]string upc, [FromQuery]int? price, [FromQuery]int? brandId, [FromQuery]int? isFreeShipping, [FromQuery]int? weight, [FromQuery]string condition, [FromQuery]int? limit, [FromQuery]string includeFields, [FromQuery]string excludeFields)
        {
            var path = Path.Combine(env.ContentRootPath, "App_Data/productos.json");
            StreamReader sr = new StreamReader(path);
            string exampleJson = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
            return Content( exampleJson , "application/json");
        }

        [HttpPost]
        [Route("/orders")]
        public virtual IActionResult UpdateOrder([FromHeader]int? xAuthToken, [FromBody] OrderFull body)
        {
            var path = Path.Combine(env.ContentRootPath, "App_Data/orden.json");
            StreamReader sr = new StreamReader(path);
            string exampleJson = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
            return Content(exampleJson, "application/json");
        }



    }
}
