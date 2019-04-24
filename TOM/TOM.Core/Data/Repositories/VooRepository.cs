using NHibernate;
using System.Collections.Generic;
using System.Linq;
using TOM.Core.Entities;

namespace TOM.Core.Data.Repositories
{
    public class VooRepository : RepositoryBase<Voo>
    {
        public VooRepository(ISession session) : base(session)
        {
        }

        public Voo BuscarPorNumeroVoo(int numeroVoo)
        {
            return Session.Query<Voo>()
                .FirstOrDefault(x => x.NumeroVoo == numeroVoo);
        }

        public IEnumerable<Passagem> BuscarPassagensPorIdVoo(int IdVoo)
        {
            var voo = Session.Query<Voo>()
                .FirstOrDefault(x => x.Id == IdVoo);
            var passagens = voo.Passagens;

            return passagens.ToList();
        }
    }
}
