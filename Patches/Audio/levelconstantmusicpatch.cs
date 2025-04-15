using System;
using System.IO;
using BepInEx;
using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(ConstantMusic))]
public class ConstantMusicPatch
{

    public ConstantMusicPatch()
    {
        // load asset here
    }

    [HarmonyPrefix, HarmonyPatch(nameof(ConstantMusic.Setup))]
    public static bool ConstantMusicSetupPatch(ConstantMusic __instance)
    {
        try{

            if (!LevelGenerator.Instance.Level.ConstantMusicPreset)
            {
                __instance.gameObject.SetActive(false);
                return false;
            }
            AudioClip[] songs = {WoaModHarm.WoaModHarm.stealth, WoaModHarm.WoaModHarm.special, WoaModHarm.WoaModHarm.afghan, WoaModHarm.WoaModHarm.betrayal, WoaModHarm.WoaModHarm.txcr};
            int index = UnityEngine.Random.Range(0, songs.Length);
            __instance.clip = WoaModHarm.WoaModHarm.special;
            __instance.volume = LevelGenerator.Instance.Level.ConstantMusicPreset.volume;
            return false;
        }catch(Exception ex)
        {
            return true;
        }
    }
}
