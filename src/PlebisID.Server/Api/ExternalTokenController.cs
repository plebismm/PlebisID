using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PlebisID.Server.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalTokenController : ControllerBase
    {
        readonly UserManager<ClaimsPrincipal> userManager;
        public ExternalTokenController(UserManager<ClaimsPrincipal> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet, Route("{authenticationScheme}")]
        [Authorize]
        public async Task<IActionResult> GetExternalToken(string authenticationScheme)
        {
            var token = HttpContext.GetTokenAsync(authenticationScheme);

            return Ok(token);
        }
    }
}