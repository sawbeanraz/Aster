using Aster.System.Mapper;
using AutoMapper;

namespace Aster.Web.Mapper {
    public class DomainModelMapperConfiguration: Profile, IAsterMapper
    {

        public DomainModelMapperConfiguration() {
            
        }

        public int Order => 0;
    }
}
