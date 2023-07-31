using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homework5.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public long Number1 { get; set; }

        [BindProperty]
        public long Number2 { get; set; }

        [BindProperty]
        public string Operation { get; set; }

        [BindProperty]
        public string Result { get; private set; }


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }

        public void OnPost()
        {

            switch (Operation)
            {
                case "sum":
                    Result = (Number1 + Number2).ToString();
                    break;
                case "subtraction":
                    Result = (Number1 - Number2).ToString();
                    break;
                case "multiplication":
                    Result = (Number1 * Number2).ToString();
                    break;
                case "division":
                    Result = (Number1 / Number2).ToString();
                    break;
            }
        }
    }
}