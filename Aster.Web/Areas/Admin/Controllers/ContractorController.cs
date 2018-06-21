using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aster.Core.Services.Contractors;
using Aster.Web.Areas.Admin.Models;
using Aster.Web.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace Aster.Web.Areas.Admin.Controllers {
    [Area("Admin")]
    public class ContractorController : Controller {
        private readonly IContractorService _contractorService;


        public ContractorController(IContractorService contractorService) {

            _contractorService = contractorService;
        }


        public async Task<IActionResult> Index() {


            var _list = new ContractorListModel();

            var contractors = await _contractorService.GetContractors();

            _list.contractors = contractors.Select(c => c.ToModel()).ToList();


            var test = await _contractorService.GetBankAccounts(1);
            foreach(var a in test) {
                Console.WriteLine(a.BankAddress, a.SortCode, a.AccountNumber, a.BankName);
            }

            return View(_list);
        }
        
        public async Task<IActionResult> Detail(int Id) {

            var c = await _contractorService
                .GetContractorById(Id);
            return View(new ContractorDetailViewModel {
                Contractor = c.ToModel()
            });
        }
    }
}