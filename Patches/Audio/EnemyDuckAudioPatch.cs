using HarmonyLib;
using BepInEx;
using UnityEngine;

[HarmonyPatch(typeof(EnemyDuckAnim))]
public class EnemyDuckAudioPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyDuckAnim.Awake))]
    public static void DuckSFXPatch(EnemyDuckAnim __instance)
    {
        __instance.quackSound.Sounds[0] = WoaModHarm.WoaModHarm.FUCK;
    }
}