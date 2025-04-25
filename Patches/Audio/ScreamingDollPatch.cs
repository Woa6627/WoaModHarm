using HarmonyLib;
using BepInEx;
using UnityEngine;

[HarmonyPatch(typeof(ScreamDollValuable))]
public class ScreamingDollPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(ScreamDollValuable.Start))]
    public static void DollSFXPatch(ScreamDollValuable __instance)
    {
        
        __instance.soundScreamLoop.Sounds[0] = WoaModHarm.Revo.doll_scream;
    }
}