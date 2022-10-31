using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace MountainPenetratingScanner {
    [HarmonyPatch(typeof(RoofGrid))]
    public static class RoofGrid_Patch {
        private static bool active = false;

        public static bool Active { 
            get => active; 
            set { 
                bool update = active != value;
                active = value;
                if (update) {
                    var grid = Find.CurrentMap.roofGrid;
                    grid.Drawer.SetDirty();
                    grid.RoofGridUpdate();
                }
            } 
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(RoofGrid.GetCellBool))]
        public static bool GetCellBool(bool result, int index, RoofDef[] ___roofGrid) {
            if (!result && Active) {
                return ___roofGrid[index] != null;
            } else {
                return result;
            }
        }
    }
}
