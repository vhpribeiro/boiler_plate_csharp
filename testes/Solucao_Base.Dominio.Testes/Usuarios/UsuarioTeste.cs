using FluentAssertions;
using Solucao_Base.Dominio.Usuarios;
using System;
using System.Collections.Generic;
using Xunit;

namespace Solucao_Base.Dominio.Testes.Usuarios
{
    public class UsuarioTeste
    {
        private int _idadePadrao;
        private string _nomePadrao;
        private string _emailPadrao;

        public UsuarioTeste()
        {
            _idadePadrao = 98;
            _nomePadrao = "Vitor Hugo Pereira Ribeiro";
            _emailPadrao = "vitor.hp.ribeiro@gmail.com.br";
        }

        [Fact]
        public void Deve_criar_um_usuario_valido()
        {
            var usuario = new Usuario(_nomePadrao, _idadePadrao, _emailPadrao);

            usuario.Id.Should().NotBe(Guid.Empty);
            usuario.Nome.Should().Be(_nomePadrao);
            usuario.Idade.Should().Be(_idadePadrao);
            usuario.Email.Should().Be(_emailPadrao);
            usuario.EhValido.Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(99)]
        [InlineData(-50)]
        public void Deve_criar_um_usuario_invalido_quando_informar_idade_errada(int idadeInvalida)
        {
            const string mensagemDeErroDeIdadeInvalida = "Idade inválida! Idade deve estar entre 1 até 98 anos!";
            var errosEsperados = new List<string> { mensagemDeErroDeIdadeInvalida };

            var usuario = new Usuario(_nomePadrao, idadeInvalida, _emailPadrao);

            usuario.Erros.Should().BeEquivalentTo(errosEsperados);
            usuario.EhValido.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("     ")]
        public void Deve_criar_um_usuario_invalido_quando_informar_nome_errado(string nomeInvalido)
        {
            const string mensagemDeErroDeIdadeInvalida = "É necessário informar o nome do usuário!";
            var errosEsperados = new List<string> { mensagemDeErroDeIdadeInvalida };

            var usuario = new Usuario(nomeInvalido, _idadePadrao, _emailPadrao);

            usuario.Erros.Should().BeEquivalentTo(errosEsperados);
            usuario.EhValido.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("     ")]
        [InlineData("vitor.hp.ribeiro@hotmail.com")]
        [InlineData("vitor.hp.ribeiro!hotmail.com")]
        public void Deve_criar_um_usuario_invalido_quando_informar_email_errado(string emailInvalido)
        {
            const string mensagemDeErroDeIdadeInvalida = "É necessário informar um email do gmail válido!";
            var errosEsperados = new List<string> { mensagemDeErroDeIdadeInvalida };

            var usuario = new Usuario(_nomePadrao, _idadePadrao, emailInvalido);

            usuario.Erros.Should().BeEquivalentTo(errosEsperados);
            usuario.EhValido.Should().BeFalse();
        }
    }
}
