using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServiceCidades.Models;
using WebServiceCidades.Repositorio;

namespace WebServiceCidades.Controllers
{
    [Route("api/[controller]")]
    public class PrimeiraController:Controller
    {
        Cidade cidade=new Cidade();
        CidadeRepositorio cidadeRep=new CidadeRepositorio();
        [HttpGet]
        public IEnumerable<Cidade> Get(){
            return cidadeRep.ListarCidades();
        }
        [HttpGet("{id}")]
        public Cidade GetCidade(int Id){
            return cidadeRep.ListarCidades().Where(c=> c.Id==Id).FirstOrDefault();
        }

        [HttpPost]
        public bool Post([FromBody] Cidade cidade){
            return cidadeRep.Cadastrar(cidade);
        }

        [HttpDelete("{id}")]
        public bool Delete(int Id){
            return cidadeRep.Delete(Id);
        }

        [HttpPut("{id}")]
        public bool Put([FromBody] Cidade cidade, int id){
            cidade.Id=id;
            return cidadeRep.Alterar(cidade);
        }
    }
}