﻿using BattleTech;
using BattleTech.Save;
using Harmony;

namespace IRTweaks.Modules.Misc {

    // Resets all custom lances and units to allow a clean loading state
    [HarmonyPatch(typeof(CloudUserSettings), "PostDeserialize")]
    public static class SkirmishReset {

        public static bool Prepare() => Mod.Config.Fixes.SkirmishReset;

        public static void Prefix(
            ref LastUsedLances ___lastUsedLances,
            ref SkirmishUnitsAndLances ___customUnitsAndLances) {
            // Always reset the skirmish lances after serialization. This prevents the ever-spinny from missing mod pieces.
            Mod.Log.Info?.Write("Resetting used lances and custom units after PostDeserialize call.");
            ___lastUsedLances = new LastUsedLances();
            ___customUnitsAndLances = new SkirmishUnitsAndLances();
        }
    }
}
