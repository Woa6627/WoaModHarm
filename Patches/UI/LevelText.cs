using HarmonyLib;
using Steamworks.ServerList;
using TMPro;
using UnityEngine;

namespace WoaRepoMod;

[HarmonyPatch(typeof(LoadingUI))]
static class LevelText
{
    [HarmonyPostfix, HarmonyPatch(nameof(LoadingUI.LevelAnimationStart))]
    public static void Start_Prefix(LoadingUI __instance)
    {
        if(SemiFunc.RunIsLevel())
            __instance.levelNumberText.text = "<color=#32a852>LEVEL " + (RunManager.instance.levelsCompleted + 1).ToString() + "</color> Modded";
    }
}