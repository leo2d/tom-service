using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOM.Core.Entities;

namespace TOM.Core.DTOs
{
    public class VooDTO
    {
        public VooDTO()
        {
            Passagens = new List<Passagem>();
        }

        public virtual DateTime DataVoo { get; set; }
        public virtual string Origem { get; set; }
        public virtual string Destino { get; set; }
        public virtual string Aeronave { get; set; }
        public virtual int NumeroVoo { get; set; }
        public virtual int QuantidadeAssentos { get; set; }
        public virtual decimal ValorUnicoPassagem { get; set; }

        public int QuantidadeLugaresLivres { get; private set; }



        public virtual List<Passagem> Passagens { get; set; }
    }
}
