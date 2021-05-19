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
    public class DeleteStudentModel : PageModel
    {
        private readonly IManageStudent manageStudent;
        public Student Student { get; set; }

        public DeleteStudentModel(IManageStudent manageStudent)
        {
            this.manageStudent = manageStudent;
        }

        public IActionResult OnGet(int studentId)
        {
            Student = manageStudent.GetStudent(studentId);
            if (Student == null)
            {
                return RedirectToPage("NoStudents");

            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(int studentId)
        {
            manageStudent.DeleteStudent(studentId);
            return RedirectToPage("./List");
        }
        
    }
}
