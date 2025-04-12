using System;
using HarmonyLib;
using TMPro;
using UnityEngine;

[HarmonyPatch(typeof(HaulUI))]
public class HaulModify : SemiUI
{
    //[HarmonyPrefix, HarmonyPatch(nameof(HaulUI.Start))]
    public static bool ModifyStart(HaulUI __instance)
    {
        __instance.Text = __instance.GetComponent<TextMeshProUGUI>();
        
        return false;
    }

    [HarmonyPrefix, HarmonyPatch(nameof(HaulUI.Update))]
    public static bool ModifyPostFix(HaulUI __instance)
    {
        try{
            //Debug.Log("Patching Update");
            
            string text2;
            if (SemiFunc.RunIsLevel())
            {
                if (!RoundDirector.instance.extractionPointActive)
                {
                    __instance.Hide();
                }
                int num = RoundDirector.instance.currentHaul;
                int extractionHaulGoal = RoundDirector.instance.extractionHaulGoal;
                num = Mathf.Max(0, num);
                __instance.currentHaulValue = num;
                string text = "<color=#4feb34>$</color>";
                text2 = string.Concat(new string[]
                {
                    "<size=30>",
                    text,
                    SemiFunc.DollarGetString(num),
                    "<color=#4feb34> <size=45>/</size> </color>",
                    text,
                    "<u>",
                    SemiFunc.DollarGetString(extractionHaulGoal)
                });
                if (__instance.currentHaulValue > __instance.prevHaulValue)
                {
                    __instance.SemiUISpringShakeY(10f, 10f, 0.3f);
                    __instance.SemiUISpringScale(0.05f, 5f, 0.2f);
                    __instance.SemiUITextFlashColor(Color.green, 0.2f);
                    __instance.prevHaulValue = __instance.currentHaulValue;
                }
                if (__instance.currentHaulValue < __instance.prevHaulValue)
                {
                    __instance.SemiUISpringShakeY(10f, 10f, 0.3f);
                    __instance.SemiUISpringScale(0.05f, 5f, 0.2f);
                    __instance.SemiUITextFlashColor(Color.red, 0.2f);
                    __instance.prevHaulValue = __instance.currentHaulValue;
                }
                __instance.Text.ForceMeshUpdate();
            }
            else
            {
                text2 = SemiFunc.DollarGetString(SemiFunc.StatGetRunCurrency());
                __instance.Hide();
            }
            __instance.Text.text = text2;
            //Debug.Log("Updated Haul UI Text: " + text2);
            return false;
            
            
        } catch(Exception ex)
        {
            Debug.Log(ex.Message);
            return true;
            
        }
    }
}
