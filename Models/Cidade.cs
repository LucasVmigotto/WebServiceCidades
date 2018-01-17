using System.Collections.Generic;

namespace WebServiceCidades.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public int Habitantes { get; set; }

        public Cidade(int Id, string Nome, string Estado, int Habitantes)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Estado = Estado;
            this.Habitantes = Habitantes;
        }

        public Cidade(){}

    }
}