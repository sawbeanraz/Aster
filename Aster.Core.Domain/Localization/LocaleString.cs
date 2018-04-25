using Aster.Data;

namespace Aster.Core.Domain.Localization {
    public class LocaleString : BaseEntity {
        public int LanguageId { get; set; }
        public string MsgId { get; set; }
        public string MsgStr { get; set; }


        public virtual Language Language { get; set; }
    }
}