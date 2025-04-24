using HarmonyLib;
using BepInEx;
using UnityEngine;
using UnityEngine.Rendering;

[HarmonyPatch(typeof(EnemyDuckAnim))]
public class EnemyDuckAudioPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyDuckAnim.Awake))]
    public static void DuckSFXPatch(EnemyDuckAnim __instance)
    {
        if(Settings.customsfx.Value)
        {
            __instance.quackSound.Sounds[0] = WoaModHarm.Revo.FUCK;
            __instance.quackSound.Sounds[1] = WoaModHarm.Revo.FUCK;
            __instance.quackSound.Sounds[2] = WoaModHarm.Revo.FUCK;
            __instance.noticeSound.Sounds[0] = WoaModHarm.Revo.FUCK;
        }
    }
}