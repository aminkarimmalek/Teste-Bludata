using MySqlASPNetMVC.Models;
using MySqlASPNetMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySqlASPNetMVC.Aplicacao
{
    public class EstadoAplicacao
    {

        private readonly Contexto contexto;

        public EstadoAplicacao()
        {
            contexto = new Contexto();
        }

        public List<Estado> ListarTodos()
        {
            var Estado = new List<Estado>();
            const string strQuery = "SELECT CD_ESTADO, DS_ESTADO FROM Estado";

            var rows = contexto.ExecutaComandoComRetorno(strQuery, null);
            foreach (var row in rows)
            {
                var tempEstado = new Estado
                {
                    Id = int.Parse(!string.IsNullOrEmpty(row["CD_ESTADO"]) ? row["CD_ESTADO"] : "0"),
                    DS_ESTADO = row["DS_ESTADO"]
                };
                Estado.Add(tempEstado);
            }

            return Estado;
        }
        private int Inserir(Estado estado)
        {
            const string commandText = " INSERT INTO Estado (DS_ESTADO) VALUES (@DS_ESTADO) ";

            var parameters = new Dictionary<string, object>
            {
                {"DS_ESTADO", estado.DS_ESTADO}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }
        private int Alterar(Estado estado)
        {
            var commandText = " UPDATE Estado SET ";
            commandText += " DS_ESTADO = @DS_ESTADO ";
            commandText += " WHERE CD_ESTADO = @CD_ESTADO ";

            var parameters = new Dictionary<string, object>
            {
                {"CD_ESTADO", estado.Id},
                {"DS_ESTADO", estado.DS_ESTADO}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }
        public void Salvar(Estado estado)
        {
            if (estado.Id > 0)
                Alterar(estado);
            else
                Inserir(estado);
        }
        public int Excluir(int CD_ESTADO)
        {
            const string strQuery = "DELETE FROM Estado WHERE CD_ESTADO = @CD_ESTADO";
            var parametros = new Dictionary<string, object>
            {
                {"CD_ESTADO", CD_ESTADO}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }
        public Estado ListarPorId(int CD_ESTADO)
        {
            var estado = new List<Estado>();
            const string strQuery = "SELECT CD_ESTADO, DS_ESTADO FROM Estado WHERE CD_ESTADO = @CD_ESTADO";
            var parametros = new Dictionary<string, object>
            {
                {"CD_ESTADO", CD_ESTADO}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempEstado = new Estado
                {
                    Id = int.Parse(!string.IsNullOrEmpty(row["CD_ESTADO"]) ? row["CD_ESTADO"] : "0"),
                    DS_ESTADO = row["DS_ESTADO"]
                };
                estado.Add(tempEstado);
            }

            return estado.FirstOrDefault();
        }
    }
}