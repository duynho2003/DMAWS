using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Lab08AzureFunctionApp.Service;

namespace Lab08AzureFunctionApp
{
    public class Function1
    {
        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            ProductService productService = new ProductService();
            var model =  productService.GetProducts();
            return new OkObjectResult(await model);
        }
    }
}
