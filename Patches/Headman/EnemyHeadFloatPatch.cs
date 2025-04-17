using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;


[HarmonyPatch(typeof(EnemyHeadFloat))]
public class EnemyHeadFloatPatch
{
    static HashSet<EnemyHeadFloat> patched = new HashSet<EnemyHeadFloat>();

    [HarmonyPrefix, HarmonyPatch(nameof(EnemyHeadFloat.Update))]
    public static void EnemyHeadSpeedPatch(EnemyHeadFloat __instance)
    {
        // may not be what im looking for
        Debug.Log($"Overwriting base value SpeedPos: {__instance.SpeedPos} with new value 0.012f");
        if(!patched.Contains(__instance))
        {
            __instance.SpeedPos = 0.012f;
            patched.Add(__instance);
        }
    }
    
}