using GuitarManager.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    public class AccountsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllAccounts([FromQuery] GetAccountsRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }
    }
}
