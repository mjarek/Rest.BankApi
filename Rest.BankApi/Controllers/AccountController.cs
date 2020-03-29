using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest.BankApi.Responses;

namespace Rest.BankApi.Controllers
{
    [Route("api/Accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountDetailProvider _detailProvider;
        public AccountController()
        {
            _detailProvider = new AccountDetailProvider();
        }

        [HttpGet]
        [Route("{id}/Status")]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Result), (int)HttpStatusCode.NotFound)]
        public ObjectResult Status(Guid id)
        {
            var result =  _detailProvider.GetStatus(id);
            if (result == null || result.Success == false)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}