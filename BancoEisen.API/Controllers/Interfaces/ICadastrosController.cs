﻿using BancoEisen.API.Models;
using BancoEisen.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BancoEisen.API.Controllers.Interfaces
{
    public interface ICadastrosController<TEntidade, TInformacoes, TFiltro>
    {
        IActionResult Todos(TFiltro filtro, Ordem ordem, Paginacao paginacao);
        IActionResult Consultar(int id);
        Task<IActionResult> Cadastrar(TInformacoes informacoes);
        Task<IActionResult> Alterar(TEntidade entidade);
        Task<IActionResult> Remover(int id);
    }
}
