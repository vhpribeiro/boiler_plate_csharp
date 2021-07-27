using Solucao_Base.Aplicacao.Dtos;
using Solucao_Base.Dominio.Usuarios;

namespace Solucao_Base.Aplicacao.Mapeadores
{
    public class MapeadorDeUsuario
    {
        public static Usuario MapearUsuarioDtoParaUsuario(UsuarioDto usuarioDto) 
            => new Usuario(usuarioDto.Nome, usuarioDto.Idade, usuarioDto.Email);
    }
}
