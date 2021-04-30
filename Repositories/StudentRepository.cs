//using System;
//using StudentProject.Models;
//using StudentProject.ViewModels;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using System.Collections;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;

//namespace StudentProject.Repositories
//{
//    public class StudentRepository : IStudentRepository
//    {
//        public ApplicationDbContext _context { get; }
//        public StudentRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }


//        public RegisterStudentModel RegisterNewStudent(RegisterStudentModel models)
//        {
//            Student std1 = new Student()
//            {
//                FirstName = models.FirstName,
//                LastName = models.LastName,
//                DateOfBirth = models.DateOfBirth,
//                Age = models.Age,
//                Class = models.Class,
//                Genders = models.Gender
//            };
//            _context.Students.Add(std1);
//            _context.SaveChanges();

//            Address address = new Address()
//            {
//                AddressLine1 = models.AddressLine1,
//                AddressLine2 = models.AddressLine2,
//                City = models.City,
//                State = models.State,
//                StudentId = std1.StudentId
//            };
//            _context.Addresses.Add(address);
//            _context.SaveChanges();

//            return models;
                  
//        }

//        List<Student> IStudentRepository.GetAllStudents()
//        {
//            List<Student> students = _context.Students.Include(e => e.Address).ToList();

//            return students;
//        }

//        public bool GetStudentStatus(StudentStatusViewModel models)
//        {
//            var student = _context.Students.FirstOrDefault(x => x.FirstName == models.FirstName && x.LastName == models.LastName);
//            if(student == null)
//            {
//                return false;
//            }
//            else
//            {
//                return true;

//            }
//        }
//    }
//}