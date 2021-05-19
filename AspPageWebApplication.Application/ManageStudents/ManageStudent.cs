using AspPageWebApplication.Data;
using AspPageWebApplication.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspPageWebApplication.Application.ManageStudents
{
    public class ManageStudent : IManageStudent
    {
        private readonly UniversityDbContext context;

        public ManageStudent(UniversityDbContext context)
        {
            this.context = context;
        }

        public void AddStudent(Student student, int universityId)
        {
            context.Universities.Where(uni => uni.Id == universityId).FirstOrDefault().Students.Add(student);
            context.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            var stud = context.Students.Where(stud => stud.Id == studentId).FirstOrDefault();
            context.Remove(stud);
            context.SaveChanges();
        }

        public void EditStudent(Student student)
        {
            var stud = context.Students.Where(stud => stud.Id == student.Id).FirstOrDefault();
            stud.Name = student.Name;
            stud.Grade = student.Grade;
            stud.Age = student.Age;
            stud.Email = student.Email;
            context.SaveChanges();
        }

        public Student GetStudent(int studentId)
        {
            return context.Students.SingleOrDefault(stud => stud.Id == studentId);
        }

        public List<Student> GetStudentsByName(string searchName)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetUniversityStudents(int universityId)
        {
            
             var uni = context.Universities.Where(uni => uni.Id == universityId).Include(uni => uni.Students).FirstOrDefault();
             var studs = uni.Students.ToList();
            return (studs); 
        }

        
    }
}
