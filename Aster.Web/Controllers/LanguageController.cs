using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aster.Services.Localization;
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
                    Orders = l.Orders,
                    Rtl = l.Rtl
                });
            }

            var french = await _languageService.GetLanguageById(2);

            list.tempXml = await _localizationService.ExportToXml(french);

            list.tempJson = await _localizationService.ExportToJson(french);

            return View(list);
        }
    }
}