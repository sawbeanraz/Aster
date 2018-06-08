using Aster.Core.Domain.Contractors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aster.Core.Services.Contractors {
    public interface IContractorService {

        Task<IList<Contractor>> GetContractors();

        Task<Contractor> GetContractorByReference(string referenceNo);
        Task<Contractor> GetContractorById(int Id);
        Task<Contractor> InsertContrator(Contractor contractor);
        void UpdateContractor(Contractor contractor);
        void DeleteContractor(Contractor contractor);




        #region Contractor Bank Details

        Task<IList<ContractorBankAccount>> GetBankAccounts(int ContractorId);
        Task<ContractorBankAccount> InsertContractorBankAccount(ContractorBankAccount contractorBankAccount);

        void UpdateContractorBankAccount(ContractorBankAccount contractorBankAccount);

        void DeleteContractorBankAccount(ContractorBankAccount contractorBankAccount);

        void UpdateDefaultBankAccount(ContractorBankAccount contractorBankAccount);

        #endregion
    }
}