using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zapweb.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int CidadeId { get; set; }

        [PetaPoco.Ignore] public Cidade Cidade { get; set; }
    }
}