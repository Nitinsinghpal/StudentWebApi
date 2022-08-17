using StudentWebApI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApI.Repository.IRepository
{
    public interface IStudentRepository
    {
        ICollection<Student> GetStudents();
        Student GetStudentById(int? studentId);
        bool CreateStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(Student student);
        bool CheckAdhaarNo(int adhaarNo);
        bool Save();
    }
}
