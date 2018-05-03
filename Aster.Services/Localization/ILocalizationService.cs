using Aster.Core.Domain.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aster.Services.Localization {
    public interface ILocalizationService {

        Task<LocaleString> GetLocaleString(int localeStringId);
        Task<LocaleString> GetLocaleString(string msgId, int languageId);
        Task<IList<LocaleString>> GetLocaleStrings(Language language);


        Task DeleteLocaleString(LocaleString localeString);
        Task InsertLocaleString(LocaleString localeString);
        Task UpdateLocaleString(LocaleString localeString);

        Task<string> ExportToXml(Language language);
        Task<string> ExportToJson(Language language);


        Task<bool> ImportFromXml(Language language, string xml);
        Task<bool> ImportFromJson(Language language, string json);
    }
}