using Aster.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aster.Services.Localization {
    public interface ILanguageService {

        Task<IList<Language>> GetLanguages();
        Task<Language> GetLanguageById(int Id);
        Task<bool> SaveLanguage(Language language);
        Task<bool> DeleteLanguage(Language language);
        Task<bool> DeleteLanguageById(int languageId);        
    }
}