using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(EnemyHeadAnimationSystem))]
public class EnemyHeadManAudioPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyHeadAnimationSystem.Awake))]
    public static void EnemyHeadSFXPatch(EnemyHeadAnimationSystem __instance)
    {
        __instance.TeethChatter.Sounds[0] = WoaModHarm.WoaModHarm.teethchatter1;
        __instance.TeethChatter.Sounds[1] = WoaModHarm.WoaModHarm.teethchatter2;
        __instance.TeethChatter.Sounds[2] = WoaModHarm.WoaModHarm.teethchatter3;
        __instance.TeethChatter.Sounds[3] = WoaModHarm.WoaModHarm.ahhhhh;
        //__instance.TeethChatter.Sounds[4] = null;
    }
}