using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using TOM.Core.Entities;

namespace TOM.Core.Data.Mapping
{
    public class VooMap : ClassMapping<Voo>
    {
        public VooMap()
        {
            Id(x => x.Id, y => y.Generator(Generators.Identity));

            Property(x => x.Origem);
            Property(x => x.Destino);
            Property(x => x.Aeronave);
            Property(x => x.NumeroVoo);
            Property(x => x.QuantidadeAssentos);
            Property(x => x.DataVoo);
            Property(x => x.ValorUnicoPassagem);

            Bag<Passagem>(x => x.Passagens, y =>
            {
                y.Cascade(Cascade.All);
                y.Key(k => k.Column("ID_VOO"));
                y.Inverse(true);
                y.Lazy(CollectionLazy.Lazy);
            }, z => z.OneToMany());
        }
    }
}
