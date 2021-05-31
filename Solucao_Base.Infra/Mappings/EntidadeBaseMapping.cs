using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucao_Base.Dominio;

namespace Solucao_Base.Infra.Mappings
{
    public abstract class EntidadeBaseMapping<T> where T : Entidade
    {
        protected readonly EntityTypeBuilder<T> Builder;

        protected EntidadeBaseMapping(EntityTypeBuilder<T> builder)
        {
            Builder = builder;
            Inicializar();
        }

        protected abstract string NomeDaTabela { get; }

        protected abstract void MapearPropriedades();
        protected abstract void MapearIndices();
        protected abstract void MapearChavesEstrangeiras();

        private void MapearBase()
        {
            Builder.ToTable(NomeDaTabela);

            Builder.Property(x => x.Id).HasColumnName("id").IsRequired();
        }

        private void MapearChavePrimaria()
        {
            Builder.HasKey(x => x.Id);
        }

        private void Inicializar()
        {
            MapearBase();
            MapearChavePrimaria();

            MapearPropriedades();
            MapearIndices();
            MapearChavesEstrangeiras();
        }
    }
}
