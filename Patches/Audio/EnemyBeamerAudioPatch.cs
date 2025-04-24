using HarmonyLib;
using BepInEx;
using UnityEngine;
using WoaModHarm;

[HarmonyPatch(typeof(EnemyBeamerAnim))]
public class EnemyBeamerAudioPatch
{
    [HarmonyPrefix, HarmonyPatch(nameof(EnemyBeamerAnim.AttackIntro))]
    public static void BeamerSFXPatch(EnemyBeamerAnim __instance)
    {
        AudioClip[] clips = {
            Revo.a101,
            Revo.a102,
            Revo.a103,
            Revo.a104,
            Revo.a105,
            Revo.a106,
            Revo.a107,
            Revo.a108
        };
        int index = UnityEngine.Random.Range(0, clips.Length);
        if(Settings.customsfx.Value)
        {
            __instance.soundAttackLoop.Sounds[0] = clips[index];
            __instance.soundAttackIntro.Sounds[0] = clips[index];
            __instance.soundAttackOutro.Sounds[0] = clips[index];
        }

    }
}