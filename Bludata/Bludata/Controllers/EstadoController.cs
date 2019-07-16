using MySqlASPNetMVC.Aplicacao;
using MySqlASPNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySqlASPNetMVC.Controllers
{
    public class EstadoController : Controller
    {
        private EstadoAplicacao EmpresaAplicacao;
        public EstadoController()
        {
            EmpresaAplicacao = new EstadoAplicacao();
        }
        public ActionResult Index()
        {
            var lista = EmpresaAplicacao.ListarTodos();
            return View(lista);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Estado estado)
        {
            if (ModelState.IsValid)
            {
                EmpresaAplicacao.Salvar(estado);
                return RedirectToAction("Index");
            }
            return View(estado);
        }

        public ActionResult Editar(int CD_ESTADO)
        {
            var estado = EmpresaAplicacao.ListarPorId(CD_ESTADO);

            if (estado == null)
                return HttpNotFound();

            return View(estado);
        }

        [HttpPost]
        public ActionResult Editar(Estado estado)
        {
            if (ModelState.IsValid)
            {
                EmpresaAplicacao.Salvar(estado);
                return RedirectToAction("Index");
            }
            return View(estado);
        }

        public ActionResult Detalhe(int CD_ESTADO)
        {
            var estado = EmpresaAplicacao.ListarPorId(CD_ESTADO);

            if (estado == null)
                return HttpNotFound();

            return View(estado);
        }

        public ActionResult Excluir(int CD_ESTADO)
        {
            var estado = EmpresaAplicacao.ListarPorId(CD_ESTADO);

            if (estado == null)
                return HttpNotFound();

            return View(estado);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int CD_ESTADO)
        {
            EmpresaAplicacao.Excluir(CD_ESTADO);
            return RedirectToAction("Index");
        }
    }
}