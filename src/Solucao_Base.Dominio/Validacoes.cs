using System;
using System.Collections.Generic;

namespace Solucao_Base.Dominio
{
    public class Validacoes
    {
        private readonly List<string> Erros = new();

        public static Validacoes Novo()
        {
            return new Validacoes();
        }

        public Validacoes Quando(bool condicao, string mensagemDeErro)
        {
            if (condicao)
                Erros.Add(mensagemDeErro);

            return this;
        }

        public Validacoes Obrigando(string stringParaSerValidada, string mensagemDeErro)
        {
            if (string.IsNullOrWhiteSpace(stringParaSerValidada))
                Erros.Add(mensagemDeErro);

            return this;
        }

        public Validacoes Obrigando(int numeroQueDeveSerPositivo, string mensagemDeErro)
        {
            if (numeroQueDeveSerPositivo < 0)
                Erros.Add(mensagemDeErro);

            return this;
        }

        public Validacoes Obrigando(double numeroQueDeveSerPositivo, string mensagemDeErro)
        {
            if (numeroQueDeveSerPositivo < 0)
                Erros.Add(mensagemDeErro);

            return this;
        }

        public Validacoes Obrigando(Guid guidParaSerValidado, string mensagemDeErro)
        {
            if (Guid.Empty == guidParaSerValidado)
                Erros.Add(mensagemDeErro);

            return this;
        }

        public List<string> ObterErros() => Erros;
    }
}
