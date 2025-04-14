using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(FlashlightController))]
static class FlashlightControllerPatch
{

    [HarmonyPostfix, HarmonyPatch(nameof(FlashlightController.LightOn))]
    public static void LightOnPatch(FlashlightController __instance)
    {
        Color[] colors = {Color.blue, Color.cyan, Color.green, Color.magenta, Color.red};
        int i = UnityEngine.Random.Range(0, colors.Length);
        __instance.spotlight.color = colors[i];
        __instance.spotlight.range = 1000f;   
    }
}