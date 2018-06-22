using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aster.Core.Services.Contractors;
using Aster.Web.Areas.Admin.Models;
using Aster.Web.Areas.Admin.Models.Contractors;
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
            return await Task.FromResult(RedirectToAction("List"));
        }

        public async Task<IActionResult> List() {
            var _list = new ContractorListModel();
            var contractors = await _contractorService.GetContractors();

            _list.contractors = contractors.Select(c => c.ToModel()).ToList();

            var test = await _contractorService.GetBankAccounts(1);
            foreach(var a in test) {
                Console.WriteLine(a.BankAddress, a.SortCode, a.AccountNumber, a.BankName);
            }

            return View(_list);
        }

        [HttpPost]
        public async Task<IActionResult> List(ContratorSearchModel model) {
            var _list = new ContractorListModel();
            _list.contractors = (await _contractorService.GetContractors()).Select(c => c.ToModel()).ToList();
            return View(_list);
        }


        public IActionResult Create() {
            //check for 
            var model = new ContractorModel();
            return View(model);
        }

        public async Task<IActionResult> Create(ContractorModel model) {
            //validate model            
            if(ModelState.IsValid) {
                var contractor = await _contractorService.InsertContrator(model.ToEntity());
                return View(contractor.ToModel());
            }  else {
                return View(model);
            }
        }
        

        public async Task<IActionResult> Edit(int id) {
            var c = await _contractorService
                .GetContractorById(id);
            return View(new ContractorDetailViewModel {
                Contractor = c.ToModel()
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ContractorModel model) {

            model.UpdatedOnUtc = DateTime.UtcNow;
            await _contractorService.UpdateContractor(model.ToEntity());
            
            return View(new ContractorDetailViewModel {
                Contractor = model
            });            
        }
    }
}