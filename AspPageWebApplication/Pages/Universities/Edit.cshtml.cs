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
    public class EditModel : PageModel
    {
        
        private readonly IManageUniversity manageUniversity;

        public EditModel(IManageUniversity manageUniversity)
        {
            this.manageUniversity = manageUniversity;
        }
        [BindProperty] // To Bind the University to use it in Post
        public University University { get; set; } 
        public void OnGet(int? universityId)// ? >> nullable
        {
            
            if (!universityId.HasValue) // لو مافهاش قيمة >> null
            {
                University = new University();
            }
            else
            {
                University = manageUniversity.GetUniversity(universityId.Value); // value >> القيمة اللي فيها
            }
        }
        public IActionResult OnPost()
        {
            if (this.University.Id > 0)
            {
                manageUniversity.EditUniversity(this.University);
                
            }
            else
            {
                manageUniversity.AddUniversity(this.University);
                
            }
            return RedirectToPage("./List");

        }
    }
}
