using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FunctionEventPoC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            Console.WriteLine($"endpoint curr id: {Task.CurrentId}");
            Console.WriteLine($"endpoint thread id {Thread.CurrentThread.ManagedThreadId}");
            Run();
            return await Task.FromResult<string[]>(new string[] { "value1", "value2" });
        }

        private static async Task Run()
        {
            while (true)
            {
                Console.WriteLine(DateTime.Now);
                await Task.Delay(1000);
                Console.WriteLine($"curr id: {Task.CurrentId}");
                Console.WriteLine($"thread id {Thread.CurrentThread.ManagedThreadId}");
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
