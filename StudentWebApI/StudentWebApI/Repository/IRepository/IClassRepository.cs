using StudentWebApI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApI.Repository.IRepository
{
    public interface IClassRepository
    {
        ICollection<Class> GetClasses();
        Class GetClassesById(int classId);
        bool ClassExists(string name);
        bool CreateClass(Class classs);
        bool UpdateClass(Class classs);
        bool DeleteClass(Class classs);
        bool Save();

    }
}
