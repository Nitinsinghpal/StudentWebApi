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
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var studentsInDb = _studentRepository.GetStudents();
            return Ok(studentsInDb);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudentById(int id)
        {
            var studentInDb = _studentRepository.GetStudentById(id);
            return Ok(studentInDb); 
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (student == null)
                return BadRequest();
            var checkAdhaar = _studentRepository.CheckAdhaarNo(student.AdhaarNo);
            if(!checkAdhaar)
            {
                var createStudent = _studentRepository.CreateStudent(student);
                if (!createStudent)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                return Ok();
            }
            return BadRequest("Adhaar no already registered");
            
        }


        [HttpPut]
        public IActionResult UpdateStudent( Student student)
        {
            if (student == null)
                return NotFound();
            if (!_studentRepository.UpdateStudent(student))
            {
                ModelState.AddModelError("", $"Something went wrong while update trail");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return Ok();

        }

        [HttpDelete]
        public IActionResult DeleteStudent(int? stId)
        {
            
            var student = _studentRepository.GetStudentById(stId);
            if (student == null) return BadRequest();
            if (!_studentRepository.DeleteStudent(student))
            {
                ModelState.AddModelError("", $"Something went wrong while delete trail{student.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return Ok();
        }

        

        
    }
}
