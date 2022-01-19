using System.Text;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Services;

#nullable disable

namespace LuhnChecker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILuhnCheckService _luhnCheck;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(
            ILuhnCheckService luhnCheck,
            ILogger<IndexModel> logger)
        {
            _luhnCheck = luhnCheck;
            _logger = logger;
        }

        [BindProperty]
        public string CardNums { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPostCheckLuhn()
        {
            if (CardNums == null)
            {
                ModelState.AddModelError(string.Empty, "You need to enter at least one card number");
                return Page();
            }
            else
            {
                string[] cards = CardNums.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                StringBuilder rsp = new StringBuilder();

                foreach (string card in cards)
                {
                    if (card != null) rsp.AppendLine($"{card} is {(_luhnCheck.Check(card) ? "valid" : "invalid")}");
                }
                return Content(rsp.ToString());
            }

            //49927398716       valid
            //49927398717       not valid
            //1234567812345678  not valid
            //1234567812345670  valid

        }
    }
}