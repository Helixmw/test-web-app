using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestWebAppLib;

namespace TestWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Class1 class1;

        public string Title { get; private set; } = "Welcome to the Home Page";

        public IndexModel(ILogger<IndexModel> logger, Class1 class1)
        {
            _logger = logger;
            this.class1 = class1;
        }

        public void OnGet()
        {
            Title = class1.Title;
            // You can set Title dynamically here if needed
        }
    }
}
