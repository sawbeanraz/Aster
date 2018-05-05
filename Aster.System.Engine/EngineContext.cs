using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using Aster.System.Abstractions;

namespace Aster.System.Engine {
    public class EngineContext {

        // Static instance of AsterEngine (ref NopCommerce)
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Create() {
            if(Singleton<IEngine>.Instance == null) {
                Singleton<IEngine>.Instance = new AsterEngine();
            }

            return Singleton<IEngine>.Instance;
        }

        public static void Replace(IEngine engine) {
            Singleton<IEngine>.Instance = engine;
        }

        public static IEngine Current {
            get {
                if(Singleton<IEngine>.Instance == null) {
                    Create();
                }

                return Singleton<IEngine>.Instance;
            }
        }
    }
}