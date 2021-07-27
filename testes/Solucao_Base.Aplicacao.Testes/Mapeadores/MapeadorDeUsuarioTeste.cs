using FluentAssertions;
using Solucao_Base.Aplicacao.Dtos;
using Solucao_Base.Aplicacao.Mapeadores;
using System;
using Xunit;

namespace Solucao_Base.Aplicacao.Testes.Mapeadores
{
    public class MapeadorDeUsuarioTeste
    {
        [Fact]
        public void Deve_mapear_usuario_dto_para_usuario()
        {
            const int idade = 20;
            const string email = "john.cena@gmail.com.br";
            const string nome = "John Cena";
            var usuarioDto = new UsuarioDto
            {
                Nome = nome,
                Email = email,
                Idade = idade
            };

            var usuario = MapeadorDeUsuario.MapearUsuarioDtoParaUsuario(usuarioDto);

            usuario.Id.Should().NotBe(Guid.Empty);
            usuario.Nome.Should().Be(nome);
            usuario.Idade.Should().Be(idade);
            usuario.Email.Should().Be(email);
            usuario.EhValido.Should().BeTrue();
        }
    }
}
