using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aster.Core.Services.Candidates;
using Aster.Web.Models;

namespace Aster.Web.Controllers
{
    public class CandidateController : Controller
    {



        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }


        public IActionResult Index()
        {


            var candidateList =  _candidateService.GetCandidates();

            var model = new CandidatesModel
            {
                Candidates = candidateList.ToList()
            };

            return View(model);
        }
    }
}