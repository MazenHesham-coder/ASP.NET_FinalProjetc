using System;
using System.Collections.Generic;
using System.Text;

namespace AspPageWebApplication.Application.ManageUniversity
{
    public class UniversityDTO // مش حنضيفه في ال داتابيز وبنحدد فيه عايزين نرجع ايه
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int StudentCount { get; set; }


    }
    // حنعمل جواه كلاس جديد
    public class UniversityDTOList
    {
        public List<UniversityDTO> Universities { get; set; }
        public int UniversitiesCount { get; set; }


    }
}
