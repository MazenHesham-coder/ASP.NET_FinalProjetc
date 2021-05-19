using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspPageWebApplication.Application.ManageUniversity;
using AspPageWebApplication.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspPageWebApplication.Pages.Universities
{
    public class DeleteModel : PageModel
    {
        private readonly IManageUniversity manageUniversity;
        public University University { get; set; }

        public DeleteModel(IManageUniversity manageUniversity)
        {
            this.manageUniversity = manageUniversity;
        }

        public IActionResult OnGet(int universityId)
        {
            University = manageUniversity.GetUniversity(universityId);
            if (University == null)
            {
                return RedirectToPage("NotFound");

            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(int universityId)
        {
            manageUniversity.DeleteUniversity(universityId);
            return RedirectToPage("./List");
        }
    }
}
