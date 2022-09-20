using Arolla.WebApis.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Arolla.WebApis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimpleDataController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<SimpleData> Get()
        {
            return new[]
            {
                new SimpleData() { Id =  1, VeryImportantData = "Hello this is important 01"},
                new SimpleData() { Id =  2, VeryImportantData = "Hello this is important 02"},
                new SimpleData() { Id =  3, VeryImportantData = "Hello this is important 03"},
                new SimpleData() { Id =  4, VeryImportantData = "Hello this is important 04"},
            };
        }

        [HttpPost]
        public void Post(SimpleData data)
        {
            WriteMessage("Post request received");
            WriteMessage($"- {data.Id} - {data.VeryImportantData}");
        }

        [HttpPut]
        public void Put(SimpleData data)
        {
            WriteMessage("Put request received");
            WriteMessage($"- {data.Id} - {data.VeryImportantData}");
        }

        [HttpDelete]
        public void Delete(int id)
        {
            WriteMessage("Delete request received");
            WriteMessage($"- {id}");
        }

        private static void WriteMessage(string message)
        {
            Console.WriteLine(message);
            Trace.WriteLine(message);
        }
    }
}
