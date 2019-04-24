using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using TOM.Core.Entities;

namespace TOM.Core.Data.Mapping
{
    public class PassagemMap : ClassMapping<Passagem>
    {
        public PassagemMap()
        {
            Id(x => x.Id, y => y.Generator(Generators.Identity));

            Property(x => x.ValorPassagem);
            Property(x => x.DataVoo);
            Property(x => x.IdVoo);

            ManyToOne(X=> X.Voo, Y=> { Y.Column("ID_VOO"); });
        }
    }
}
