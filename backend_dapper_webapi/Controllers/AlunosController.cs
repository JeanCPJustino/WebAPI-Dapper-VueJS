using backend_dapper_webapi.Models;
using backend_dapper_webapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace backend_dapper_webapi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly AlunoRepository _AlunoRepository;

        public AlunosController(IConfiguration configuration)
        {
            _AlunoRepository = new AlunoRepository(configuration);
        }

        [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            return _AlunoRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Aluno Get(int id)
        {
            return _AlunoRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Aluno aluno)
        {
            if (ModelState.IsValid)
                _AlunoRepository.Add(aluno);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Aluno aluno)
        {
            aluno.id_aluno = id;

            if (ModelState.IsValid)
                _AlunoRepository.Update(aluno);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (ModelState.IsValid)
                _AlunoRepository.Delete(id);
        }


        [HttpGet("byprofessor/{professorid}")]
        public IEnumerable<Aluno> GetByProfessorId(int professorid)
        {
            return _AlunoRepository.GetByProfessorId(professorid);
        }

    }
}