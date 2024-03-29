﻿
using Prosoft.devRegister.Business.Model;
using System.Collections.Generic;

namespace Prosoft.devRegister.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity 
    {
        Task<List<TEntity>> ObterTodos();
        Task<TEntity> ObterUsuarioPorIdRepository(string usuarioId);
        Task<TEntity> AtualizarUsuarioPorIdRepository(Usuario usuario);
        Task<TEntity> InserirUsuarioRepository(Usuario usuario);
    }
}
