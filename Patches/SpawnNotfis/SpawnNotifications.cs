using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(EnemyGnome))]
public class NotifyGnomeSpawn
{
    private static int gnomes = 0;
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyGnome.OnSpawn))]
    public static void OnEnemySpawnPatch(EnemyGnome __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer() && SemiFunc.EnemySpawn(__instance.enemy))
        {
            gnomes += 1;
            Debug.Log(gnomes + " Gnomes Spawned");
        }
    }
}

[HarmonyPatch(typeof(EnemyFloater))]
public class NotifyFloaterSpawn
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyFloater.OnSpawn))]
    public static void OnEnemySpawnPatch(EnemyFloater __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer() && SemiFunc.EnemySpawn(__instance.enemy))
        {
            Debug.Log("Floater Spawned");
        }
    }
}

[HarmonyPatch(typeof(EnemyRobe))]
public class NotifyRobeSpawn
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyRobe.OnSpawn))]
    public static void OnEnemySpawnPatch(EnemyRobe __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer() && SemiFunc.EnemySpawn(__instance.enemy))
        {
            Debug.Log("Robe Spawned");
        }
    }
}
[HarmonyPatch(typeof(EnemyHunter))]
public class NotifyHuntsManSpawn
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyHunter.OnSpawn))]
    public static void OnEnemySpawnPatch(EnemyHunter __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer() && SemiFunc.EnemySpawn(__instance.enemy))
        {
            Debug.Log("Hunter Spawned");
        }
    }
}

[HarmonyPatch(typeof(EnemySlowMouth))]
public class NotifySlowMouthSpawn
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemySlowMouth.OnSpawn))]
    public static void OnEnemySpawnPatch(EnemySlowMouth __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer() && SemiFunc.EnemySpawn(__instance.enemy))
        {
            Debug.Log("Slow Mouth Spawned");
        }
    }
}

[HarmonyPatch(typeof(EnemyAnimal))]
public class NotifyAnimalSpawn
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyAnimal.OnSpawn))]
    public static void OnEnemySpawnPatch(EnemyAnimal __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer() && SemiFunc.EnemySpawn(__instance.enemy))
        {
            Debug.Log("Animal Spawned");
        }
    }
}

[HarmonyPatch(typeof(EnemyHidden))]
public class NotifyHiddenSpawn
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyHidden.OnSpawn))]
    public static void OnEnemySpawnPatch(EnemyHidden __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer() && SemiFunc.EnemySpawn(__instance.enemy))
        {
            Debug.Log("Hidden Spawned");
        }
    }
}

[HarmonyPatch(typeof(EnemyHeadController))]
public class NotifyHeadmanSpawn
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyHeadController.OnSpawn))]
    public static void OnEnemySpawnPatch(EnemyHeadController __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer())
        {
            Debug.Log("HeadMan Spawned");
        }
    }
}

[HarmonyPatch(typeof(EnemyUpscream))]
public class NotifyUpScreamSpawn
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyUpscream.OnSpawn))]
    public static void OnEnemySpawnPatch(EnemyHeadController __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer())
        {
            Debug.Log("UpScream Spawned");
        }
    }
}

[HarmonyPatch(typeof(EnemyDuck))]
public class NotifyDuckSpawn
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyDuck.OnSpawn))]
    public static void OnEnemySpawnPatch(EnemyHeadController __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer())
        {
            Debug.Log("Duck Spawned");
        }
    }
}

[HarmonyPatch(typeof(EnemyCeilingEye))]
public class NotifyCeilingEyeSpawn
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyCeilingEye.OnSpawn))]
    public static void OnEnemySpawnPatch(EnemyHeadController __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer())
        {
            Debug.Log("Ceiling Eye Spawned");
        }
    }
}

[HarmonyPatch(typeof(EnemyThinMan))]
public class NotifyThinManSpawn
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyThinMan.OnSpawn))]
    public static void OnEnemySpawnPatch(EnemyHeadController __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer())
        {
            Debug.Log("ThinMan Spawned");
        }
    }
}

[HarmonyPatch(typeof(EnemyBang))]
public class NotifyBangSpawn
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyBang.OnSpawn))]
    public static void OnEnemySpawnPatch(EnemyHeadController __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer())
        {
            Debug.Log("Bang Spawned");
        }
    }
}

[HarmonyPatch(typeof(EnemyBeamer))]
public class NotifyBeamerSpawn
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyBang.OnSpawn))]
    public static void OnEnemySpawnPatch(EnemyHeadController __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer())
        {
            Debug.Log("Beamer Spawned");
        }
    }
}

[HarmonyPatch(typeof(EnemyBowtie))]
public class NotifyBowtieSpawn
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyBowtie.OnSpawn))]
    public static void OnEnemySpawnPatch(EnemyHeadController __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer())
        {
            Debug.Log("Bowtie Spawned");
        }
    }
}

[HarmonyPatch(typeof(EnemyTumbler))]
public class NotifyTumberSpawn
{
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyTumbler.OnSpawn))]
    public static void OnEnemySpawnPatch(EnemyHeadController __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer())
        {
            Debug.Log("Tumbler Spawned");
        }
    }
}
