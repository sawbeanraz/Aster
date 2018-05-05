using Aster.System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aster.System.Localization {
    public class LanguageService : ILanguageService {


        private readonly IRepositoryAsync<Language> _languageRepository;


        public LanguageService(
            IRepositoryAsync<Language> languageRepository) {
            _languageRepository = languageRepository;
        }


        public async Task DeleteLanguage(Language language) {

            if(language == null)
                throw new ArgumentNullException(nameof(language));

            try {
                await _languageRepository.DeleteAsync(language);
                //TODO: event notification language deleted
                //_eventPublisher.EntityDeleted(language);
            } catch(Exception ex) {
                //TODO: Log error 
                throw ex;
            }
        }

        public async Task DeleteLanguageById(int languageId) {
            if(languageId <= 0)
                throw new ArgumentOutOfRangeException(nameof(languageId));

            try {
                var language = await _languageRepository.GetByIdAsync(languageId);
                await _languageRepository.DeleteAsync(language);
            } catch(Exception ex) {
                //TODO: Log Error
                throw ex;
            }
        }

        public async Task<Language> GetLanguageById(int Id) {
            try {
                return await _languageRepository.GetByIdAsync(Id);
            } catch(Exception ex) {
                //TODO: Log error
                throw ex;
            }
        }
        public async Task<Language> GetLanguageByName(string Name) {
            var query = from l in _languageRepository.List
                        where l.Name == Name
                        select l;
            return await Task.FromResult(query.FirstOrDefault());
        }

        public async Task<IList<Language>> GetLanguages() {
            try {
                var query = _languageRepository.List;
                return await Task.FromResult(query.ToArray());
            } catch(Exception ex) {
                //TODO: Log Error;
                throw ex;
            }
        }

        public async Task InsertLanguage(Language language) {
            if(language == null)
                throw new ArgumentNullException(nameof(language));

            await _languageRepository.InsertAsync(language);
            //TODO: Dispatch Event for New Language
        }

        public async Task UpdateLanguage(Language language) {
            if(language == null)
                throw new ArgumentException(nameof(language));

            await _languageRepository.UpdateAsync(language);
            //TODO: Dispatch Event for Language Update
        }
    }
}
