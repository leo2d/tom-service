using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using TOM.Core.Data.Config;
using TOM.Core.Data.Repositories;
using TOM.Core.Entities;

namespace TOM
{
    /// <summary>
    /// Summary description for PassagemWS
    /// </summary>
    [WebService(Namespace = "http://tom.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PassagemWS : WebService
    {
        private readonly PassagemRepository _passagemRepository;
        private readonly VooRepository _vooRepository;

        public PassagemWS()
        {
            _passagemRepository = DBFactory.Instance.PassagemRepository;
            _vooRepository = DBFactory.Instance.VooRepository;
        }

        [WebMethod]
        public bool ComprarBilhete(int idVoo)
        {
            var voo = _vooRepository.GetById(idVoo);

            if (null != voo)
                return EfeturarCompraBilhete(voo);

            return false;
        }

        [WebMethod]
        public bool ComprarBilhetes(int numeroVoo, int quantidade)
        {
            var voo = _vooRepository.BuscarPorNumeroVoo(numeroVoo);

            if (null != voo)
                return EfeturarCompraBilhete(voo, quantidade);

            return false;
        }

        private bool EfeturarCompraBilhete(Voo voo, int quantidade = 1)
        {
            if (voo.RetornarQuantidadeLugaresLivres() >= quantidade)
            {
                for (int i = 0; i < quantidade; i++)
                {
                    var passagem = new Passagem()
                    {
                        Id = 0,
                        IdVoo = voo.Id,
                        ValorPassagem = voo.ValorUnicoPassagem,
                        DataVoo = voo.DataVoo,
                    };

                    _passagemRepository.Save(passagem);
                }

                return true;
            }

            return false;
        }


        [WebMethod]
        public bool DevolverBilhete(int numeroVoo)
        {
            var voo = _vooRepository.BuscarPorNumeroVoo(numeroVoo);

            if (null == voo)
                return false;
            else
                voo.Passagens = _passagemRepository.BuscarPorVoo(voo.Id).ToList();

            var bilhete = voo.Passagens.FirstOrDefault();

            if (null != bilhete)
                _passagemRepository.Delete(bilhete);

            return true;

        }

        [WebMethod]
        public List<Passagem> BuscarTodas()
        {
            var passagens = _passagemRepository.FindAll().ToList();

            foreach (var passagem in passagens)
                passagem.Voo = _vooRepository.GetById(passagem.IdVoo);

            return passagens;
        }

        [WebMethod]
        public List<Passagem> BuscarPorVoo(int idVoo)
        {
            var passagens = _passagemRepository
                .BuscarPorVoo(idVoo)
                .ToList();

            return passagens;
        }
    }
}
