using System;

namespace Solucao_Base.Dominio.Excecoes
{
    public class RecursoNaoEncontradoException : Exception
    {
        public RecursoNaoEncontradoException(string message) : base(message) { }
    }
}
