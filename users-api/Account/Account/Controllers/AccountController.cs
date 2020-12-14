
using Account.Models;
using Account.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController: ControllerBase
    {
        private IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [Authorize]
        [HttpGet("ValidateToken")]
        public IActionResult ValidateToken()
        {
            return Ok(true);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var outCome = await accountService.RegisterAsync(model);
                if (outCome.IsSuccess)
                {
                    return Ok(outCome);
                }
                return BadRequest(outCome);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var outCome = await accountService.LoginUserAsync(model);
                if (outCome.IsSuccess)
                {
                    return Ok(outCome);
                }
                return BadRequest(outCome);
            }
            return BadRequest("Some properties are not valid");
        }

    }
}
