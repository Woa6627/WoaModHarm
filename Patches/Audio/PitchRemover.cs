using HarmonyLib;
using BepInEx;
using UnityEngine;

[HarmonyPatch(typeof(Sound))]
public class RemovePitch
{
    [HarmonyPrefix, HarmonyPatch(nameof(Sound.Play))]
    public static bool PlayPatch(Sound __instance, Vector3 position, float volumeMultiplier, float falloffMultiplier, float offscreenVolumeMultiplier, float offscreenFalloffMultiplier, ref AudioSource __result)
    {
        volumeMultiplier = 1f;
        falloffMultiplier = 1f;
        offscreenVolumeMultiplier = 1f;
        offscreenFalloffMultiplier = 1f;
        if (__instance.Sounds.Length == 0)
		{
			return true;
		}
		AudioClip audioClip = __instance.Sounds[UnityEngine.Random.Range(0, __instance.Sounds.Length)];
		float num = 1f;//__instance.Pitch + UnityEngine.Random.Range(-__instance.PitchRandom, __instance.PitchRandom);
		AudioSource audioSource = __instance.Source;
		if (!audioSource)
		{
			GameObject gameObject = AudioManager.instance.AudioDefault;
			switch (__instance.Type)
			{
			case AudioManager.AudioType.HighFalloff:
				gameObject = AudioManager.instance.AudioHighFalloff;
				break;
			case AudioManager.AudioType.Footstep:
				gameObject = AudioManager.instance.AudioFootstep;
				break;
			case AudioManager.AudioType.MaterialImpact:
				gameObject = AudioManager.instance.AudioMaterialImpact;
				break;
			case AudioManager.AudioType.Cutscene:
				gameObject = AudioManager.instance.AudioCutscene;
				break;
			case AudioManager.AudioType.AmbienceBreaker:
				gameObject = AudioManager.instance.AudioAmbienceBreaker;
				break;
			case AudioManager.AudioType.LowFalloff:
				gameObject = AudioManager.instance.AudioLowFalloff;
				break;
			case AudioManager.AudioType.Global:
				gameObject = AudioManager.instance.AudioGlobal;
				break;
			case AudioManager.AudioType.HigherFalloff:
				gameObject = AudioManager.instance.AudioHigherFalloff;
				break;
			case AudioManager.AudioType.Attack:
				gameObject = AudioManager.instance.AudioAttack;
				break;
			case AudioManager.AudioType.Persistent:
				gameObject = AudioManager.instance.AudioPersistent;
				break;
			}
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameObject, position, Quaternion.identity, AudioManager.instance.SoundsParent);
			gameObject2.gameObject.name = audioClip.name;
			audioSource = gameObject2.GetComponent<AudioSource>();
			if (gameObject != AudioManager.instance.AudioPersistent)
			{
				UnityEngine.Object.Destroy(gameObject2, audioClip.length / num);
			}
		}
		else if (!audioSource.enabled)
		{
			return true;
		}
		audioSource.minDistance *= __instance.FalloffMultiplier;
		audioSource.minDistance *= falloffMultiplier;
		audioSource.maxDistance *= __instance.FalloffMultiplier;
		audioSource.maxDistance *= falloffMultiplier;
		audioSource.clip = __instance.Sounds[UnityEngine.Random.Range(0, __instance.Sounds.Length)];
		audioSource.volume = (__instance.Volume + UnityEngine.Random.Range(-__instance.VolumeRandom, __instance.VolumeRandom)) * volumeMultiplier;
		if (__instance.SpatialBlend > 0f && (__instance.OffscreenVolume * offscreenVolumeMultiplier < 1f || __instance.OffscreenFalloff * offscreenFalloffMultiplier < 1f) && !SemiFunc.OnScreen(audioSource.transform.position, 0.1f, 0.1f))
		{
			audioSource.volume *= __instance.OffscreenVolume * offscreenVolumeMultiplier;
			audioSource.minDistance *= __instance.OffscreenFalloff * offscreenFalloffMultiplier;
			audioSource.maxDistance *= __instance.OffscreenFalloff * offscreenFalloffMultiplier;
		}
		audioSource.spatialBlend = __instance.SpatialBlend;
		audioSource.reverbZoneMix = __instance.ReverbMix;
		audioSource.dopplerLevel = __instance.Doppler;
		audioSource.pitch = num;
		audioSource.loop = false;
		if (__instance.SpatialBlend > 0f)
		{
			__instance.StartLowPass(audioSource);
		}
		audioSource.Play();
        __result = audioSource;
		return false;
    }
}