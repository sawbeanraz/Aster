using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aster.Core.Domain.Localization;
using Aster.Data;

namespace Aster.Services.Localization {
    public class LanguageService : ILanguageService {


        private readonly IRepositoryAsync<Language> _languageRepository;
        

        public LanguageService(
            IRepositoryAsync<Language> languageRepository) {
            _languageRepository = languageRepository;
        }


        public async Task<bool> DeleteLanguage(Language language) {

            if(language == null)
                throw new ArgumentNullException(nameof(language));

            try {
                await _languageRepository.DeleteAsync(language);


                //TODO: event notification language deleted
                //_eventPublisher.EntityDeleted(language);

                return true;
            } catch (Exception ex) {
                //TODO: Log error 
                throw ex;
            }
        }

        public async Task<bool> DeleteLanguageById(int languageId) {
            if(languageId <= 0)
                throw new ArgumentOutOfRangeException(nameof(languageId));

            try {
                var language = await _languageRepository.GetByIdAsync(languageId);
                await _languageRepository.DeleteAsync(language);
                return true;
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

        public async Task<IList<Language>> GetLanguages() {
            try {
                var query = _languageRepository.List;
                return await Task.FromResult(query.ToArray());
            } catch (Exception ex) {
                //TODO: Log Error;
                throw ex;
            }
        }

        public async Task<bool> SaveLanguage(Language language) {
            if(language == null)
                throw new ArgumentNullException(nameof(language));

            try {

                if(language.Id <= 0) {
                    //Insert
                    await _languageRepository.InsertAsync(language);
                } else {
                    //Update
                    await _languageRepository.UpdateAsync(language);
                }
                return true;
            } catch(Exception ex) {
                //TODO: Log Error
                throw ex;
            }
        }
    }
}
