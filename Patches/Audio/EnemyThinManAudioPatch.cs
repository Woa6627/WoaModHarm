using HarmonyLib;
using BepInEx;
using UnityEngine;

[HarmonyPatch(typeof(EnemyThinManAnim))]
public class EnemyThinManAudioPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyThinManAnim.Awake))]
    public static void EnemyThinManSFXPatch(EnemyThinManAnim __instance)
    {
        
    }
}