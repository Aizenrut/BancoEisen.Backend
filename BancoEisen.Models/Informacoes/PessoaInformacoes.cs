﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BancoEisen.Models.Informacoes
{
    public struct PessoaInformacoes
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Sobrenome { get; set; }

        [Required]
        [MinLength(11)]
        [MaxLength(11)]

        public string Cpf { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
