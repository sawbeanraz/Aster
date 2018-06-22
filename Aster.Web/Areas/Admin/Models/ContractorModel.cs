using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aster.Web.Areas.Admin.Models {
    public class ContractorModel {
        public int Id { get; set; }
        public string ReferenceNo { get; set; }
        public string Forename { get; set; }
        public string Middlename { get; set; }
        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        public string NationalInsuranceNo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }

        public string ContactNo { get; set; }
        public string Email { get; set; }

        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}
