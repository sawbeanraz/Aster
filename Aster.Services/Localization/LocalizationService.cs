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

        public async Task<LocaleString> GetLocaleString(string msgId) {
            //TODO: get language from the context
            var query = from r in _localeRepository.List
                        orderby r.Id
                        where r.MsgId == msgId && r.LanguageId == 1
                        select r;
            var localeString = query.FirstOrDefault();
            return await Task.FromResult(localeString);
        }

        public IList<LocaleString> GetLocaleStrings(Language language) {
            var query = from r in _localeRepository.List
                        orderby r.MsgId
                        where r.LanguageId == language.Id
                        select r;
            return query.ToList();
        }

        

        public void InsertLocaleString(LocaleString localeString) {
            throw new NotImplementedException();
        }

        public void UpdateLocaleString(LocaleString localeString) {
            throw new NotImplementedException();
        }



        public string ExportToJson(Language language) {
            throw new NotImplementedException();
        }

        public string ExportToXml(Language language) {
            throw new NotImplementedException();
        }


        public bool ImportFromJson(Language language, string json) {
            throw new NotImplementedException();
        }

        public bool ImportFromXml(Language language, string xml) {
            throw new NotImplementedException();
        }
    }
}