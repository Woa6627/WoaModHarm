using System.Collections.Generic;
using HarmonyLib;


using Mono.Cecil;

[HarmonyPatch(typeof(ValuableLovePotion))]
public class ItemHeartPotionPatch
{
    [HarmonyPrefix, HarmonyPatch(nameof(ValuableLovePotion.GenerateAffectionateSentence))]
    public static bool GenerateAffectionateSentencePatch(ValuableLovePotion __instance, ref string __result)
    {
		List<string> list = new List<string>
		{
            "I wanna fuck {playername} so badly",
            "You are my heart,  my one and only thought {playerName}",
            "{playerName} makes me so wet a tsunami starts",
            "I could take {playerName} so deeply",
            "I have no gag reflex... {playerName}",
            "{playerName} will you be my Joe Goldberg?",
            "I am celibate, but i would 100% nut in {playerName}"
		};
		string text = list[UnityEngine.Random.Range(0, list.Count)];
		string text2 = text.Replace("{playerName}", __instance.playerName);
		__result = char.ToUpper(text2[0]).ToString() + text2.Substring(1);
		return false;
	}
    
}