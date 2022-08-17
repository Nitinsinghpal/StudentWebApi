using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebApI.Models;
using StudentWebApI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApI.Controllers
{
    [Route("api/class")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;
        public ClassController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        [HttpGet]
        public IActionResult GetClasses()
        {
            var classesInDb = _classRepository.GetClasses().ToList();
            return Ok(classesInDb);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetClassById(int id)
        {
            var classInDb = _classRepository.GetClassesById(id);
            return Ok(classInDb);
        }

        [HttpPost]
        public IActionResult CreateClass(Class classs)
        {
            if (classs == null)
                return BadRequest();
            var classExists = _classRepository.ClassExists(classs.ClassName);
            if(!classExists)
            {
                var classCreated = _classRepository.CreateClass(classs);
                if (!classCreated)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                return Ok("Created Successfully!!");
            }
            return BadRequest("Class Already Exists");
           
        }
        [HttpPut]
        public IActionResult UpdateClass(Class classs)
        {
            if (classs == null)
                return BadRequest();
            var updateClass = _classRepository.UpdateClass(classs);
            if(!updateClass)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteClass(int id)
        {
            var classInDb = _classRepository.GetClassesById(id);
            if (classInDb == null)
                return BadRequest();
            var classDelete = _classRepository.DeleteClass(classInDb);
            if(!classDelete)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }
    }
}
