using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using WoaRepoMod;

namespace WoaModHarm;

[BepInPlugin("Woa.WoaRepoHarm", "WoaRepoHarm", "1.0.1")]
public class WoaModHarm : BaseUnityPlugin
{
    internal static WoaModHarm Instance { get; private set; } = null!;
    internal new static ManualLogSource Logger => Instance._logger;
    private ManualLogSource _logger => base.Logger;
    internal Harmony? Harmony { get; set; }
    public static System.Version? Version;

    private void Awake()
    {
        Instance = this;
        Version = Info.Metadata.Version;
        // Prevent the plugin from being deleted
        this.gameObject.transform.parent = null;
        this.gameObject.hideFlags = HideFlags.HideAndDontSave;
        

        Patch();

        Logger.LogInfo($"{Info.Metadata.GUID} v{Info.Metadata.Version} has loaded!");
    }

    internal void Patch()
    {
        Harmony ??= new Harmony(Info.Metadata.GUID);
        Harmony.PatchAll(typeof(LevelText));
        Harmony.PatchAll(typeof(BuildVersion));
        Harmony.PatchAll(typeof(FlashlightControllerPatch));
        Harmony.PatchAll(typeof(SelfDestructionMessages));
        Harmony.PatchAll(typeof(PlayerControllerPatch));
        Harmony.PatchAll(typeof(EnemyHeadChaseOffsetPatch));
        NotifyPatchers(Harmony);
    }

    internal void NotifyPatchers(Harmony Harmony)
    {
        Harmony.PatchAll(typeof(NotifyGnomeSpawn));
        Harmony.PatchAll(typeof(NotifyHuntsManSpawn));
        Harmony.PatchAll(typeof(NotifyAnimalSpawn));
        Harmony.PatchAll(typeof(NotifyFloaterSpawn));
        Harmony.PatchAll(typeof(NotifyRobeSpawn));
        Harmony.PatchAll(typeof(NotifySlowMouthSpawn));
        Harmony.PatchAll(typeof(NotifyHeadmanSpawn));
        Harmony.PatchAll(typeof(NotifyHiddenSpawn));
    }
    internal void Unpatch()
    {
        Harmony?.UnpatchSelf();
    }

    private void Update()
    {
        // Code that runs every frame goes here
    }
}