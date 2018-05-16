using Aster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Core.Services.Candidates
{
    public interface ICandidateService
    {

        IList<Candidate> GetCandidates();
        void InsertCandidate(Candidate c);

    }
}
