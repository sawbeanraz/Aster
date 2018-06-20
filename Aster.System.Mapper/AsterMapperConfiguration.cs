using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.System.Mapper {


    /// <summary>
    /// Aster static mapper for engine to inject configuration from the web model
    /// </summary>
    public static class AsterMapperConfiguration {
        public static IMapper Mapper { get; private set; }


        public static MapperConfiguration MapperConfiguration { get; private set; }

        public static void Init(MapperConfiguration config) {
            MapperConfiguration = config;
            Mapper = config.CreateMapper();
        }

    }
}
