using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspPageWebApplication.Application.ManageStudents;
using AspPageWebApplication.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspPageWebApplication.Pages.Universities
{
    public class EditStudentModel : PageModel
    {
        private readonly IManageStudent manageStudent;

        public EditStudentModel(IManageStudent manageStudent)
        {
            this.manageStudent = manageStudent;
        }
        [BindProperty] // To Bind the University to use it in Post
        public Student Student { get; set; }
        public IActionResult OnGet(int studentId)
        {
            Student = manageStudent.GetStudent(studentId);
            if (Student == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost()
        {
            manageStudent.EditStudent(this.Student);
            return RedirectToPage("./List");

        }
        
    }
}
