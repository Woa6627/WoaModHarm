using System;
using System.IO;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using WoaRepoMod;

namespace WoaModHarm;

[BepInPlugin("Woa.WoaRepoHarm", "WoaRepoHarm", "0.0.6")]
public class WoaModHarm : BaseUnityPlugin
{
    internal static WoaModHarm Instance { get; private set; } = null!;
    internal new static ManualLogSource Logger => Instance._logger;
    private ManualLogSource _logger => base.Logger;
    internal Harmony? Harmony { get; set; }
    public static System.Version? Version;
    public static AssetBundle mainMenuMusic = AssetBundle.LoadFromFile(Path.Combine(Paths.PluginPath, "mainmenumusic.woa"));
    public static AudioClip stealth = mainMenuMusic.LoadAsset<AudioClip>("msc main menu");
    public static AudioClip on_hover = mainMenuMusic.LoadAsset<AudioClip>("menu hover");
    public static AudioClip on_select = mainMenuMusic.LoadAsset<AudioClip>("menu select");
    public static AudioClip silence = mainMenuMusic.LoadAsset<AudioClip>("silence");
    public static AudioClip betrayal = mainMenuMusic.LoadAsset<AudioClip>("betrayal");
    public static AudioClip afghan = mainMenuMusic.LoadAsset<AudioClip>("hz_afghan");
    public static AudioClip special = mainMenuMusic.LoadAsset<AudioClip>("special");
    public static AudioClip txcr = mainMenuMusic.LoadAsset<AudioClip>("txcr");

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
        PlayerPatches(Harmony);
        UIPatchers(Harmony);
        NotifyPatchers(Harmony);
        EnemyPatchers(Harmony);
        AudioPatchers(Harmony);
    }

    static void NotifyPatchers(Harmony Harmony)
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

    static void UIPatchers(Harmony Harmony)
    {
        Harmony.PatchAll(typeof(GoalUIPatch));
        Harmony.PatchAll(typeof(BuildVersion));
        Harmony.PatchAll(typeof(LevelText));
    }

    static void PlayerPatches(Harmony Harmony)
    {
        Harmony.PatchAll(typeof(FlashlightControllerPatch));
        Harmony.PatchAll(typeof(SelfDestructionMessages));
        Harmony.PatchAll(typeof(PlayerControllerPatch));
    }

    static void AudioPatchers(Harmony Harmony)
    {
        Harmony.PatchAll(typeof(RemovePitch));
        Harmony.PatchAll(typeof(ConstantMusicPatch));
        Harmony.PatchAll(typeof(MenuManagerPatch));
    }

    static void EnemyPatchers(Harmony Harmony)
    {
        Harmony.PatchAll(typeof(EnemyHeadChaseOffsetPatch));
        Harmony.PatchAll(typeof(EnemyGnomePatch));
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