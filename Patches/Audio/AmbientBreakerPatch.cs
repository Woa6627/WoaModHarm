using HarmonyLib;
using BepInEx;
using UnityEngine;

[HarmonyPatch(typeof(AmbienceBreakers))]
public class AmbienceBreakersPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(AmbienceBreakers.Awake))]
    public static void AmbienceBreakersSFXPatch(AmbienceBreakers __instance)
    {
        __instance.sound.Sounds.AddItem(WoaModHarm.WoaModHarm.ambient_iseeu);
    }
}