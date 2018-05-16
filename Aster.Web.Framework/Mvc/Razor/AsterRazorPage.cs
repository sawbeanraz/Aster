using Aster.System.Engine;
using Aster.System.Localization;
using Aster.Web.Framework.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aster.Web.Framework.Mvc.Razor
{
    public abstract class AsterRazorPage<TModel>: RazorPage<TModel> {


        private Localizer _localizer;
        private Pluralizer _pluralizer;

        private ILocalizationService _localizationService;

        public Localizer _ {
            get {
                if(_localizationService == null)
                    _localizationService = EngineContext.Current.Resolve<ILocalizationService>();

                if(_localizer == null) {
                    _localizer = (msgId, args) => {

                        var localeString = new LocaleString { MsgId = "Non Localization", MsgStr = "test no error" }; //_localizationService.GetLocaleString(msgId, 2).GetAwaiter().GetResult();

                        if(localeString == null) {
                            return new LocalizedString(msgId);
                        }

                        return new LocalizedString((args == null || args.Length == 0)
                            ? localeString.MsgStr
                            : string.Format(localeString.MsgStr, args));
                    };
                }
                return _localizer;
            }
        }

        public Pluralizer __ {
            get {

                if(_pluralizer == null) {
                    _pluralizer = (singular, plural, count, args) => {
                        var msgId = count == 1 ? singular : plural;
                        var localeString = new LocaleString { MsgId = "Non Localization", MsgStr = "test no error" };//_localizationService.GetLocaleString(msgId, 2).Result;
                        if (localeString == null) {
                            return new LocalizedString(string.Format(msgId, new object[] { count }.Concat(args).ToArray()));

                        } else {
                            return new LocalizedString(
                                string.Format(localeString.MsgStr, 
                                    new object[] { count }.Concat(args).ToArray()));
                        }
                    };
                }
                return _pluralizer;
            }

        }
    }
}
