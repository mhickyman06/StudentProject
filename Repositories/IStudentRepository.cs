using StudentProject.Models;
using StudentProject.ViewModels;
using System;
using System.Collections.Generic;

namespace StudentProject.Repositories
{
    public interface IStudentRepository
    {
        RegisterStudentModel RegisterNewStudent(RegisterStudentModel models);

        List<Student> GetAllStudents();
        bool GetStudentStatus(StudentStatusViewModel models);
    }
}