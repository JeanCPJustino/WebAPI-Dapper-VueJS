using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Linq;
using backend_dapper_webapi.Models;
using Newtonsoft.Json;

namespace backend_dapper_webapi.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        IConfiguration _configuration;

        public AlunoRepository(IConfiguration Configuration)
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

        public void Add(Aluno aluno)
        {
            using (IDbConnection dbConnection = Connection)
            {
                SqlMapper.AddTypeHandler(new JsonObjectTypeHandler<Professor>());

                string sQuery = @"INSERT INTO Alunos ( nome,  sobrenome,  dataNascimento,  id_professor) 
                                              VALUES (@nome, @sobrenome, @dataNascimento, @id_professor)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, aluno);
            }
        }

        public IEnumerable<Aluno> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                SqlMapper.AddTypeHandler(new JsonObjectTypeHandler<Professor>());

                string sQuery = @"SELECT al.id_aluno, al.nome, al.sobrenome, al.dataNascimento,
	                                     (SELECT pr.id_professor, pr.nome FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) Professor 
                                    FROM Alunos al WITH (NOLOCK)
                                    LEFT JOIN Professores pr WITH (NOLOCK)
                                      ON pr.id_professor = al.id_professor";
                dbConnection.Open();
                return dbConnection.Query<Aluno>(sQuery);
            }
        }

        public Aluno GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                SqlMapper.AddTypeHandler(new JsonObjectTypeHandler<Professor>());

                string sQuery = @"SELECT al.id_aluno, al.nome, al.sobrenome, al.dataNascimento,
	                                     (SELECT pr.id_professor, pr.nome FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) Professor
                                    FROM Alunos al WITH (NOLOCK)
                                    LEFT JOIN Professores pr WITH (NOLOCK)
                                      ON pr.id_professor = al.id_professor
                                   WHERE al.id_aluno=@id";
                dbConnection.Open();
                return dbConnection.Query<Aluno>(sQuery, new { id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                SqlMapper.ResetTypeHandlers();

                string sQuery = @"DELETE Alunos WHERE id_aluno=@id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { id = id });
            }
        }

        public void Update(Aluno aluno)
        {
            using (IDbConnection dbConnection = Connection)
            {   
                SqlMapper.ResetTypeHandlers();
                
                string sQuery = @"UPDATE Alunos 
                                     SET nome = @nome, 
                                         sobrenome = @sobrenome, 
                                         dataNascimento = @dataNascimento,
                                         id_professor = @id_professor
                                   WHERE id_aluno=@id_aluno";
                dbConnection.Open();
                dbConnection.Query(sQuery, aluno);
            }
        }

        public IEnumerable<Aluno> GetByProfessorId(int id_professor)
        {
            using (IDbConnection dbConnection = Connection)
            {
                SqlMapper.AddTypeHandler(new JsonObjectTypeHandler<Professor>());

                string sQuery = @"SELECT al.id_aluno, al.nome, al.sobrenome, al.dataNascimento,
                                         (SELECT pr.id_professor, pr.nome FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) Professor
                                    FROM Alunos al WITH (NOLOCK)
                                   INNER JOIN Professores pr WITH (NOLOCK)
                                      ON pr.id_professor = al.id_professor
                                   WHERE al.id_professor=@id_professor";
                dbConnection.Open();

                return dbConnection.Query<Aluno>(sQuery, new { id_professor = id_professor });
            }
        }
    }
}