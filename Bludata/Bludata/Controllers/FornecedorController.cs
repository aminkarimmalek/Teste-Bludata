using MySqlASPNetMVC.Aplicacao;
using MySqlASPNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySqlASPNetMVC.Controllers
{
    public class FornecedorController : Controller
    {
        private FornecedorAplicacao FornecedorAplicacao;
        private EmpresaAplicacao EmpresaAplicacao;
        public FornecedorController()
        {
            FornecedorAplicacao = new FornecedorAplicacao();
            EmpresaAplicacao = new EmpresaAplicacao();
        }
        public ActionResult Index()
        {
            var lista = FornecedorAplicacao.ListarTodos();
            return View(lista);
        }

        public ActionResult Cadastrar()
        {
            var Empresas = EmpresaAplicacao.ListarTodos().Select(c => new
            {
                CD_EMPRESA = c.Id,
                NOME_FANTASIA = c.NOME_FANTASIA

            }).ToList();

            ViewBag.Empresas = new SelectList(Empresas, "CD_EMPRESA", "NOME_FANTASIA");

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                FornecedorAplicacao.Salvar(fornecedor);
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        public ActionResult Editar(int Id)
        {
            var Empresas = EmpresaAplicacao.ListarTodos().Select(c => new
            {
                CD_EMPRESA = c.Id,
                NOME_FANTASIA = c.NOME_FANTASIA

            }).ToList();

            ViewBag.Empresas = new SelectList(Empresas, "CD_EMPRESA", "NOME_FANTASIA");

            var fornecedor = FornecedorAplicacao.ListarPorId(Id);
            if (fornecedor == null)
                return HttpNotFound();

            return View(fornecedor);
        }

        [HttpPost]
        public ActionResult Editar(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                FornecedorAplicacao.Salvar(fornecedor);
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        public ActionResult Detalhe(int id)
        {
            var fornecedor = FornecedorAplicacao.ListarPorId(id);

            if (fornecedor == null)
                return HttpNotFound();

            return View(fornecedor);
        }

        public ActionResult Excluir(int id)
        {
            var fornecedor = FornecedorAplicacao.ListarPorId(id);

            if (fornecedor == null)
                return HttpNotFound();

            return View(fornecedor);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            FornecedorAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}