using AspPageWebApplication.Domain;
using System.Collections.Generic;

namespace AspPageWebApplication.Application.ManageUniversity
{
    public interface IManageUniversity
    {
        UniversityDTOList GetUniversities();
        University GetUniversity(int universityId);
        List<University> GetUniversitiesByName(string searchName);
       

        void DeleteUniversity(int universityId);
        void AddUniversity(University university);
        void EditUniversity(University university);
    }
}
