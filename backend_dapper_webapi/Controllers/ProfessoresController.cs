using backend_dapper_webapi.Models;
using backend_dapper_webapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace backend_dapper_webapi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProfessoresController: ControllerBase
    {
        private readonly ProfessorRepository _ProfessorRepository;

        public ProfessoresController(IConfiguration configuration)
        {
            _ProfessorRepository = new ProfessorRepository(configuration);
        }

        [HttpGet]
        public IEnumerable<Professor> Get()
        {
            return _ProfessorRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Professor Get(int id)
        {
            return _ProfessorRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Professor professor)
        {
            if (ModelState.IsValid)
                _ProfessorRepository.Add(professor);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Professor professor)
        {
            professor.id_professor = id;

            if (ModelState.IsValid)
                _ProfessorRepository.Update(professor);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            if (ModelState.IsValid)
                _ProfessorRepository.Delete(id);
        }     
    }
}