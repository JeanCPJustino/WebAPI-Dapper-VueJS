using System.Collections.Generic;
using backend_dapper_webapi.Models;

namespace backend_dapper_webapi.Repository
{
    public interface IProfessorRepository
    {
        void Add(Professor professor);
        IEnumerable<Professor> GetAll();
        Professor GetById(int id);
        void Update(Professor professor);
        void Delete(int id);
    }
}