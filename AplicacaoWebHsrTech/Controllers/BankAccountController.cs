using HsrTech.Application.Interface;
using HsrTech.Domain.Entities.Metadata;
using HsrTech.Domain.Entities.Partial;
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

        public ActionResult Statistics(StatisticsOptions options)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.DataChart = _bankAccountApp.GetStatisticsByLogin(User.Identity.Name, options);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
        
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
    }
}