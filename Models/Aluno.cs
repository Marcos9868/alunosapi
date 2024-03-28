using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosApi.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [StringLength(130)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public int Idade { get; set; } = 0;

    }
}