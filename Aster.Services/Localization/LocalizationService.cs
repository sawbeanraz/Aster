using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aster.Core.Domain.Localization;
using Aster.Data;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;


namespace Aster.Services.Localization {
    public class LocalizationService : ILocalizationService {


        private readonly IRepositoryAsync<LocaleString> _localeRepository;
        private readonly ILanguageService _languageService;
        //private readonly ILogger _logger;
        //private readonly ICacheService _cacheService;
        
        public LocalizationService(
            IRepositoryAsync<LocaleString> localeRepository,
            ILanguageService languageService) {
            _localeRepository = localeRepository;
            _languageService = languageService;
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
            return await GetLocaleStrings(language.Id);            
        }

        public async Task<IList<LocaleString>> GetLocaleStrings(int languageId) {
            var query = from r in _localeRepository.List
                        orderby r.MsgId
                        where r.LanguageId == languageId
                        select r;
            return await Task.FromResult(query.ToList());
        }

        public async Task InsertLocaleString(LocaleString localeString) {
            await _localeRepository.InsertAsync(localeString);
        }

        public async Task UpdateLocaleString(LocaleString localeString) {
            await _localeRepository.UpdateAsync(localeString);
        }

        public async Task<string> ToJson(Language language) {
            if(language == null)
                throw new ArgumentNullException(nameof(language));

            language.LocaleStrings = await GetLocaleStrings(language);

            return await Task.FromResult(JsonConvert.SerializeObject(language, 
                Formatting.Indented, new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));            
            
        }

        public async Task<string> ToXml(Language language) {
            if(language == null)
                throw new ArgumentNullException(nameof(language));

            language.LocaleStrings = await GetLocaleStrings(language);

            var xml  = new XElement("Language",
                new XElement("Name", language.Name),
                new XElement("LanguageCulture", language.LanguageCulture),
                new XElement("Rtl", language.Rtl),
                new XElement("LocaleStrings", 
                    language.LocaleStrings.Select(l =>
                    new XElement("LocaleString",
                        new XElement("MsgId", l.MsgId),
                        new XElement("MsgStr", l.MsgStr)))));

            return await Task.FromResult(xml.ToString());
        }


        public async Task<bool> ImportFromJson(string json) {
            try {
                var languageFromJson = JsonConvert.DeserializeObject<Language>(json);

                await InsertUpdateLanguage(new Language() {
                    Name = languageFromJson.Name,
                    LanguageCulture = languageFromJson.LanguageCulture,
                    Rtl = languageFromJson.Rtl,
                    Enabled = true,
                    Orders = languageFromJson.Orders
                }, languageFromJson.LocaleStrings);

                return true;
            } catch (Exception e) {
                throw e;
            }
        }

        public async Task<bool> ImportFromXml(string xml) {
            try {
                var _language = XElement.Parse(xml);

                var localeStrings =
                    from e in _language.Element("LocaleStrings").Descendants("LocaleString")
                    select new LocaleString {
                        MsgId = (string)e.Element("MsgId"),
                        MsgStr = (string)e.Element("MsgStr")
                    };

                var languageFromXml = new Language() {
                    Name = (string)_language.Element("Name"),
                    LanguageCulture = (string)_language.Element("LanguageCulture"),
                    Rtl = (bool)_language.Element("Rtl")
                };

                await InsertUpdateLanguage(new Language() {
                    Name = (string)_language.Element("Name"),
                    LanguageCulture = (string)_language.Element("LanguageCulture"),
                    Rtl = (bool)_language.Element("Rtl")
                }, localeStrings.ToList());

                return true;
            } catch (Exception ex) {
                //TODO: ILogger
                throw ex;
            }
        }


        private async Task InsertUpdateLanguage(Language language, IList<LocaleString> localeStrings) {

            var lang = await _languageService.GetLanguageByName(language.Name);
            if(lang == null) {
                lang = new Language {
                    Name = language.Name,
                    LanguageCulture = language.LanguageCulture,
                    Rtl = language.Rtl,
                    Enabled = language.Enabled,
                    Orders = language.Orders
                };
                await _languageService.InsertLanguage(lang);
            } else {
                lang.LanguageCulture = language.LanguageCulture;
                lang.Rtl = language.Rtl;
                lang.Orders = language.Orders;
                lang.Enabled = language.Enabled;
                await _languageService.UpdateLanguage(lang);
            }
            
            var currentLocales = await GetLocaleStrings(lang.Id);
            var newLocales = new List<LocaleString>();

            foreach(var locale in localeStrings) {
                var l = currentLocales.FirstOrDefault(x => x.MsgId == locale.MsgId);
                if(l != null) {
                    l.MsgStr = locale.MsgStr;
                } else {
                    newLocales.Add(new LocaleString {
                        LanguageId = lang.Id,
                        MsgId = locale.MsgId,
                        MsgStr = locale.MsgStr
                    });
                }
            }

            await InsertLocaleStrings(newLocales);
            await UpdateLocaleStrings(currentLocales);
        }


        private async Task InsertLocaleStrings(IList<LocaleString> localeStrings) {
            foreach(var l in localeStrings) {
                await InsertLocaleString(l);
            }            
        }

        private async Task UpdateLocaleStrings(IList<LocaleString> localeStrings) {
            foreach(var l in localeStrings) {
                await UpdateLocaleString(l);
            }
        }
    }
}