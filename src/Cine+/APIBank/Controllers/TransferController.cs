using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APIBank.Models;

namespace APIBank.Controllers
{

    [ApiController]
    [Route("api/transfer_money")]
    public class TransferController : ControllerBase
    {
        private readonly ILogger<TransferController> _logger;

        public TransferController(ILogger<TransferController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{NOFrom}/{PIN}/{NOTo}/{amount}")]
        public IResponse Transfer(string no_from, string pin, string no_to, double amount, [FromServices] ILogger<TransferController> logger)
        {
            ICashier _cashier = new CashierPerson();
            IResponse _response = _cashier.Transfer(
                new Dictionary<string, object>(){
                    {"no_from", no_from},
                    {"pin", pin},
                    {"no_to", no_to},
                    {"amount", amount}
                }
            );
            return _response;
        }
    }
}