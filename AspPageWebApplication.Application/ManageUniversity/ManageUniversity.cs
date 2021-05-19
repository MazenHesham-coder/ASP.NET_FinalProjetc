using AspPageWebApplication.Data;
using AspPageWebApplication.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspPageWebApplication.Application.ManageUniversity
{
    public class ManageUniversity : IManageUniversity
    {
        // we will use variable context to access our data 
        private readonly UniversityDbContext context;

        // Dependency injection
        public ManageUniversity(UniversityDbContext context)
        {
            this.context = context;
        }

        public void AddUniversity(University university)
        {
            context.Universities.Add(university);
            context.SaveChanges();
        }
        public void DeleteUniversity(int universityId)
        {
            var uni = context.Universities.SingleOrDefault(uni => uni.Id == universityId);
            context.Remove(uni);
            context.SaveChanges();
        }

        public void EditUniversity(University university)
        {
            var uni = context.Universities.SingleOrDefault(uni => uni.Id == university.Id);
            if (university != null)
            {
                uni.Name = university.Name;
                uni.Address = university.Address;
                context.SaveChanges();
            }
        }

        public UniversityDTOList GetUniversities()
        {
            return new UniversityDTOList()
            {
                Universities = context.Universities.ToList().Select(c => new UniversityDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    StudentCount = context.Universities.Include(st => st.Students).Where(un => un.Id == c.Id).FirstOrDefault()
                    .Students
                    .Count
                }).ToList(),
                UniversitiesCount = context.Universities.ToList().Count

            };


        }

        public List<University> GetUniversitiesByName(string searchName)
        {
            return context.Universities.Where(uni => uni.Name.StartsWith(searchName)).ToList();
        }

        public University GetUniversity(int universityId)
        {
            return context.Universities.SingleOrDefault(uni => uni.Id == universityId);
        }

        void IManageUniversity.AddUniversity(University university)
        {
            context.Universities.Add(university);
            context.SaveChanges();
        }


    }
}
