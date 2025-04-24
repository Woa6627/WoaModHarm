using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(TrapRadio))]
public class ValuableRadioAudioPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(TrapRadio.Start))]
    public static void TrapRadioSFXLOOPPatch(TrapRadio __instance)
    {
        if(Settings.customsfx.Value)
            __instance.RadioLoop.Sounds[0] = WoaModHarm.Revo.radioREQ;
    }
}