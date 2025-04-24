using System;
using System.IO;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using Microsoft.Extensions.Configuration;
using BepInEx.Configuration;
using WoaModHarm;
#pragma warning disable CS8618


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
            if(!Settings.mainmenumusic.Value) return true;
            if (!LevelGenerator.Instance.Level.ConstantMusicPreset)
            {
                __instance.gameObject.SetActive(false);
                return false;
            }
            AudioClip[] songs = {Revo.stealth, Revo.special, Revo.afghan, Revo.betrayal, Revo.txcr};
            int index = UnityEngine.Random.Range(0, songs.Length);
            __instance.clip = Revo.special;
            __instance.volume = LevelGenerator.Instance.Level.ConstantMusicPreset.volume;
            return false;
        }catch(Exception ex)
        {
            Revo.Logger.Log(BepInEx.Logging.LogLevel.Error, ex.Message);
            return true;
        }
    }
}
