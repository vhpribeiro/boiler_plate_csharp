using System;
using System.Collections.Generic;

namespace Solucao_Base.Dominio
{
    public class Validacoes<T> where T : class
    {
        private readonly List<string> Erros = new();

        public static Validacoes<T> Novo()
        {
            return new Validacoes<T>();
        }

        public Validacoes<T> Quando(bool condicao, string mensagemDeErro)
        {
            if (condicao)
                Erros.Add(mensagemDeErro);

            return this;
        }

        public Validacoes<T> Obrigando(string stringParaSerValidada, string mensagemDeErro)
        {
            if (string.IsNullOrWhiteSpace(stringParaSerValidada))
                Erros.Add(mensagemDeErro);

            return this;
        }

        public Validacoes<T> Obrigando(int numeroQueDeveSerPositivo, string mensagemDeErro)
        {
            if (numeroQueDeveSerPositivo < 0)
                Erros.Add(mensagemDeErro);

            return this;
        }

        public Validacoes<T> Obrigando(double numeroQueDeveSerPositivo, string mensagemDeErro)
        {
            if (numeroQueDeveSerPositivo < 0)
                Erros.Add(mensagemDeErro);

            return this;
        }

        public Validacoes<T> Obrigando(Guid guidParaSerValidado, string mensagemDeErro)
        {
            if (Guid.Empty == guidParaSerValidado)
                Erros.Add(mensagemDeErro);

            return this;
        }

        public List<string> ObterErros() => Erros;
    }
}
