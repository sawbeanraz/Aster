using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aster.System.Data {
    public class DataSettingsManager {
        private const string _DataSettingsFile = "~/App_Data/dataSettings.json";

        public virtual DataSettings LoadSettings(string filePath = null, bool reloadSettings = false) {

            //NOTE: Code Used from nopCommerce
            filePath = filePath ?? _DataSettingsFile;
            filePath = filePath.Replace("~/", "").TrimStart('/').Replace('/', '/');

            var text = File.ReadAllText(filePath);
            if(string.IsNullOrEmpty(text))          //empty settings
                return new DataSettings();

            return JsonConvert.DeserializeObject<DataSettings>(text);
        }



        public virtual void SaveSettings(DataSettings settings) {
            //TODO: Save settings in Single Class for Data

        }
    }
}
