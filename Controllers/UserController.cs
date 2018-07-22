using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace myApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public LoginResult Post([FromBody]UserCreds creds)
        {
            LoginResult result = new LoginResult();
            result.ok = false;
            result.message = "Login failed";

            if (creds.username == "admin" && creds.password == "abc")
            {
                result.ok = true;
                result.message = "Login Başarılı";
            }
            return result;
        }
    }
}
