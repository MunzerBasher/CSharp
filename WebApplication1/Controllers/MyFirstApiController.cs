using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Controllers
{
    [Route("api/MyFirstApiApplication")]
    [ApiController]
    public class MyFirstApiController : ControllerBase
    {
        [HttpGet("Get_MyName", Name = "MyName")]
        public string GetMyName()
        {
            return "My Name is Munzer";
        }
        [HttpGet("Get_YourName", Name = "YourName")]
        public string GetYourName()
        {
            return "Your Name is Ahmed";
        }

        [HttpGet("Sum/{Number1}/{Number2}")]
        public int SumTwoNumber(int Number1, int Number2)
        {
            return (Number1 + Number2);
        }
        [HttpGet("Multi/{Number1}/{Number2}")]
        public int MultiTwoNumber(int Number1, int Number2)
        {
            return (Number1 * Number2);
        }

    }
}
