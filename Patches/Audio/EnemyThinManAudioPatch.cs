using HarmonyLib;
using BepInEx;
using UnityEngine;
using WoaModHarm;

[HarmonyPatch(typeof(EnemyThinManAnim))]
public class EnemyThinManAudioPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyThinManAnim.Awake))]
    public static void EnemyThinManSFXPatch(EnemyThinManAnim __instance)
    {
        __instance.teleportIn.Sounds[0] = Revo.PussyPoggerConverted;
    }
}