using MySqlASPNetMVC.Aplicacao;
using MySqlASPNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySqlASPNetMVC.Controllers
{
    public class EmpresaController : Controller
    {
        private EmpresaAplicacao EmpresaAplicacao;
        private EstadoAplicacao EstadoAplicacao;
        public EmpresaController()
        {
            EmpresaAplicacao = new EmpresaAplicacao();
            EstadoAplicacao = new EstadoAplicacao();
        }
        public ActionResult Index()
        {
            var results = EmpresaAplicacao.ListarTodos();

            return View(results.ToList());
        }

        public ActionResult Cadastrar()
        {
            var estado = EstadoAplicacao.ListarTodos().Select(c => new
            {
                CD_ESTADO = c.Id,
                DS_ESTADO = c.DS_ESTADO

            }).ToList();

            ViewBag.Estados = new SelectList(estado, "CD_ESTADO", "DS_ESTADO");

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                EmpresaAplicacao.Salvar(empresa);
                return RedirectToAction("Index");
            }
            
            return View();
        }

        public ActionResult Editar(int Id)
        {
            var estado = EstadoAplicacao.ListarTodos().Select(c => new
            {
                CD_ESTADO = c.Id,
                DS_ESTADO = c.DS_ESTADO

            }).ToList();

            ViewBag.Estados = new SelectList(estado, "CD_ESTADO", "DS_ESTADO");

            var empresa = EmpresaAplicacao.ListarPorId(Id);
            if (empresa == null)
                return HttpNotFound();
            return View(empresa);
        }

        [HttpPost]
        public ActionResult Editar(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                EmpresaAplicacao.Salvar(empresa);
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        public ActionResult Detalhe(int id)
        {
            var empresa = EmpresaAplicacao.ListarPorId(id);

            if (empresa == null)
                return HttpNotFound();

            return View(empresa);
        }

        public ActionResult Excluir(int id)
        {
            var empresa = EmpresaAplicacao.ListarPorId(id);

            if (empresa == null)
                return HttpNotFound();

            return View(empresa);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            EmpresaAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}