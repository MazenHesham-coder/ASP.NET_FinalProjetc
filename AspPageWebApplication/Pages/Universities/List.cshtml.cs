using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspPageWebApplication.Application.ManageUniversity;
using AspPageWebApplication.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AspPageWebApplication.Pages.Univercities
{
    public class ListModel : PageModel
    {

        private readonly IConfiguration config;
        private readonly IManageUniversity manageUniversity;


        public List<University> Universities;
        public UniversityDTOList UniversityDTOList { get; set; }
        public string Message { get; set; }
        public int test { get; set; }

        [BindProperty(SupportsGet = true)] //To support Get request
                                           // عشان نجيب القيمة اللي اتكتب في فرونت نجيبها للباكاند نستخدمها
        public string searchName { get; set; }

        public ListModel(IConfiguration configuration, IManageUniversity manageUniversity)
        {
            this.manageUniversity = manageUniversity;
            config = configuration;
        }
        public void OnGet()
        {
            /*Message = config["Message"];*/
            if (this.searchName == null)
            {
                UniversityDTOList = manageUniversity.GetUniversities(); // incase no search
            }
            else
            {
                Universities = manageUniversity.GetUniversitiesByName(this.searchName);
            }
        }
    }
}
