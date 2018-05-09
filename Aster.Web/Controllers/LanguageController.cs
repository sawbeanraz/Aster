﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Aster.System.Localization;
using Aster.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aster.Web.Controllers {
    public class LanguageController : Controller {


        private readonly ILanguageService _languageService;
        private readonly ILocalizationService _localizationService;

        public LanguageController(
            ILanguageService languageService,
            ILocalizationService localizationService) {
            _languageService = languageService;
            _localizationService = localizationService;
        }


        public async Task<IActionResult> Index() {

            var list = new LanguageListModel();
            
            //TODO: Introduct auto mapping
            var languages = await _languageService.GetLanguages();

            foreach(var l in languages) {
                list.LanguageList.Add(new LanguageModel() {
                    Id = l.Id,
                    Name = l.Name,
                    LanguageCulture = l.LanguageCulture,
                    Enabled = l.Enabled,                    
                    Rtl = l.RightToLeft
                });
            }

            var french = await _languageService.GetLanguageById(2);

            var canadianFrench = new Language() {
                Name = "Canadian French",
                LanguageCulture = "CA-fr",
                RightToLeft = false
            };


            canadianFrench.LocaleStrings = new List<LocaleString>() {
                new LocaleString{ MsgId = "Hello", MsgStr = "K chha daka"},
                new LocaleString{ MsgId = "How are you", MsgStr = "K chha halkhabar" }
            };

            
            list.tempXml = await _localizationService.ToXml(french);

            list.tempJson = await _localizationService.ToJson(french);


            string json = await _localizationService.ToJson(canadianFrench);
            json = @"{
  ""Name"": ""Canadian French"",
  ""LanguageCulture"": ""FR-fr"",
  ""RightToLeft"": false,
  ""Enabled"": true,
  ""Orders"": 1,
  ""LocaleStrings"": [
    {
      ""LanguageId"": 2,
      ""MsgId"": ""Hello"",
      ""MsgStr"": ""asdfhasdkjfha skdjfhCanadian Bonjour"",
      ""Id"": 1
    },
    {
      ""LanguageId"": 2,
      ""MsgId"": ""Hello!! How are you?"",
      ""MsgStr"": ""askdfh aksjdfh aksjdhf Canadian Bonjour!! Comment allez-vous?"",
      ""Id"": 2
    }
  ]
}";
            await _localizationService.ImportFromJson(json);


            var xmlString = @"<Language>
  <Name>Hamro French</Name>
  <LanguageCulture>HH-fr</LanguageCulture>
  <RightToLeft>false</RightToLeft>
  <LocaleStrings>
    <LocaleString>
      <MsgId>Hello</MsgId>
      <MsgStr>Bonjour</MsgStr>
    </LocaleString>
    <LocaleString>
      <MsgId>Hello!! How are you?</MsgId>
      <MsgStr>Bonjour!! Comment allez-vous?</MsgStr>
    </LocaleString>
  </LocaleStrings>
</Language>";

            await _localizationService.ImportFromXml(xmlString);
            return View(list);
        }
    }
}