using StudentWebApI.Data;
using StudentWebApI.Models;
using StudentWebApI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApI.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDbContext _context;
        public ClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool ClassExists(string name)
        {
            return _context.Classes.Any(p => p.ClassName == name);

        }

        public bool CreateClass(Class classs)
        {
            _context.Classes.Add(classs);
            return Save();
        }

        public bool DeleteClass(Class classs)
        {
            _context.Classes.Remove(classs);
            return Save();
        }

        public ICollection<Class> GetClasses()
        {
            return _context.Classes.ToList();
        }

        public Class GetClassesById(int classId)
        {
            return _context.Classes.Find(classId);

        }

        public bool Save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }

        public bool UpdateClass(Class classs)
        {
            _context.Classes.Update(classs);
            return Save();
        }
    }
}
