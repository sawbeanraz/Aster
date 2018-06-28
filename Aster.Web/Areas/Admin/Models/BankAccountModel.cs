namespace Aster.Web.Areas.Admin.Models {
    public class BankAccountModel {

        public int Id { get; set; }

        public int ContractorId { get; set; }

        public string SortCode { get; set; }

        public string AccountNumber { get; set; }

        public string BankName { get; set; }

        public string BankBranchName { get; set; }

        public string BankAddress { get; set; }

        public bool Default { get; set; }
    }
}