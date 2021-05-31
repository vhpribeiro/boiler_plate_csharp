using System;

namespace Solucao_Base.Dominio.Excecoes
{
    public class DadosInvalidosException : Exception
    {
        public DadosInvalidosException(string message) : base(message) { }
    }
}
