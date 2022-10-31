using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace MountainPenetratingScanner {
    [HarmonyPatch(typeof(TickManager))]
    public static class TickManager_Patch {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(TickManager.DoSingleTick))]
        public static void DoSingleTick() {
            Scanners.Prune();
            RoofGrid_Patch.Active = Scanners.HasActive(Find.CurrentMap);
        }
    }
}
