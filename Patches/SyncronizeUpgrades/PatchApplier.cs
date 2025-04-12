using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(RunManager))]
public class RunManagerPatch
{
    [HarmonyPrefix, HarmonyPatch(nameof(RunManager.ChangeLevel))]
    private static void ChangeLevelPrefix()
    {
        SynchronizeUpgradesPatch.SynchronizeUpgrades(true);
    }


}

[HarmonyPatch(typeof(StatsManager))]
public class StatsManagerPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(StatsManager.ResetAllStats))]
    private static void ResetAllStatsPostFix()
    {
        SynchronizeUpgradesPatch.ResetPreviousMaxValues();
    }

    [HarmonyPrefix, HarmonyPatch(nameof(StatsManager.Update))]
    private static void UpdatePrefix()
    {
        SynchronizeUpgradesPatch.SynchronizeUpgrades(false);
    }
}