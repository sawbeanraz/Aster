using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aster.Core.Services.Contractors;
using Aster.Web.Areas.Admin.Mapper;
using Aster.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aster.Web.Areas.Admin.Controllers {
    [Area("Admin")]
    public class ContractorBankAccountController : Controller {
        private readonly IContractorService _contractorService;

        public ContractorBankAccountController(IContractorService contractorService) {
            _contractorService = contractorService;
        }


        public async Task<IActionResult> Index(int Id) {
            var bankAccount = await _contractorService.GetBankAccountById(Id);
            return View(bankAccount.ToModel());
        }


        [HttpPost]
        public async Task<IActionResult> Index(BankAccountModel bankAccount) {

            await _contractorService.UpdateContractorBankAccount(bankAccount.ToEntity());
            return View(bankAccount);
        }

    }
}