using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(EnemyHeadChaseOffset))]
public class EnemyHeadChaseOffsetPatch
{
    [HarmonyPrefix, HarmonyPatch(nameof(EnemyHeadChaseOffset.Update))]
    public static bool UpdatePatch(EnemyHeadChaseOffset __instance)
    {
        __instance.Lerp = 0.25f;
        if (__instance.Enemy.CurrentState == EnemyState.Chase || __instance.Enemy.CurrentState == EnemyState.ChaseSlow)
		{
			if (__instance.Lerp <= 0f || __instance.Lerp >= 1f)
			{
				__instance.Active = true;
			}
		}
		else if (__instance.Lerp <= 0f || __instance.Lerp >= 1f)
		{
			__instance.Active = false;
		}
		if (__instance.Active)
		{
			__instance.Lerp += Time.deltaTime * 0.1f;
		}
		else
		{
			__instance.Lerp -= Time.deltaTime * 0.1f;
		}
		__instance.Lerp = Mathf.Clamp01(__instance.Lerp);
		if (__instance.Active)
		{
			__instance.transform.localRotation = Quaternion.SlerpUnclamped(Quaternion.identity, Quaternion.Euler(__instance.Offset), __instance.IntroCurve.Evaluate(__instance.Lerp));
			return false;
		}
		__instance.transform.localRotation = Quaternion.SlerpUnclamped(Quaternion.identity, Quaternion.Euler(__instance.Offset), __instance.OutroCurve.Evaluate(__instance.Lerp));
        return false;
    }
}