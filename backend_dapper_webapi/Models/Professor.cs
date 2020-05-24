using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace backend_dapper_webapi.Models
{
    public class Professor  
    {
        [Key]
        public int id_professor { get; set; }    
        public string nome { get; set; }       
   
    }
}