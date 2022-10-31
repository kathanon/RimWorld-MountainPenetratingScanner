using HarmonyLib;
using Verse;
using RimWorld;

namespace MountainPenetratingScanner
{
    [StaticConstructorOnStartup]
    public static class Main
    {
        static Main()
        {
            var harmony = new Harmony(Strings.ID);
            harmony.PatchAll();
        }
    }
}
