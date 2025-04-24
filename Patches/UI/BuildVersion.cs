using HarmonyLib;
using TMPro;
using UnityEngine;
using WoaModHarm;

[HarmonyPatch(typeof(BuildName))]
public static class BuildVersion
{
    [HarmonyPostfix, HarmonyPatch(nameof(BuildName.Start))]
    static void PostFix(BuildName __instance)
    {
        Debug.Log("Postfix for BuildName.Start() applied");
        __instance.GetComponent<TextMeshProUGUI>().alpha = 1f;
        __instance.GetComponent<TextMeshProUGUI>().text = "Version: " + BuildManager.instance.version.title + " - <size=10>R.E.V.O Version: " + Revo.Version.ToString() + "</size>";
    }
}