using Aster.Framework.Localization;
using System;
using System.Collections.Generic;
using System.Text;





namespace Aster.Framework.Mvc.Razor {
    public abstract class AsterRazorPage<TModel>: Microsoft.AspNetCore.Mvc.Razor.RazorPage<TModel> {

        private Localizer _localizer;


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


    }
}
