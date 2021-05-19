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
    public class DetailsModel : PageModel
    {
       

        public University University { get; set; }
        /*[BindProperty(SupportsGet = true)]*/
        /*public List<Student> Students { get; set; }*/

        private readonly IManageUniversity manageUniversity;

        public DetailsModel(IManageUniversity manageUniversity)
        {
            this.manageUniversity = manageUniversity;
        }


        public IActionResult OnGet(int universityId)
        {
            University = manageUniversity.GetUniversity(universityId);
            /*Students = manageUniversity.GetUniversityStudents(universityId);*/
            if (University == null)
            {
                return RedirectToPage("NotFound");

            }
            /*if (Students == null)
            {
                
            }*/
            else
            {
                return Page();
            }

            
        }

       
    }
}
