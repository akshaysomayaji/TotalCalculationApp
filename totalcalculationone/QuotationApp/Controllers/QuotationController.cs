using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseLayer.Interfaces;
using DatabaseLayer.Components;
using Entities;
using DataObjects;

namespace QuotationApp.Controllers
{
    public class QuotationController : Controller
    {
        IMasterService imasterService;
        ICustomerService icustomerService;
        public QuotationController()
        {
            imasterService = new MasterService();
            icustomerService = new CustomerService();
        }
        // GET: Quotation
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            MasterData masterData = new MasterData()
            {
                chargeCodeMasters = imasterService.GetCodeMasters(),
                movementTypeMasters = imasterService.GetMovementTypeMasters(),
                currencyMasters = imasterService.GetCurrencyMasters(),
                customers = icustomerService.GetCustomers(),
                IncoTerms = imasterService.GetIncoTerms(),
                portMasters = imasterService.GetPortMasters(),
                UnitMasters = imasterService.GetUnitMasters()

            };
            ViewData["masterdata"] = masterData;
            return View();
        }
    }
}