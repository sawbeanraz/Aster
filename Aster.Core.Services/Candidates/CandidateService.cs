using System;
using System.Collections.Generic;
using System.Text;
using Aster.Core.Domain;
using Aster.System.Data;
using System.Linq;

namespace Aster.Core.Services.Candidates
{
    public class CandidateService : ICandidateService
    {


        private readonly IRepositoryAsync<Candidate> _candidateRepository;

        public CandidateService(IRepositoryAsync<Candidate> candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public IList<Candidate> GetCandidates()
        {
            var query = from c in _candidateRepository.List
                        select c;
            return query.ToList();
        }

        public void InsertCandidate(Candidate c)
        {
            _candidateRepository.InsertAsync(c);
        }
    }
}
