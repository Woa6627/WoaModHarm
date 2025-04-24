using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(EnemyGnome))]
public class EnemyGnomePatch
{
    [HarmonyPrefix, HarmonyPatch(nameof(EnemyGnome.OnSpawn))]
    public static bool OnSpawnPrefix(EnemyGnome __instance)
    {
        if (SemiFunc.IsMasterClientOrSingleplayer() && SemiFunc.EnemySpawn(__instance.enemy))
		{
            WoaModHarm.Revo.Logger.LogDebug("Hijacked Gnome Spawner");
		}
        return false;
    }
}