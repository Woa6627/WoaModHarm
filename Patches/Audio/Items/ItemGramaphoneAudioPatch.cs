using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(TrapGramophone))]
public class ItemGramaphoneAudioPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(TrapGramophone.Start))]
    public static void GramaphoneAudioPatch(TrapGramophone __instance)
    {
        __instance.GramophoneMusic.Sounds[0] = WoaModHarm.Revo.gramaphone_music;
    }
}