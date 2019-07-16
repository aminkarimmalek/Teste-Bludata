using MySqlASPNetMVC.Models;
using MySqlASPNetMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySqlASPNetMVC.Aplicacao
{
    public class FornecedorAplicacao
    {

        private readonly Contexto contexto;

        public FornecedorAplicacao()
        {
            contexto = new Contexto();
        }

        public List<Fornecedor> ListarTodos()
        {
            var Fornecedor = new List<Fornecedor>();
            const string strQuery = "SELECT empresa.NOME_FANTASIA, CD_FORNECEDOR, NM_FORNECEDOR,DT_CADASTRO,NR_CNPJ FROM fornecedor INNER JOIN empresa ON fornecedor.CD_EMPRESA = empresa.CD_EMPRESA";
            var rows = contexto.ExecutaComandoComRetorno(strQuery, null);
            foreach (var row in rows)
            {
                var tempFornecedor = new Fornecedor
                {
                    Id = int.Parse(!string.IsNullOrEmpty(row["CD_FORNECEDOR"]) ? row["CD_FORNECEDOR"] : "0"),
                    NM_FORNECEDOR = row["NM_FORNECEDOR"],
                    NR_CNPJ = row["NR_CNPJ"],
                    DT_CADASTRO = Convert.ToDateTime(row["DT_CADASTRO"]),
                    NOME_FANTASIA = row["NOME_FANTASIA"]
                };
                Fornecedor.Add(tempFornecedor);
            }

            return Fornecedor;
        }
        private int Inserir(Fornecedor fornecedor)
        {
            const string commandText = " INSERT INTO Fornecedor (NM_FORNECEDOR,CD_EMPRESA,DT_CADASTRO,NR_CNPJ) VALUES (@NM_FORNECEDOR,@CD_EMPRESA,@DT_CADASTRO,@NR_CNPJ) ";

            var parameters = new Dictionary<string, object>
            {
                {"NM_FORNECEDOR", fornecedor.NM_FORNECEDOR},
                 {"CD_EMPRESA", fornecedor.CD_EMPRESA},
                 {"DT_CADASTRO", fornecedor.DT_CADASTRO},
                 {"NR_CNPJ", fornecedor.NR_CNPJ}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }
        private int Alterar(Fornecedor fornecedor)
        {
            var commandText = " UPDATE Fornecedor SET ";
            commandText += " NM_FORNECEDOR = @NM_FORNECEDOR, ";
            commandText += " NR_CNPJ = @NR_CNPJ, ";
            commandText += " CD_EMPRESA = @CD_EMPRESA ";
            commandText += " WHERE CD_FORNECEDOR = @CD_FORNECEDOR ";

            var parameters = new Dictionary<string, object>
            {
                {"CD_FORNECEDOR", fornecedor.Id},
                {"NR_CNPJ", fornecedor.NR_CNPJ},
                {"CD_EMPRESA", fornecedor.CD_EMPRESA},
                {"NM_FORNECEDOR", fornecedor.NM_FORNECEDOR}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }
        public void Salvar(Fornecedor fornecedor)
        {
            if (fornecedor.Id > 0)
                Alterar(fornecedor);
            else
                Inserir(fornecedor);
        }
        public int Excluir(int Id)
        {
            const string strQuery = "DELETE FROM Fornecedor WHERE CD_FORNECEDOR = @CD_FORNECEDOR";
            var parametros = new Dictionary<string, object>
            {
                {"CD_FORNECEDOR", Id}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }
        public Fornecedor ListarPorId(int id)
        {
            var fornecedor = new List<Fornecedor>();
            const string strQuery = "SELECT CD_FORNECEDOR, NM_FORNECEDOR,NR_CNPJ,CD_EMPRESA FROM Fornecedor WHERE CD_FORNECEDOR = @CD_FORNECEDOR";
            var parametros = new Dictionary<string, object>
            {
                {"CD_FORNECEDOR", id}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempFornecedor = new Fornecedor
                {
                    Id = int.Parse(!string.IsNullOrEmpty(row["CD_FORNECEDOR"]) ? row["CD_FORNECEDOR"] : "0"),
                    NM_FORNECEDOR = row["NM_FORNECEDOR"],
                    CD_EMPRESA = int.Parse(!string.IsNullOrEmpty(row["CD_EMPRESA"]) ? row["CD_EMPRESA"] : "0"),
                    NR_CNPJ = row["NR_CNPJ"]
                };
                fornecedor.Add(tempFornecedor);
            }

            return fornecedor.FirstOrDefault();
        }
    }
}