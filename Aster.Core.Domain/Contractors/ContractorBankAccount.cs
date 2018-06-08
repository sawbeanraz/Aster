using Aster.System.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Core.Domain.Contractors
{
    public class ContractorBankAccount: BaseEntity
    {
        public int ContractorId { get; set; }

        public string SortCode { get; set; }

        public string AccountNumber { get; set; }

        public string BankName { get; set; }

        public string BankBranchName { get; set; }

        public string BankAddress { get; set; }

        public bool Default { get; set; }
        
        public virtual Contractor Contractor { get; set; }
    }
}
