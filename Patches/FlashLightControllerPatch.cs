using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(FlashlightController))]
static class FlashlightControllerPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(FlashlightController.LightOn))]
    public static void LightOnPatch(FlashlightController __instance)
    {
        __instance.spotlight.color = Color.magenta;
        //__instance.spotlight.intensity = 0.15f;
        //__instance.spotlight.range = 5f;   
    }
}