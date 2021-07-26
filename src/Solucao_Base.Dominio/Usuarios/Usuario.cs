using System;

namespace Solucao_Base.Dominio.Usuarios
{
    public class Usuario : Entidade
    {
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public string Email { get; private set; }

        public Usuario(string nome, int idade, string email)
        {
            ValidarInformacoes(nome, idade, email);

            Id = Guid.NewGuid();
            Nome = nome;
            Idade = idade;
            Email = email;
        }

        private void ValidarInformacoes(string nome, int idade, string email)
        {
            Erros = Validacoes.Novo()
                .Obrigando(nome, "É necessário informar o nome do usuário!")
                .Quando(string.IsNullOrWhiteSpace(email) || !email.Contains("@gmail.com.br"), "É necessário informar um email do gmail válido!")
                .Quando(idade <= 0 || idade > 98, "Idade inválida! Idade deve estar entre 1 até 98 anos!")
                .ObterErros();
        }
    }
}
