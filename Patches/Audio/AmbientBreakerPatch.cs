using HarmonyLib;
using BepInEx;
using UnityEngine;

[HarmonyPatch(typeof(AmbienceBreakers))]
public class AmbienceBreakersPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(AmbienceBreakers.Start))]
    public static void AmbienceBreakersSFXPatch(AmbienceBreakers __instance)
    {

        __instance.sound.Sounds.AddItem(WoaModHarm.Revo.ambient_iseeu);
    }
}