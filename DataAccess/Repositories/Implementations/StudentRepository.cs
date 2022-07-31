using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using DataAccess.Repositories.Base;

namespace DataAccess.Repositories.Implementations
{
    public class StudentRepository:IRepository<Student>
    {

        public Student Create(Student entity)
        {
            try
            {
             DbContext.Students.Add(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
            return entity;
        }

        public void Delete(Student entity)
        {
            try
            {
             DbContext.Students.Remove(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
            
        }


        public void Update(Student entity)
        {
            try
            {
             var student = DbContext.Groups.Find(g => g.Id == entity.Id);
            if (student != null)
            {
                student.Name = entity.Name;
                student.Surname = entity.Surname;
            }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
            
        }

        public Student Get(Predicate<Student> filter = null)
        {
            try
            {
            if (filter == null)
            {
                return DbContext.Students[0];
            }
            else
            {
                return DbContext.Students.Find(filter);
            }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
            return null;
            
        }

        public List<Student> GetAll(Predicate<Student> filter = null)
        {
            try
            {
            if (filter == null)
            {
                return DbContext.Students;

            }
            else
            {
                return DbContext.Students.FindAll(filter);
            }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
            return null;
        }
    }
 }
