﻿using BancoEisen.Data.Models.Filtros;
using BancoEisen.Models.Cadastros;
using BancoEisen.Models.Informacoes;

namespace BancoEisen.Controllers.Interfaces
{
    public interface IContaController : ICadastroController<Conta, ContaInformacoes, ContaFiltro>
    {
    }
}
