using System;
using System.Collections.Generic;

namespace Solucao_Base.Dominio
{
    public abstract class Entidade
    {
        public Guid Id { get; set; }
        public List<string> Erros { get; protected set; }
        public bool EhValido => Erros.Count is 0;
    }
}
