using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aster.Core.Services.Contractors;
using Aster.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aster.Web.Controllers {
    public class ContractorController : Controller {

        private readonly IContractorService _contractorService;
        

        public ContractorController(IContractorService contractorService) {

            _contractorService = contractorService;            
        }
   

        public async Task<IActionResult> Index() {


            var _list = new ContractorListModel();

            var contractors = await _contractorService.GetContractors();

            _list.contractors = contractors.Select(c => new ContractorModel {
                Id = c.Id,
                ReferenceNo = c.ReferenceNo,
                Forename = c.Forename,
                Middlename = c.Middlename,
                Surname = c.Surname,
                DateOfBirth = c.DateOfBirth,
                Gender = c.Gender,
                NationalInsuranceNo = c.NationalInsuranceNo,
                Address1 = c.Address1,
                Address2 = c.Address2,
                County = c.County,
                PostCode = c.PostCode,
                ContactNo = c.ContactNo,
                Email = c.Email,
                CreatedOnUtc = c.CreatedOnUtc,
                UpdatedOnUtc = c.UpdatedOnUtc
            }).ToList();


            var test = await _contractorService.GetBankAccounts(1);
            foreach(var a in test) {
                Console.WriteLine(a.BankAddress, a.SortCode, a.AccountNumber, a.BankName);
            }

            return View(_list);
        }

        public async Task<IActionResult> Detail(int Id) {

            var c = await _contractorService
                .GetContractorById(Id);

            var contractor = new ContractorModel() {
                Id = c.Id,
                ReferenceNo = c.ReferenceNo,
                Forename = c.Forename,
                Middlename = c.Middlename,
                Surname = c.Surname,
                DateOfBirth = c.DateOfBirth,
                Gender = c.Gender,
                NationalInsuranceNo = c.NationalInsuranceNo,
                Address1 = c.Address1,
                Address2 = c.Address2,
                County = c.County,
                PostCode = c.PostCode,
                ContactNo = c.ContactNo,
                Email = c.Email,
                CreatedOnUtc = c.CreatedOnUtc,
                UpdatedOnUtc = c.UpdatedOnUtc
            };
            
            return View(new ContractorDetailViewModel {
                Contractor = contractor
            });
        }
    }
}