using Aster.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Services.Localization {
    public interface ILocalizationService {

        LocaleString GetLocaleString(int localeStringId);
        LocaleString GetLocaleString(string msgId);
        IList<LocaleString> GetLocaleStrings(Language language);


        void DeleteLocaleString(LocaleString localeString);
        void InsertLocaleString(LocaleString localeString);
        void UpdateLocaleString(LocaleString localeString);

        string ExportToXml(Language language);
        string ExportToJson(Language language);


        bool ImportFromXml(Language language, string xml);
        bool ImportFromJson(Language language, string json);
    }
}