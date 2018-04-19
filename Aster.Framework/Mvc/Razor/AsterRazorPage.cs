using Aster.Framework.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;





namespace Aster.Framework.Mvc.Razor {
    public abstract class AsterRazorPage<TModel>: Microsoft.AspNetCore.Mvc.Razor.RazorPage<TModel> {

        private Localizer _localizer;
        private Pluralizer _pluralizer;


        public Localizer T {
            get {
                //if(_localizationService == null)
                //    _localizationService = EngineContext.Current.Resolve<ILocalizationService>();

                //if(_localizer == null) {
                //    _localizer = (format, args) => {
                //        var resFormat = _localizationService.GetResource(format);
                //        if(string.IsNullOrEmpty(resFormat)) {
                //            return new LocalizedString(format);
                //        }
                //        return new LocalizedString((args == null || args.Length == 0)
                //            ? resFormat
                //            : string.Format(resFormat, args));
                //    };
                //}
                if(_localizer == null) {
                    _localizer = (text, args) => {
                        return new LocalizedString($"{text} TERO TAUKO DONE");
                    };                    
                }                
                return _localizer;
            }
        }

        public Pluralizer Plural {
            get {

                if(_pluralizer == null) {
                    _pluralizer = (singular, plural, count, args) => {
                        //TODO: 
                        //1. If count is one get localization text for singlur else plural from service
                        //2. Convert the text to localized string
                        return new LocalizedString(
                            string.Format(
                                count == 1 ? singular : plural,
                                new object[] { count }.Concat(args).ToArray()));
                    };
                }

                return _pluralizer;
            }

        }
    }
}
