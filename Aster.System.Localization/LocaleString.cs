using Aster.System.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.System.Localization {
    public class LocaleString : BaseEntity {
        public int LanguageId { get; set; }
        public string MsgId { get; set; }
        public string MsgStr { get; set; }

        public virtual Language Language { get; set; }
    }
}
