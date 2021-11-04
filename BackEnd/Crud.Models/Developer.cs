using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{
    public class Developer
    {
        public long Id { get; set; }
        
        [Required, MinLength(4), MaxLength(100)]
        public string Nome { get; set; }
        
        [Required]
        public char Sexo { get; set; }
        
        [Required]
        public int Idade { get; set; }

        [Required, MinLength(5), MaxLength(200)]
        public string Hobby { get; set; }
        
        [Required]
        public DateTime DataNascimento { get; set; }

        public Developer() { }

        public Developer(long id, string nome, char sexo, int idade, string hobby, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Sexo = sexo;
            Idade = idade;
            Hobby = hobby;
            DataNascimento = dataNascimento;
        }
    }
}
