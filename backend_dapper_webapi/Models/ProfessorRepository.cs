using System.Collections.Generic;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Linq;
using backend_dapper_webapi.Repository;

namespace backend_dapper_webapi.Models
{
    public class ProfessorRepository : IProfessorRepository
    {
        IConfiguration _configuration;

        public ProfessorRepository(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").
                                GetSection("DefaultConnection").Value;
            return connection;
        }

        public IDbConnection Connection
        {
            get
            {                
                return new SqlConnection(this.GetConnection());
            }
        }        

        public void Add(Professor professor)
        {
            using (IDbConnection dbConnection = Connection)
            {                
                string sQuery = @"INSERT INTO Professores ( nome) 
                                                   VALUES (@nome)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, professor);
            }
        }

        public IEnumerable<Professor> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {     
                SqlMapper.ResetTypeHandlers();                                        

                string sQuery = @"SELECT * FROM Professores";
                dbConnection.Open();
                return dbConnection.Query<Professor>(sQuery);
            }
        }

        public Professor GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                SqlMapper.ResetTypeHandlers();
                
                string sQuery = @"SELECT * FROM Professores WHERE id_professor=@id";
                dbConnection.Open();
                return dbConnection.Query<Professor>(sQuery, new { id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                SqlMapper.ResetTypeHandlers();

                string sQuery = @"DELETE Professores WHERE id_professor=@id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { id = id });
            }
        }

        public void Update(Professor professor)
        {
            using (IDbConnection dbConnection = Connection)
            {
                SqlMapper.ResetTypeHandlers();

                string sQuery = @"UPDATE Professores 
                                     SET nome = @nome
                                   WHERE id_professor=@id_professor";
                dbConnection.Open();
                dbConnection.Query(sQuery, professor);
            }
        }
    }
}