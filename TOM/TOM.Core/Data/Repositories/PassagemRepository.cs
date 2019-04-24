using NHibernate;
using System.Collections.Generic;
using System.Linq;
using TOM.Core.Entities;

namespace TOM.Core.Data.Repositories
{
    public class PassagemRepository : RepositoryBase<Passagem>
    {
        public PassagemRepository(ISession session) : base(session)
        {
        }

        public IEnumerable<Passagem> BuscarPorVoo(int IdVoo)
        {
            var passagens = Session.Query<Passagem>()
                .Where(x => x.IdVoo == IdVoo);

            return passagens.ToList();
        }

    }
}
