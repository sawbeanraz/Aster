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

        public ContractorService(
            IRepositoryAsync<Contractor> contractorRespository) {

            _contractorRepository = contractorRespository;
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

        public async Task<IList<Contractor>> GetContractors() {
            //TODO: Pagination
            var q = from c in _contractorRepository.List
                    select c;
            return await Task.FromResult(q.ToList());
        }

        public async Task<Contractor> InsertContrator(Contractor contractor) {
            return await _contractorRepository.InsertAsync(contractor);
        }

        public async void UpdateContractor(Contractor contractor) {
            await _contractorRepository.UpdateAsync(contractor);
        }
    }
}