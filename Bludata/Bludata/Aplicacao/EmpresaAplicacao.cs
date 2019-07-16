using MySqlASPNetMVC.Models;
using MySqlASPNetMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySqlASPNetMVC.Aplicacao
{
    public class EmpresaAplicacao
    {
        private readonly Contexto contexto;

        public EmpresaAplicacao()
        {
            contexto = new Contexto();
        }

        public List<Empresa> ListarTodos()
        {
            var Empresa = new List<Empresa>();
            const string strQuery = "SELECT " +
                " CD_EMPRESA, " +
                " CNPJ, " +
                " NOME_FANTASIA, " +
                " DS_SIGLA " +
                " FROM Empresa " +
                " JOIN ESTADO ON EMPRESA.CD_ESTADO = ESTADO.CD_ESTADO";

            var rows = contexto.ExecutaComandoComRetorno(strQuery, null);
            foreach (var row in rows)
            {
                var tempEmpresa = new Empresa();
                tempEmpresa.Id = int.Parse(!string.IsNullOrEmpty(row["CD_EMPRESA"]) ? row["CD_EMPRESA"] : "0");
                tempEmpresa.CNPJ = row["CNPJ"];
                tempEmpresa.NOME_FANTASIA = row["NOME_FANTASIA"];
                tempEmpresa.DS_SIGLA = row["DS_SIGLA"];
                Empresa.Add(tempEmpresa);
            }
            return Empresa;
        }
        private int Inserir(Empresa empresa)
        {
            const string commandText = " INSERT INTO Empresa ( NOME_FANTASIA,CD_ESTADO,CNPJ ) VALUES ( @NOME_FANTASIA, @CD_ESTADO, @CNPJ) ";

            var parameters = new Dictionary<string, object>
            {
                {"NOME_FANTASIA", empresa.NOME_FANTASIA},
                {"CD_ESTADO", empresa.CD_ESTADO},
                {"CNPJ", empresa.CNPJ},
            };

            return contexto.ExecutaComando(commandText, parameters);
        }
        private int Alterar(Empresa empresa)
        {
            var commandText = " UPDATE Empresa SET ";
            commandText += " NOME_FANTASIA = @NOME_FANTASIA ";
            commandText += " WHERE CD_EMPRESA = @CD_EMPRESA ";

            var parameters = new Dictionary<string, object>
            {
                {"CD_EMPRESA", empresa.Id},
                {"NOME_FANTASIA", empresa.NOME_FANTASIA}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }
        public void Salvar(Empresa empresa)
        {
            if (empresa.Id > 0)
                Alterar(empresa);
            else
                Inserir(empresa);
        }
        public int Excluir(int CD_EMPRESA)
        {
            const string strQuery = "DELETE FROM Empresa WHERE CD_EMPRESA = @CD_EMPRESA";
            var parametros = new Dictionary<string, object>
            {
                {"CD_EMPRESA", CD_EMPRESA}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }
        public Empresa ListarPorId(int CD_EMPRESA)
        {
            var empresa = new List<Empresa>();
            const string strQuery = "SELECT CD_EMPRESA, NOME_FANTASIA,CD_ESTADO,  CNPJ FROM Empresa WHERE CD_EMPRESA = @CD_EMPRESA";
            var parametros = new Dictionary<string, object>
            {
                {"CD_EMPRESA", CD_EMPRESA}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempEmpresa = new Empresa
                {
                    Id = int.Parse(!string.IsNullOrEmpty(row["CD_EMPRESA"]) ? row["CD_EMPRESA"] : "0"),
                    NOME_FANTASIA = row["NOME_FANTASIA"],
                    CNPJ = row["CNPJ"],
                    CD_ESTADO = int.Parse(!string.IsNullOrEmpty(row["CD_ESTADO"]) ? row["CD_ESTADO"] : "0")
                };
                empresa.Add(tempEmpresa);
            }

            return empresa.FirstOrDefault();
        }
    }
}