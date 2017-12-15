using EniWine.Database.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EniWine.Controllers
{
    public class HomeController : Controller
    {
        ArmaRepositorio _armaRepositorio;
        SuspeitoRepositorio _suspeitoRepositorio;
        LocalRepositorio _localRepositorio;

        public HomeController()
        {
            _armaRepositorio = new ArmaRepositorio();
            _suspeitoRepositorio = new SuspeitoRepositorio();
            _localRepositorio = new LocalRepositorio();
        }


        public ActionResult Index()
        {
            Session["Culpado"] = Culpado(); // sempre que houver refresh na página os dados do culpados serão alterados e salvos na Session

            //abaixo são carregados todos os dados dos dropdownlist, buscando do banco de dados
            ViewBag.Suspeitos = _suspeitoRepositorio.GetAll().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Descricao }).OrderBy(x => x.Text).ToList();
            ViewBag.Armas = _armaRepositorio.GetAll().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Descricao }).OrderBy(x => x.Text).ToList();
            ViewBag.Locais = _localRepositorio.GetAll().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Descricao }).OrderBy(x => x.Text).ToList();

            return View();
        }

        public ActionResult ValidaTeoria(int suspeito, int local, int arma)
        {
            //essa função irá validar cada um dos parâmetros selecionados na pagina e adicionar os elementos errados
            // numa lista que no final é convertida para um json e enviada de volta para a página

            List<int> result = new List<int>();

            if (((List<int>)Session["Culpado"])[0] != suspeito)
                result.Add(1);

            if (((List<int>)Session["Culpado"])[1] != local)
                result.Add(2);

            if (((List<int>)Session["Culpado"])[2] != arma)
                result.Add(3);

            if (result.Count > 1)
                for (int i = 0; i < result.Count; i++) result[i] = ValorArbitrario();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public List<int> Culpado()
        {
            // essa função irá selecionar randômicamente o suspeito, local e arma
            Random r = new Random();
            List<int> result = new List<int>();

            result.Add(r.Next(1, 7)); //adiciona suspeito (o valor apresentado será entre 1 e 6)
            result.Add(r.Next(1, 9)); //adiciona local (o valor apresentado será entre 1 e 8)
            result.Add(r.Next(1, 7)); //adiciona arma (o valor apresentado será entre 1 e 6)

            return result;
        }

        public int ValorArbitrario()
        {
            //essa função irá retornar um valor randômico entre 1 e 3 e só será acionado quando houver mais
            //de uma resposta incorreta no envio da teoria
            Thread.Sleep(1000); // a thread sleep vou necessária para melhorar a variedade de valores no resultado pois quando executado várias vezes numa velocidade muito rápido ele traz os mesmo valores
            Random r = new Random();
            return r.Next(1, 4);
        }
    }
}