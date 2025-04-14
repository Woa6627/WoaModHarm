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
        for(int i = 0; i < __instance.quackSound.Sounds.Length; i++)
        {
            __instance.quackSound.Sounds[i] = null;
        }
        __instance.quackSound.Sounds[0] = WoaModHarm.WoaModHarm.FUCK;
        __instance.noticeSound.Sounds[0] = WoaModHarm.WoaModHarm.FUCK;
    }
}