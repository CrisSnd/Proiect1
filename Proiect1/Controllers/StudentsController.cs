using Data;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect1.Dtos;
using Proiect1.Utils;

namespace Proiect1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDataAccesLayerService dal;

        public StudentsController(IDataAccesLayerService dal)
        {
            this.dal = dal; 
        }

        /// <summary>
        /// Initializeaza DB-ul
        /// </summary>

        [HttpPost("seed")]
        public void Seed()=> dal.Seed();


        /// <summary>
        /// Returneaza toti studentii in baza de date
        /// </summary>
        [HttpGet]
        public IEnumerable<StudentToGetDto> GetAllStudents()
        {

            var allStudents=dal.GetAllStudents();
            return allStudents.Select(s=>StudentUtils.ToDto(s)).ToList();

        }

        /// <summary>
        /// Gets a students by id
        /// </summary>
        /// <param name="id">id of the student</param>
        /// <returns>student data </returns>

        [HttpGet("/id/{id}")]
        public StudentToGetDto GetStudentById(int id)
        {
            var student = dal.GetStudentById(id);
            return StudentUtils.ToDto(student); 
        }


        /// <summary>
        /// Creates a students
        /// </summary>
        /// <param name="studentToCreate">student to create data</param>
        /// <returns>created student data</returns>
        [HttpPost]
        public StudentToGetDto CreateStudent([FromBody] StudentToCreateDto studentToCreate)=>
        
            dal.CreateStudent(studentToCreate.ToEntity()).ToDto();



        /// <summary>
        /// Updates a students
        /// </summary>
        /// <param name="studentToUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        public StudentToGetDto UpdateStudent([FromBody] StudentToUpdateDto studentToUpdate) =>
           dal.UpdateStudent(studentToUpdate.ToEntity()).ToDto();




        /// <summary>
        /// Updates a address
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adressToUpdate"></param>
        [HttpPut("{id}")]

        public void UpdateStudentAdress([FromRoute] int id, [FromBody] AdressToUpdateDto adressToUpdate)=>
       dal.UpdateOrCreateStudentAddress(id,adressToUpdate.ToEntity());


        [HttpDelete("{id}")]

        public IActionResult DeleteStudent (int id)
        {
            if(id == 0)
            {
                return BadRequest(("id cannot be 0"));
            }
            try
            {
                dal.DeleteStudent(id);
            }
            catch(InvalidCastException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }
    }
}
