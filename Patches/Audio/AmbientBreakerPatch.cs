using HarmonyLib;
using BepInEx;
using UnityEngine;

[HarmonyPatch(typeof(AmbienceBreakers))]
public class AmbienceBreakersPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(AmbienceBreakers.Start))]
    public static void AmbienceBreakersSFXPatch(AmbienceBreakers __instance)
    {
        if(Settings.customsfx.Value)
            __instance.sound.Sounds.AddItem(WoaModHarm.WoaModHarm.ambient_iseeu);
    }
}