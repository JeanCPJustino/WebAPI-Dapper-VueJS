using Microsoft.EntityFrameworkCore;
using backend_dapper_webapi.Models;
using System.Collections.Generic;
using System;

namespace backend_dapper_webapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>().HasData(
                new List<Professor>(){
                    new Professor() {
                        id_professor = 1,
                        nome = "César"
                    },
                    new Professor() {
                        id_professor = 2,
                        nome = "Ademir"
                    },
                    new Professor() {
                        id_professor = 3,
                        nome = "Edmundo"
                    }
                }
            );

            builder.Entity<Aluno>().HasData(
                new List<Aluno>(){
                    new Aluno() {
                        id_aluno = 1,
                        nome = "Mazinho",
                        sobrenome = "Messi Black",
                        dataNascimento = DateTime.Parse("12/05/1987"),
                        id_professor = 1,
                    },
                    new Aluno() {
                        id_aluno = 2,
                        nome = "Patrick",
                        sobrenome = "Barriga de Cavalo",
                        dataNascimento = DateTime.Parse("01/01/1990"),
                        id_professor = 1                        
                    },
                    new Aluno() {
                        id_aluno = 3,
                        nome = "Deyverson",
                        sobrenome = "Cambalhota",
                        dataNascimento = DateTime.Parse("06/07/1993"),
                        id_professor = 2                        
                    },
                    new Aluno() {
                        id_aluno = 4,
                        nome = "Alceu",
                        sobrenome = "Voadora",
                        dataNascimento = DateTime.Parse("23/11/1992"),
                        id_professor = 2                        
                    },
                    new Aluno() {
                        id_aluno = 5,
                        nome = "Miguel",
                        sobrenome = "Borja",
                        dataNascimento = DateTime.Parse("12/05/1987"),
                        id_professor = 3                        
                    },                                        
                }
            );            
        }
    }
}