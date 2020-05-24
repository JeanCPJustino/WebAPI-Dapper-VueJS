using System.Collections.Generic;
using backend_dapper_webapi.Models;

namespace backend_dapper_webapi.Repository
{
    public interface IAlunoRepository
    {
        void Add(Aluno aluno);
        IEnumerable<Aluno> GetAll();
        Aluno GetById(int id);
        void Update(Aluno aluno);
        void Delete(int id);
        IEnumerable<Aluno> GetByProfessorId(int id);
    }
}