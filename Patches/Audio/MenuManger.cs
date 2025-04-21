using HarmonyLib;
using BepInEx;
using UnityEngine;

[HarmonyPatch(typeof(MenuManager))]
public class MenuManagerPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(MenuManager.Start))]
    public static void StartPatch(MenuManager __instance)
    {
        if(Settings.mainmenusfx.Value)
        {
            __instance.soundHover.Sounds[0] = WoaModHarm.WoaModHarm.on_hover;
            __instance.soundConfirm.Sounds[0] = WoaModHarm.WoaModHarm.on_select;
            __instance.soundDeny.Sounds[0] = WoaModHarm.WoaModHarm.silence;
            __instance.soundAction.Sounds[0] = WoaModHarm.WoaModHarm.on_select;
            __instance.soundTick.Sounds[0] = WoaModHarm.WoaModHarm.silence;
            __instance.soundDud.Sounds[0] = WoaModHarm.WoaModHarm.silence;
            __instance.soundPageOutro.Sounds[0] = WoaModHarm.WoaModHarm.on_select;
            __instance.soundPageIntro.Sounds[0] = WoaModHarm.WoaModHarm.on_select;
            __instance.soundWindowPopUp.Sounds[0] = WoaModHarm.WoaModHarm.on_select;
            __instance.soundWindowPopUpClose.Sounds[0] = WoaModHarm.WoaModHarm.on_select;
            __instance.soundMove.Sounds[0] = WoaModHarm.WoaModHarm.on_select;
        }
    }

    [HarmonyPrefix, HarmonyPatch(nameof(MenuManager.MenuEffectHover))]
    public static bool MenuHoverEffect(MenuManager __instance, float pitch, float volume)
    {

		__instance.soundHover.Pitch = pitch;
		
		if (volume != -1f)
		{
			__instance.soundHover.Volume = volume;
		}
		__instance.soundHover.Play(__instance.transform.position, 1f, 1f, 1f, 1f);
        return false;
    }
}