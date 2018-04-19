using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Framework.Localization
{
    public delegate LocalizedString Localizer(string text, params object[] args);
    public delegate LocalizedString Pluralizer(string singular, string plural, int count, params object[] args);
}
