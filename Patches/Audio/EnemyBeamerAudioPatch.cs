using HarmonyLib;
using BepInEx;
using UnityEngine;

[HarmonyPatch(typeof(EnemyBeamerAnim))]
public class EnemyBeamerAudioPatch
{
    [HarmonyPrefix, HarmonyPatch(nameof(EnemyBeamerAnim.AttackIntro))]
    public static void BeamerSFXPatch(EnemyBeamerAnim __instance)
    {
        AudioClip[] clips = {
            WoaModHarm.WoaModHarm.a101,
            WoaModHarm.WoaModHarm.a102,
            WoaModHarm.WoaModHarm.a103,
            WoaModHarm.WoaModHarm.a104,
            WoaModHarm.WoaModHarm.a105,
            WoaModHarm.WoaModHarm.a106,
            WoaModHarm.WoaModHarm.a107,
            WoaModHarm.WoaModHarm.a108
        };
        int index = UnityEngine.Random.Range(0, clips.Length);
        __instance.soundAttackLoop.Sounds[0] = clips[index];
        __instance.soundAttackIntro.Sounds[0] = clips[index];
        __instance.soundAttackOutro.Sounds[0] = clips[index];
    }
}