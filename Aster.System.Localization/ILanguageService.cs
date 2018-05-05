using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aster.System.Localization {
    public interface ILanguageService {

        Task<IList<Language>> GetLanguages();
        Task<Language> GetLanguageById(int Id);
        Task<Language> GetLanguageByName(string Name);
        Task InsertLanguage(Language language);
        Task UpdateLanguage(Language language);
        Task DeleteLanguage(Language language);
        Task DeleteLanguageById(int languageId);
    }
}
