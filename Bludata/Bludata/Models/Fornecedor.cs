using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySqlASPNetMVC.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public int CD_EMPRESA { get; set; }
        public string NM_FORNECEDOR { get; set; }
        public DateTime DT_CADASTRO { get; set; }
        public string NR_CNPJ { get; set; }
        public string NOME_FANTASIA { get; internal set; }
    }
}