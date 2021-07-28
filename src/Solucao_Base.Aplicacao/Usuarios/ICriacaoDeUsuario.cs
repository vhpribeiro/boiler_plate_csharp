using Solucao_Base.Aplicacao.Dtos;
using System;
using System.Threading.Tasks;

namespace Solucao_Base.Aplicacao.Usuarios
{
    public interface ICriacaoDeUsuario
    {
        Task<Guid> Criar(UsuarioDto usuarioDto);
    }
}