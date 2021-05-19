using AspPageWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspPageWebApplication.Application.ManageStudents
{
    public interface IManageStudent
    {
        List<Student> GetUniversityStudents(int universityId);
        List<Student> GetStudentsByName(string searchName);
        Student GetStudent(int studentId);

        void DeleteStudent(int studentId);
        void AddStudent(Student student, int universityId);
        void EditStudent(Student student);
    }
}
