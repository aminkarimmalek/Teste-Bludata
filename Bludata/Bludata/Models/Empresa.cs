using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MySqlASPNetMVC.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string NOME_FANTASIA { get; set; }
        public string DS_SIGLA { get; set; }
        public string CNPJ { get; set; }
        public int CD_ESTADO { get; set; }
    }
}