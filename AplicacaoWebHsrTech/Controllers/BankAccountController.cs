using HsrTech.Application.Interface;
using HsrTech.Domain.Entities.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AplicacaoWebHsrTech.Controllers
{
    [Authorize]
    public class BankAccountController : Controller
    {
        // GET: BankAccount
        private readonly IBankAccountApp _bankAccountApp;
        
        public BankAccountController(IBankAccountApp bankAccountApp)
        {
            _bankAccountApp = bankAccountApp;            
        }
        public ActionResult Index()
        {
            try
            {
                var list = _bankAccountApp.ListAccountsByLogin(User.Identity.Name);            
                return View(list);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAccount(BankAccountMetadata model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bankAccountApp.CreateAccount(model.Balance,model.Limit, User.Identity.Name);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult Account(int numberAccount)
        {
            try
            {
                return View(_bankAccountApp.GetAccountByNumberAccount(numberAccount));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult Transfer(int numberAccount)
        {
            try
            {
                return View(_bankAccountApp.GetAccountByNumberAccount(numberAccount));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult TransferValue(decimal value, int numberAccount, int typeTransfer, int numberBankAccount )
        {
            try
            {
                if (numberAccount == numberBankAccount)
                {
                    return View();
                }

                bool sucess = _bankAccountApp.Transfer(value, numberAccount, typeTransfer, User.Identity.Name, numberBankAccount);
                if (sucess)
                {
                    return RedirectToAction("Index","BankAccount");
                }
                else
                {
                    return View();
                }                
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        public ActionResult Chart()
        {
            return View();
        }

        public enum Filter { Day, Hour, Minute }

        [HttpPost]
        public JsonResult GetOpenAccountsBy(Filter filter)
        {
            var list = _bankAccountApp.ListAccountsByLogin(User.Identity.Name);

            IList<object> data = new List<object>();

            switch (filter)
            {
                case Filter.Day:
                    foreach (var i in list.GroupBy(b => b.OpenDate.Date))
                    {
                        data.Add(new { Date = i.First().OpenDate.ToString("yyyy/MM/dd"), Qtd = i.Count() });
                    }
                    
                    return Json(data);
                case Filter.Hour:
                    foreach (var i in list.GroupBy(b => b.OpenDate.Date.AddHours(b.OpenDate.Hour)))
                    {
                        data.Add(new { Date = i.First().OpenDate.ToString("yyyy/MM/dd HH") + "hr(s)", Qtd = i.Count() });
                    }
                    
                    return Json(data);
                case Filter.Minute:
                    foreach (var i in list.GroupBy(b => b.OpenDate.Date.AddHours(b.OpenDate.Hour).AddMinutes(b.OpenDate.Minute)))
                    {
                        data.Add(new { Date = i.First().OpenDate.ToString("yyyy/MM/dd HH:mm"), Qtd = i.Count() });
                    }

                    return Json(data);
                default:
                    return null;
            }
        }
    }
}