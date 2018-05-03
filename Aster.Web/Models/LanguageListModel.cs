using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aster.Web.Models {
    public class LanguageListModel {

        public LanguageListModel() {
            LanguageList = new List<LanguageModel>();
        }
        public IList<LanguageModel> LanguageList { get; set; }

        public string tempXml { get; set; }
        public string tempJson { get; set; }
    }
}