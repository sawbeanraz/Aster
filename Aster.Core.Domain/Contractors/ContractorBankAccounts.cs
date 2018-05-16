using Aster.System.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Core.Domain.Contractors
{
    public class ContractorBankAccounts: BaseEntity
    {
        public string SortCode { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string BankBranchName { get; set; }
        public string BankAddress { get; set; }        
    }
}
