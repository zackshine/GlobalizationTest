using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorGlobal.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnGetSetCultureAsync(string culture)
        {
            HttpContext.Response.Cookies.Append("Culture", "c=" + culture + "|uic=" + culture);
            var returnUrl = Request.Headers["Referer"].ToString();
            if (returnUrl.Contains("?culture="))
            {
                var url = returnUrl.Substring(0, returnUrl.IndexOf("?culture="));
                return Redirect(url + "?culture=" + culture);
            }
            else
            {
                return Redirect(returnUrl + "?culture=" + culture);
            }
        }
    }
}
