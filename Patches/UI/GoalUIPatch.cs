using HarmonyLib;
using Unity.VisualScripting;
using UnityEngine;

[HarmonyPatch(typeof(GoalUI))]
public class GoalUIPatch : SemiUI
{
    [HarmonyPostfix, HarmonyPatch(nameof(GoalUI.Update))]
    public static void GUIP(GoalUI __instance)
    {
        int extractionPointsCompleted = RoundDirector.instance.extractionPointsCompleted;
        int extractionPoints = RoundDirector.instance.extractionPoints;
        __instance.Text.text = $"<color=#008000> <size=45>{extractionPointsCompleted}/{extractionPoints}</size> </color><b></b>";
    }
}