using Microsoft.AspNetCore.Mvc;

namespace Bank_app.Controller
{
    [Controller]
    public class HomeController : ControllerBase
    {
        [Route("/")]
        public IActionResult Home()
        {
            return Content("Welcome to the bank");
        }

        [Route("/account-details")]
        public IActionResult account()
        {
            var data = new { accountNumber = 4000, accountHolderName = "ahmed", currentBalanc = 5000 };
            return new JsonResult(data);
        }

        [Route("/account-statement")]

        public IActionResult user()
        {
            return File("/CSS.pdf", "application/pdf");
        }

        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult balance(int accountNumber )
        {
            var data = new { accountNumber = 4000, accountHolderName = "ahmed", currentBalanc = 5000 };
            string? accountNumberObj = Convert.ToString(Request.RouteValues["accountNumber"]);
            if (string.IsNullOrEmpty(accountNumberObj))
            {
                return NotFound("account number should be supplied");
            }
            else
            {
                int accountNO = Convert.ToInt16(accountNumberObj);
                if(accountNO!=data.accountNumber)
                {
                    return BadRequest($"account number should be {data.accountNumber}");
                }
                else
                    return Content($"{data.accountNumber}");
            }
        }


    }
}
