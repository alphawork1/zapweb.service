using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zapweb.Models
{
    public class Condominio
    {
        public int Id { get; set; }
        public string Nome { get; set; }        
        public string Colaborador { get; set; }
        public string Cadastrador { get; set; }
        public int QuantidadeAndaresBloco { get; set; }
        public int QuantidadeApto{ get; set; }
        public int QuantidadeBlocos { get; set; }
        public string Observacao { get; set; }
        public DateTime DataUltimaCampanha { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Rank { get; set; }

        public int AdministradoraId { get; set; }
        public int UnidadeId { get; set; }
        public int SindicoId { get; set; }
        public int ZeladorId { get; set; }
        public int EnderecoId { get; set; }

        [PetaPoco.Ignore] public Endereco Endereco { get; set; }
        [PetaPoco.Ignore] public Administradora Administradora { get; set; }
        [PetaPoco.Ignore] public Contato Sindico { get; set; }
        [PetaPoco.Ignore] public Contato Zelador { get; set; }
        [PetaPoco.Ignore] public Unidade Unidade { get; set; }
    }
}