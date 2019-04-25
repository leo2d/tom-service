using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using TOM.Core.Data.Config;
using TOM.Core.Data.Repositories;
using TOM.Core.DTOs;
using TOM.Core.Entities;

namespace TOM
{
    /// <summary>
    /// Summary description for VooWS
    /// </summary>
    [WebService(Namespace = "http://tom.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class VooWS : WebService
    {
        private readonly VooRepository _vooRepository = DBFactory.Instance.VooRepository;

        [WebMethod]
        public void Criar(Voo voo)
        {
            _vooRepository.SaveOrUpdate(voo);
        }

        [WebMethod]
        public void Editar(Voo voo)
        {
            _vooRepository.Update(voo);
        }

        [WebMethod]
        public void Apagar(int idVoo)
        {
            var voo = _vooRepository.FindFirstById(idVoo);
            _vooRepository.Delete(voo);
        }

        [WebMethod]
        public List<Voo> BuscarTodos()
        {
            var voos = _vooRepository.FindAll();
            return voos.ToList();
        }

        [WebMethod]
        public List<Voo> BuscarVoosPorFiltro(FiltroBuscaVooDTO filtro)
        {
            var voos = _vooRepository.FindAll();

            List<Voo> result = new List<Voo>();

            if (!string.IsNullOrEmpty(filtro.Origem))
                voos = voos.Where(x => x.Origem.Trim().ToLower().Equals(filtro.Origem.Trim().ToLower())).ToList();
            if(!string.IsNullOrEmpty(filtro.Destino))
                voos = voos.Where(x => x.Destino.Trim().ToLower().Equals(filtro.Destino.Trim().ToLower())).ToList();

            return voos.ToList();
        }

        [WebMethod]
        public Voo BuscarPorId(int idVoo)
        {
            var voo = _vooRepository.FindFirstById(idVoo);
            return voo;
        }

       

    }
}
