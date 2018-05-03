using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aster.Core.Domain.Localization;
using Aster.Data;
using System.Linq;

namespace Aster.Services.Localization {
    public class LocalizationService : ILocalizationService {


        private readonly IRepositoryAsync<LocaleString> _localeRepository;
        //private readonly ILogger _logger;

        
        public LocalizationService(IRepositoryAsync<LocaleString> localeRepository) {
            _localeRepository = localeRepository;
        }


        public async Task DeleteLocaleString(LocaleString localeString) {
            await _localeRepository.DeleteAsync(localeString);
        }

        public async Task<LocaleString> GetLocaleString(int localeStringId) {
            return await _localeRepository.GetByIdAsync(localeStringId);
        }

        public async Task<LocaleString> GetLocaleString(string msgId, int languageId) {
            //TODO: get language from the context
            var query = from r in _localeRepository.List
                        orderby r.Id
                        where r.MsgId == msgId && r.LanguageId == languageId
                        select r;
            var localeString = query.FirstOrDefault();
            return await Task.FromResult(localeString);
        }

        public async Task<IList<LocaleString>> GetLocaleStrings(Language language) {
            var query = from r in _localeRepository.List
                        orderby r.MsgId
                        where r.LanguageId == language.Id
                        select r;
            return await Task.FromResult(query.ToList());
        }

        public async Task InsertLocaleString(LocaleString localeString) {
            await _localeRepository.InsertAsync(localeString);
        }

        public async Task UpdateLocaleString(LocaleString localeString) {
            await _localeRepository.UpdateAsync(localeString);
        }

        public async Task<string> ExportToJson(Language language) {
            await Task.Delay(100);
            throw new NotImplementedException();
        }

        public async Task<string> ExportToXml(Language language) {
            await Task.Delay(100);
            throw new NotImplementedException();
        }

        public async Task<bool> ImportFromJson(Language language, string json) {
            await Task.Delay(100);
            throw new NotImplementedException();
        }

        public async Task<bool> ImportFromXml(Language language, string xml) {
            await Task.Delay(100);
            throw new NotImplementedException();
        }
    }
}