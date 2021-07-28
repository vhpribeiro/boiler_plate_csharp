using FluentAssertions;
using NSubstitute;
using Solucao_Base.Aplicacao.Dtos;
using Solucao_Base.Aplicacao.Usuarios;
using Solucao_Base.Dominio;
using Solucao_Base.Dominio.Excecoes;
using Solucao_Base.Dominio.Usuarios;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Solucao_Base.Aplicacao.Testes.Usuarios
{
    public class CriacaoDeUsuarioTeste
    {
        private readonly IEntidadeBaseRepository<Usuario> _usuarioRepository;
        private readonly CriacaoDeUsuario _criacaoDeUsuario;

        public CriacaoDeUsuarioTeste()
        {
            _usuarioRepository = Substitute.For<IEntidadeBaseRepository<Usuario>>();
            _criacaoDeUsuario = new CriacaoDeUsuario(_usuarioRepository);
        }

        [Fact]
        public void Deve_lancar_excecao_ao_criar_usuario_e_usuario_for_invalido()
        {
            const string mensagemDeErroEsperada = "Não foi possível criar o usuários. Erros: É necessário informar o nome do usuário!|Idade inválida! Idade deve estar entre 1 até 98 anos!";
            const string nomeInvalido = "";
            const string email = "maria.santos@gmail.com.br";
            const int idade = 0;
            var usuarioDto = new UsuarioDto
            {
                Nome = nomeInvalido,
                Email = email,
                Idade = idade
            };

            Func<Task> func = () => _criacaoDeUsuario.Criar(usuarioDto);

            func.Should().Throw<DadosInvalidosException>().WithMessage(mensagemDeErroEsperada);
            _usuarioRepository.DidNotReceive().InserirUma(Arg.Any<Usuario>());
        }

        [Fact]
        public async Task Deve_criar_um_usuario()
        {
            const string nome = "Maria dos Santos";
            const string email = "maria.santos@gmail.com.br";
            const int idade = 4;
            var usuarioDto = new UsuarioDto
            {
                Nome = nome,
                Email = email,
                Idade = idade
            };

            var idDoUsuario = await _criacaoDeUsuario.Criar(usuarioDto);

            idDoUsuario.Should().NotBe(Guid.Empty);
            await _usuarioRepository.Received().InserirUma(Arg.Is<Usuario>(u => u.Nome == nome && u.Email == email && u.Idade == idade && u.EhValido));
        }
    }
}
