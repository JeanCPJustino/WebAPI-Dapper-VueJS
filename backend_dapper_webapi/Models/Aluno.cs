using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace backend_dapper_webapi.Models
{    
    public class Aluno
    {
        [Key]
        public int id_aluno { get; set; }    
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public DateTime dataNascimento { get; set; }
        public int id_professor { get; set; }        
        public Professor Professor { get; set; }        
    }
}