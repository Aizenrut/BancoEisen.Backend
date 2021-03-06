﻿using BancoEisen.Models.Cadastros;
using System;

namespace BancoEisen.API.Models
{
    public struct PessoaResource
    {
        public int Id { get; }
        public string Nome { get;}
        public string Sobrenome { get; }
        public string Cpf { get; }
        public DateTime DataNascimento { get; }

        public PessoaResource(Pessoa pessoa)
        {
            Id = pessoa.Id;
            Nome = pessoa.Nome;
            Sobrenome = pessoa.Sobrenome;
            Cpf = pessoa.Cpf;
            DataNascimento = pessoa.DataNascimento;
        }
    }
}
