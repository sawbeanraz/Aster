using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Aster.Core.Domain.Contractors;
using Aster.System.Data;

namespace Aster.Core.Services.Contractors {
    public class ContractorService : IContractorService {

        private readonly IRepositoryAsync<Contractor> _contractorRepository;
        private readonly IRepositoryAsync<ContractorBankAccount> _contractorBankAccountRepository;

        public ContractorService(
            IRepositoryAsync<Contractor> contractorRespository,
            IRepositoryAsync<ContractorBankAccount> contractorBankAccountRepository) {

            _contractorRepository = contractorRespository;
            _contractorBankAccountRepository = contractorBankAccountRepository;
        }

        public async void DeleteContractor(Contractor contractor) {
            await _contractorRepository.DeleteAsync(contractor);
        }

        public async Task<Contractor> GetContractorByReference(string referenceNo) {
            var q = from c in _contractorRepository.List
                    where c.ReferenceNo == referenceNo
                    select c;
            return await Task.FromResult(q.FirstOrDefault());
        }

        public async Task<Contractor> GetContractorById(int Id) {
            return await _contractorRepository.GetByIdAsync(Id);
        }

        public async Task<IList<Contractor>> GetContractors() {
            //TODO: Pagination
            var q = from c in _contractorRepository.List
                    select c;                        
            return await Task.FromResult(q.ToList());
        }

        

        public async Task<Contractor> InsertContrator(Contractor contractor) {

            if(contractor == null) throw new ArgumentNullException(typeof(Contractor).FullName);


            if (string.IsNullOrWhiteSpace(contractor.Forename.Trim())) 
                throw new ArgumentException("Forename can not be blank.", typeof(Contractor).FullName);

            if(string.IsNullOrWhiteSpace(contractor.Surname.Trim()))
                throw new ArgumentException("Surname can not be blank.", typeof(Contractor).FullName);

            
            if(string.IsNullOrWhiteSpace(contractor.Gender.Trim())) {
                throw new ArgumentException("Gender can not be blank.", typeof(Contractor).FullName);
            }


            return await _contractorRepository.InsertAsync(contractor);
        }

        public async Task UpdateContractor(Contractor contractor) {
            await _contractorRepository.UpdateAsync(contractor);
        }





        #region Contractor Bank Account
        public async Task DeleteContractorBankAccount(ContractorBankAccount contractorBankAccount) {
            await _contractorBankAccountRepository
                .DeleteAsync(contractorBankAccount);
        }

        public async Task<ContractorBankAccount> GetBankAccountById(int BankAccountId) {
            return await _contractorBankAccountRepository
                .GetByIdAsync(BankAccountId);
        }

        public async Task<IList<ContractorBankAccount>> GetBankAccounts(int ContractorId) {
            var q = from account in _contractorBankAccountRepository.List
                    where account.ContractorId == ContractorId
                    select account;

            return await Task.FromResult(q.ToList());
        }

        public Task<ContractorBankAccount> InsertContractorBankAccount(ContractorBankAccount contractorBankAccount) {
            throw new NotImplementedException();
        }

        public async Task UpdateContractorBankAccount(ContractorBankAccount contractorBankAccount) {
            await _contractorBankAccountRepository.UpdateAsync(contractorBankAccount);
        }

        public Task UpdateDefaultBankAccount(ContractorBankAccount contractorBankAccount) {
            throw new NotImplementedException();
        }
        #endregion

    }
}