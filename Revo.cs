using System;
using System.IO;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using Unity.VisualScripting;
using UnityEngine;
using WoaRepoMod;

namespace WoaModHarm;

[BepInPlugin("Woa.Revo", "Revo", "0.1.8")]
public class Revo : BaseUnityPlugin
{
    internal static Revo Instance { get; private set; } = null!;
    internal new static ManualLogSource Logger => Instance._logger;
    private ManualLogSource _logger => base.Logger;
    internal Harmony Harmony { get; set; }
    public static System.Version Version;

    #region Music
    public static AssetBundle mainMenuMusic = AssetBundle.LoadFromFile(Path.Combine(Paths.PluginPath, "mainmenumusic.woa"));

    public static AudioClip stealth = mainMenuMusic.LoadAsset<AudioClip>("msc main menu");
    public static AudioClip on_hover = mainMenuMusic.LoadAsset<AudioClip>("menu hover");
    public static AudioClip on_select = mainMenuMusic.LoadAsset<AudioClip>("menu select");
    public static AudioClip silence = mainMenuMusic.LoadAsset<AudioClip>("silence");
    public static AudioClip betrayal = mainMenuMusic.LoadAsset<AudioClip>("betrayal");
    public static AudioClip afghan = mainMenuMusic.LoadAsset<AudioClip>("hz_afghan");
    public static AudioClip special = mainMenuMusic.LoadAsset<AudioClip>("special");
    public static AudioClip txcr = mainMenuMusic.LoadAsset<AudioClip>("txcr");
    public static AudioClip doll_scream = mainMenuMusic.LoadAsset<AudioClip>("spigun");
    public static AudioClip gramaphone_music = mainMenuMusic.LoadAsset<AudioClip>("gramaphone");
    #endregion

#region SFX
    public static AssetBundle sfx = AssetBundle.LoadFromFile(Path.Combine(Paths.PluginPath, "sfx.woa"));
    public static AudioClip huntsmanShotFired = sfx.LoadAsset<AudioClip>("slst");
    public static AudioClip a101 = sfx.LoadAsset<AudioClip>("a101");
    public static AudioClip a102 = sfx.LoadAsset<AudioClip>("a102");
    public static AudioClip a103 = sfx.LoadAsset<AudioClip>("a103");
    public static AudioClip a104 = sfx.LoadAsset<AudioClip>("a104");
    public static AudioClip a105 = sfx.LoadAsset<AudioClip>("a105");
    public static AudioClip a106 = sfx.LoadAsset<AudioClip>("a106");
    public static AudioClip a107 = sfx.LoadAsset<AudioClip>("a107");
    public static AudioClip a108 = sfx.LoadAsset<AudioClip>("a108");
    public static AudioClip FUCK = sfx.LoadAsset<AudioClip>("FUCK");
    public static AudioClip ambient_iseeu = sfx.LoadAsset<AudioClip>("potthinmanroam");
    public static AudioClip teethchatter1 = sfx.LoadAsset<AudioClip>("teethchatter1");
    public static AudioClip teethchatter2 = sfx.LoadAsset<AudioClip>("teethchatter2");
    public static AudioClip teethchatter3 = sfx.LoadAsset<AudioClip>("teethchatter3");
    public static AudioClip radioREQ = sfx.LoadAsset<AudioClip>("radioREQ");
    public static AudioClip ahhhhh = sfx.LoadAsset<AudioClip>("ahhhhhh");

#endregion


    private void Awake()
    {
        Instance = this;
        Version = Info.Metadata.Version;
        // Prevent the plugin from being deleted
        this.gameObject.transform.parent = null;
        this.gameObject.hideFlags = HideFlags.HideAndDontSave;
        Settings.mainmenumusic = Config.Bind("MUSIC", "mainmenumusic", true, "Enable or disable main menu music");
        Settings.mainmenusfx = Config.Bind("UI", "mainmenusfx", true, "Enable or disable UI sound effects");
        Settings.mainmenumusic = Config.Bind("GAME", "customsoundeffects", true, "Enable or disable custom sound effects");
        Logger.Log(LogLevel.Info, "Config File Path: "+ Config.ConfigFilePath);
        Patch();


        Logger.LogInfo($"{Info.Metadata.GUID} v{Info.Metadata.Version} has loaded!");
    }

    void Start()
    {
        Debug.Log("Loaded Start");
        GameObject UI = new GameObject("WoaUI");
        UI.AddComponent<WoaUI>();
        DontDestroyOnLoad(UI);
    }

    internal void Patch()
    {
        Harmony ??= new Harmony(Info.Metadata.GUID);
        PlayerPatches(Harmony);
        UIPatchers(Harmony);
        NotifyPatchers(Harmony);
        EnemyPatchers(Harmony);
        AudioPatchers(Harmony);
        ItemPatches(Harmony);
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
        Harmony.PatchAll(typeof(NotifyDuckSpawn));
        Harmony.PatchAll(typeof(NotifyBeamerSpawn));
        Harmony.PatchAll(typeof(NotifyThinManSpawn));
        Harmony.PatchAll(typeof(NotifyCeilingEyeSpawn));
        Harmony.PatchAll(typeof(NotifyUpScreamSpawn));
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
        //Harmony.PatchAll(typeof(RemovePitch));
        Harmony.PatchAll(typeof(ConstantMusicPatch));
        Harmony.PatchAll(typeof(MenuManagerPatch));
        Harmony.PatchAll(typeof(ScreamingDollPatch));
        Harmony.PatchAll(typeof(EnemyHunterAudioPatch));
        Harmony.PatchAll(typeof(EnemyDuckAudioPatch));
        Harmony.PatchAll(typeof(EnemyBeamerAudioPatch));
        Harmony.PatchAll(typeof(AmbienceBreakersPatch));
        Harmony.PatchAll(typeof(ItemDuckAudioPatch));
        Harmony.PatchAll(typeof(EnemyHeadManAudioPatch));
        Harmony.PatchAll(typeof(ValuableRadioAudioPatch));
        Harmony.PatchAll(typeof(ItemGramaphoneAudioPatch));
    }

    static void ItemPatches(Harmony Harmony)
    {
        Harmony.PatchAll(typeof(ItemHeartPotionPatch));
    }

    static void EnemyPatchers(Harmony Harmony)
    {
        Harmony.PatchAll(typeof(EnemyHeadChaseOffsetPatch));
        Harmony.PatchAll(typeof(EnemyGnomePatch));
        Harmony.PatchAll(typeof(EnemyHeadFloatPatch));
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