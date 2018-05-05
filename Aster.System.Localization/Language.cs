using Aster.System.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.System.Localization
{
    public class Language : BaseEntity {

        public string Name { get; set; }

        public string LanguageCulture { get; set; }

        public bool RightToLeft { get; set; }

        public bool Enabled { get; set; }

        public virtual IList<LocaleString> LocaleStrings { get; set; }
    }
}
