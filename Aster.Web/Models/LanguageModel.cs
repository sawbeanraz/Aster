using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aster.Web.Models {
    public class LanguageModel {

        public int Id { get; set; }
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public bool Rtl { get; set; }
        public bool Enabled { get; set; }
        public int Orders { get; set; }

    }
}