using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Events;

[HarmonyPatch(typeof(ChatManager))]
public static class SelfDestructionMessages
{
    [HarmonyPrefix, HarmonyPatch(nameof(ChatManager.PossessSelfDestruction))]
    public static bool PossessSelfDestructionPatch()
    {
        var __instance = AccessTools.Field(typeof(ChatManager), "instance").GetValue(null) as ChatManager;
        if (!__instance?.playerAvatar)
		{
			return false;
		}
		if (__instance.playerAvatar.isDisabled)
		{
			return false;
		}
		__instance.PossessChatScheduleStart(-1);
		UnityEvent unityEvent = new UnityEvent();
		unityEvent.AddListener(new UnityAction(__instance.SelfDestruct));
		string message = SDM.Messages.GetMessages()[Random.Range(0, SDM.Messages.GetMessages().Count)];
		__instance.PossessChat(ChatManager.PossessChatID.SelfDestruct, message, 2f, Color.red, 0f, true, 2, unityEvent);
		__instance.PossessChatScheduleEnd();
        return false;
    }
}