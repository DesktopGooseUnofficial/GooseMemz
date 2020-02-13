using GooseShared;
using System.Threading;

namespace DefaultMod {
    public class ModEntryPoint : IMod {
        void IMod.Init() {
            bool done = false;
            InjectionPoints.PreTickEventHandler preTickEventHandler = default(InjectionPoints.PreTickEventHandler); 
            preTickEventHandler = (GooseEntity g) => {
                InjectionPoints.PreTickEvent -= preTickEventHandler;
                API.Goose.setCurrentTaskByID(g, "FreePrize");
            };
            InjectionPoints.PreTickEvent += preTickEventHandler;
        }
    }
}
