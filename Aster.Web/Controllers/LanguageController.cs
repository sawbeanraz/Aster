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

        public LanguageController(ILanguageService languageService) {
            _languageService = languageService;
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
            return View(list);
        }
    }
}