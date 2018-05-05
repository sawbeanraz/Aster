using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aster.System.Localization {
    public interface ILocalizationService {

        Task<LocaleString> GetLocaleString(int localeStringId);
        Task<LocaleString> GetLocaleString(string msgId, int languageId);
        Task<IList<LocaleString>> GetLocaleStrings(Language language);
        Task<IList<LocaleString>> GetLocaleStrings(int languageId);


        Task DeleteLocaleString(LocaleString localeString);
        Task InsertLocaleString(LocaleString localeString);
        Task UpdateLocaleString(LocaleString localeString);

        Task<string> ToXml(Language language);
        Task<string> ToJson(Language language);


        Task<bool> ImportFromXml(string xml);
        Task<bool> ImportFromJson(string json);
    }
}
