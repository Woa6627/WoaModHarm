using HarmonyLib;
using BepInEx;
using UnityEngine;

[HarmonyPatch(typeof(EnemyHunter))]
public class EnemyHunterAudioPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyHunter.Awake))]
    public static void ShootSoundSfxPatch(EnemyHunter __instance)
    {
        
        __instance.soundShoot.Sounds[0] = WoaModHarm.Revo.huntsmanShotFired;
    }
}