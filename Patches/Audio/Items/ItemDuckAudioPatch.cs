using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(ItemRubberDuck))]
public class ItemDuckAudioPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(ItemRubberDuck.Start))]
    public static void ItemDuckSFXPatch(ItemRubberDuck __instance)
    {
        __instance.soundQuack.Sounds[0] = WoaModHarm.WoaModHarm.FUCK;
    }
}