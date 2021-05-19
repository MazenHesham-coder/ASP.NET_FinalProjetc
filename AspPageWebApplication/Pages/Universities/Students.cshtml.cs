using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspPageWebApplication.Application.ManageStudents;
using AspPageWebApplication.Application.ManageUniversity;
using AspPageWebApplication.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspPageWebApplication.Pages.Universities
{
    public class StudentsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public List<Student>  Students { get; set; }
        public University University { get; set; }

        /*private readonly IManageUniversity manageUniversity;*/
        private readonly IManageStudent manageStudents;
        public StudentsModel(IManageStudent manageStudents)
        {
            this.manageStudents = manageStudents;
        }
        public IActionResult OnGet(int universityId)
        {
            /*University = manageUniversity.GetUniversity(universityId);*/

            Students = manageStudents.GetUniversityStudents(universityId);
            if (Students.Count() == 0)
            {
                return RedirectToPage("NoStudents");

            }
            else
            {
                return Page();
            }
        }
    }
}
