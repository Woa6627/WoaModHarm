using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(EnemyGnome))]
public class NotifyGnomeSpawn
{
    private static int gnomes = 0;
    [HarmonyPostfix, HarmonyPatch(nameof(EnemyGnome.OnSpawn))]
    public static void OnGnomeSpawn(EnemyGnome __instance)
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
    public static void OnGnomeSpawn(EnemyFloater __instance)
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
    public static void OnGnomeSpawn(EnemyRobe __instance)
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
    public static void OnGnomeSpawn(EnemyHunter __instance)
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
    public static void OnGnomeSpawn(EnemySlowMouth __instance)
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
    public static void OnGnomeSpawn(EnemyAnimal __instance)
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
    public static void OnHiddenSpawn(EnemyHidden __instance)
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
    public static void OnHeadManSpawn(EnemyHeadController __instance)
    {
        if(SemiFunc.IsMasterClientOrSingleplayer())
        {
            Debug.Log("HeadMan Spawned");
        }
    }
}