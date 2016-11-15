using ClientRest.WS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WsReceita.Models;

namespace ClientRest.Controllers
{
    public class ReceitaController : Controller
    {
        private Operacoes op;
        private static Receita receita;
        public ReceitaController()
        {
            op = new Operacoes();
        }

        // GET: Receita
        public ActionResult Index(int id = -1)
        {
            if (id != -1)
            {
                receita = op.ObterReceitaMedica(new NumeroReceita { Numero = id });

                return View(new List<Receita> { receita });
            }

            return View(new List<Receita> { });
        }

        public ActionResult Create()
        {
            receita = new Receita();
            return View(receita);
        }

        public ActionResult Details(Receita r)
        {
            if (receita.NumReceita == r.NumReceita)
                r = receita;

            return View(r);
        }

        public ActionResult Procura()
        {
            return View();
        }

        public ActionResult Cancela(Receita r)
        {
            op.CancelarReceitaMedica(new NumeroReceita() { Numero = r.NumReceita });
            return Index(r.NumReceita);
        }

        public ActionResult Utiliza(Receita r)
        {
            op.UtilizarReceitaMedica(new NumeroReceita() { Numero = r.NumReceita });
            return Index(r.NumReceita);
        }

        public ActionResult ItensReceita(Receita r)
        {
            r.ItensReceita = receita.ItensReceita;
            if (r.Medico != null && r.Paciente != null)
                receita = r;
                
            return View(receita.ItensReceita);
        }

        public ActionResult CriarItem()
        {
            var item = new Item();
            return View(item);
        }

        public ActionResult NovoItemReceita(Item i)
        {
            i.NumReceita = receita.NumReceita;
            receita.ItensReceita.Add(i);
            return RedirectToAction("ItensReceita", "Receita", receita);
        }

        public ActionResult CriarReceita()
        {
            receita.Cpf = receita.Paciente.Cpf;
            receita.Crm = receita.Medico.Crm;
            receita.Medico.Usuario = new Usuario()
            {
                Login = string.Format("{0}{1}{2}{3}{4}{5}", 
                DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                Senha = string.Format("{0}{1}{2}{3}{4}{5}",
                DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
            };

            op.CadastrarReceitaMedica(receita);
            return RedirectToAction("Index", "Receita");
        }
    }
}