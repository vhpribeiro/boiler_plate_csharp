using Solucao_Base.Aplicacao.Dtos;
using Solucao_Base.Aplicacao.Mapeadores;
using Solucao_Base.Dominio;
using Solucao_Base.Dominio.Excecoes;
using Solucao_Base.Dominio.Usuarios;
using System;
using System.Threading.Tasks;

namespace Solucao_Base.Aplicacao.Usuarios
{
    public class CriacaoDeUsuario : ICriacaoDeUsuario
    {
        private readonly IEntidadeBaseRepository<Usuario> _usuarioRepository;

        public CriacaoDeUsuario(IEntidadeBaseRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Guid> Criar(UsuarioDto usuarioDto)
        {
            var usuario = MapeadorDeUsuario.MapearUsuarioDtoParaUsuario(usuarioDto);

            if (usuario.EhValido is false)
                throw new DadosInvalidosException($"Não foi possível criar o usuários. Erros: {string.Join('|', usuario.Erros)}");

            await _usuarioRepository.InserirUma(usuario);

            return usuario.Id;
        }
    }
}
