using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace TOM.Core.Entities
{
    public class Voo : BaseEntity<Voo>
    {
        public Voo()
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
        [XmlIgnore()]
        public virtual IList<Passagem> Passagens { get; set; }

        [NotMapped]
        public virtual int? QuantidadeAssentosLivres { get; set; }

        public virtual int RetornarQuantidadeLugaresLivres()
        {
            return QuantidadeAssentos - Passagens.Count;
        }
    }
}
