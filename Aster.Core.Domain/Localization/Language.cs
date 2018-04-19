using Aster.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Core.Domain.Localization {
    public class Language : BaseEntity {

        public string Name { get; set; }

        public string LanguageCulture { get; set; }

        public bool Rtl { get; set; }

        public bool Enabled { get; set; }
    
        public int Orders { get; set; }

    }
}
