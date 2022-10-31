using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace MountainPenetratingScanner {
    public static class Scanners {
        private static readonly List<CompDeepScanner> scanners = new List<CompDeepScanner>();

        public static void Add(CompDeepScanner comp) => 
            scanners.Add(comp);

        public static void Prune() => 
            scanners.RemoveAll(s => s.parent.DestroyedOrNull());

        public static bool HasActive(Map map) => 
            scanners.Any(s => s.parent.Map == map && s.ShouldShowDeepResourceOverlay());
    }

    [HarmonyPatch]
    public static class RegisterScanner_Patch {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(CompDeepScanner), MethodType.Constructor)]
        public static void RegisterScanner(CompDeepScanner __instance) {
            Scanners.Add(__instance);
        }
    }
}
