using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(PlayerController))]
public class PlayerControllerPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(PlayerController.Update))]
    public static void PlayerControllerRegenSprint(PlayerController __instance)
    {
        __instance.sprintRechargeAmount = 20f;
        //__instance.SprintSpeed = 30f;
    }
}