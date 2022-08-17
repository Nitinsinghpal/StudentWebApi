using Microsoft.EntityFrameworkCore;
using StudentWebApI.Data;
using StudentWebApI.Models;
using StudentWebApI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;       
        }
        public bool CreateStudent(Student student)
        {
            _context.Students.Add(student);
            return Save();
        }

       

        public ICollection<Student> GetStudents()
        {
           return _context.Students.Include(s=>s.Classes).ToList();
           
        }

        public Student GetStudentById(int? studentId)
        {
           return _context.Students.Find(studentId);
        }

        public bool Save()
        {
           return _context.SaveChanges() == 1 ? true : false;
        }

        public bool UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            return Save();

        }

        public bool DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
            return Save();
        }

        public bool CheckAdhaarNo(int adhaarNo)
        {
            return _context.Students.Any(a => a.AdhaarNo == adhaarNo);
        }

       
    }
}
