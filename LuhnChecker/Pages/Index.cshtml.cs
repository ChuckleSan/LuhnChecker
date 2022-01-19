using Microsoft.AspNetCore.Mvc.RazorPages;

using Services;

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

        public void OnGet()
        {

        }
    }
}