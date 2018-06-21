using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aster.Web.Areas.Admin.Models {
    public class ContractorDetailViewModel {
        public ContractorModel Contractor;

        public List<string> Genders { get; } = new List<string> {
            "Male", "Female"
        };
    }
}