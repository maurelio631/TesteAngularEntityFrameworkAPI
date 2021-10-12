using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreAngularAPI.Models
{
    public class UsuarioDetail
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName="nvarchar(100)")]
        public string Nome { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Sobrenome { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Datanascimento { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Escolaridade { get; set; }
    }
}
