using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aster.Web.Models {
    public class ContractorDetailViewModel {
        public ContractorModel Contractor;


        //public List<SelectListItem> Genders { get; } = new List<SelectListItem> {
        //    new SelectListItem { Value = "Male", Text = "Male" },
        //    new SelectListItem { Value = "Female", Text = "Female" },
        //};

        public List<string> Genders { get; } = new List<string> {
            "Male", "Female"
        };
    }
}