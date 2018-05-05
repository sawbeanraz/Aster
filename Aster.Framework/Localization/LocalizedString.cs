using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Framework.Localization {
    public class LocalizedString : HtmlString {

        private readonly string _localized;

        public LocalizedString(string localized) : base(localized) {
            _localized = localized;
        }

        public string Text {
            get { return Localized; }
        }

        public string Localized => _localized;
    }
}