

// for Index.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public static string Username = "Admin";
        public string Password = "Admin123";



        public static string[] firstName = new string[99] ;
        public static string[] lastName = new string[99];
        public static string[] emailAddress = new string[99];
        public static string[] newUsername = new string[99];
        public static string[] newPassword = new string[99];
        public static string[] comPassword = new string[99];
        public static int ctrl = 0;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPostGetAjax(string User, string Pass)
        {
            Boolean verify = false;
            for (int x=0; x<=ctrl; x++)
            {
                if (User == newUsername[x] && Pass == newPassword[x]
             && User != "" && Pass != "")
                {
                    verify = true;
                    break;
                }
                else
                {
                    verify = false;
                }
            }
            return new JsonResult(verify);

        }


        public IActionResult OnPostCreateUser(string PfirstName, string PlastName, string PemailAddress,
            string PnewUsername, string PnewPassword, string PcomPassword)
        {
            Boolean verify;
            if (PfirstName != "" && PlastName != "" && PemailAddress != ""
                && PnewUsername != "" && PnewPassword != "" && PcomPassword != "")
            {
                firstName[ctrl] = PfirstName;
                lastName[ctrl] = PlastName;
                emailAddress[ctrl] = PemailAddress;
                newUsername[ctrl] = PnewUsername;
                newPassword[ctrl] = PnewPassword;
                comPassword[ctrl] = PcomPassword;
                ctrl++;
                verify = true;
                return new JsonResult(verify);
            }
            else
            {
                verify = false;
                return new JsonResult(verify);
            }
        }

    }
}