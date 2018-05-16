

using Aster.System.Data;
using System;

namespace Aster.Core.Domain {
    public class Candidate: BaseEntity {
        public string Name { get; set; }

        public DateTime DOB { get; set; }

    }
}
