using Aster.Core.Domain.Contractors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aster.Core.Services.Contractors {
    public interface IContractorService {

        Task<IList<Contractor>> GetContractors();

        Task<Contractor> GetContractorByReference(string referenceNo);
        Task<Contractor> InsertContrator(Contractor contractor);
        void UpdateContractor(Contractor contractor);
        void DeleteContractor(Contractor contractor);

    }
}