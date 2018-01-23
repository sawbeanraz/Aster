using System.Runtime.CompilerServices;

namespace Aster.Framework.Infrastructure.Engine {

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