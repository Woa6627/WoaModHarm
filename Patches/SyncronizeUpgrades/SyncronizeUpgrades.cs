using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;
using Photon.Pun;
using System.Linq;
using System;

public class SynchronizeUpgradesPatch
{
    private static Dictionary<string, int> previousMaxValues = new Dictionary<string, int>();
    internal static void SynchronizeUpgrades(bool forced = false)
    {
        try
        {
            bool flag = LevelGenerator.Instance.Generated && !SemiFunc.MenuLevel() && PhotonNetwork.IsMasterClient;
            if (flag)
            {
                StatsManager instance = StatsManager.instance;
                Dictionary<string, Dictionary<string, int>> dictionaryOfDictionaries = instance.dictionaryOfDictionaries;
                List<string> list = (from key in dictionaryOfDictionaries.Keys
                where key.StartsWith("playerUpgrade")
                select key).ToList<string>();
                WoaModHarm.WoaModHarm.Logger.LogDebug("Found upgrade keys: " + string.Join(", ", list));
                Dictionary<string, int> dictionary = new Dictionary<string, int>();
                foreach (string text in list)
                {
                    Dictionary<string, int> dictionary2;
                    bool flag2 = dictionaryOfDictionaries.TryGetValue(text, out dictionary2) && dictionary2.Count > 0;
                    if (flag2)
                    {
                        int num = dictionary2.Values.Max();
                        dictionary[text] = num;
                        WoaModHarm.WoaModHarm.Logger.LogDebug(string.Format("Calculated max value for {0}: {1}", text, num));
                    }
                    else
                    {
                        WoaModHarm.WoaModHarm.Logger.LogDebug("No upgrades found for key " + text + ".");
                    }
                }
                bool flag3 = false;
                bool flag4 = !forced;
                if (flag4)
                {
                    WoaModHarm.WoaModHarm.Logger.LogDebug("Current max values: " + string.Join<KeyValuePair<string, int>>(", ", dictionary));
                    WoaModHarm.WoaModHarm.Logger.LogDebug("Previous max values: " + string.Join<KeyValuePair<string, int>>(", ", SynchronizeUpgradesPatch.previousMaxValues));
                    bool flag5 = dictionary.Any(delegate(KeyValuePair<string, int> kv)
                    {
                        int num2;
                        return !SynchronizeUpgradesPatch.previousMaxValues.TryGetValue(kv.Key, out num2) || num2 != kv.Value;
                    });
                    bool flag6 = flag5;
                    if (flag6)
                    {
                        WoaModHarm.WoaModHarm.Logger.LogDebug("Upgrade values have changed, applying updates.");
                        flag3 = true;
                    }
                    else
                    {
                        WoaModHarm.WoaModHarm.Logger.LogDebug("No upgrade values changed, skipping update.");
                    }
                }
                else
                {
                    WoaModHarm.WoaModHarm.Logger.LogDebug("Forced upgrades synchronization due to level change.");
                    flag3 = true;
                }
                bool flag7 = flag3;
                if (flag7)
                {
                    foreach (KeyValuePair<string, int> keyValuePair in dictionary)
                    {
                        WoaModHarm.WoaModHarm.Logger.LogDebug(string.Format("Updating upgrade {0} with value {1}.", keyValuePair.Key, keyValuePair.Value));
                        instance.DictionaryFill(keyValuePair.Key, keyValuePair.Value);
                    }
                    bool flag8 = !forced;
                    if (flag8)
                    {
                        SemiFunc.StatSyncAll();
                        WoaModHarm.WoaModHarm.Logger.LogDebug("StatSyncAll called.");
                    }
                    SynchronizeUpgradesPatch.previousMaxValues = new Dictionary<string, int>(dictionary);
                    WoaModHarm.WoaModHarm.Logger.LogDebug("Updated previousMaxValues for next iteration.");
                    WoaModHarm.WoaModHarm.Logger.LogInfo("Upgrades synced for all players.");
                }
            }
            }
            catch (Exception ex)
            {
                SynchronizeUpgradesPatch.LogException(ex);
                throw;
            }   
    }
    
        private static void LogException(Exception ex)
		{
			bool flag = ex != null;
			if (flag)
			{
				WoaModHarm.WoaModHarm.Logger.LogDebug(string.Concat(new string[]
				{
					"Exception caught: ",
					ex.GetType().FullName,
					" - ",
					ex.Message,
					"\nStackTrace: ",
					ex.StackTrace
				}));
				bool flag2 = ex.InnerException != null;
				if (flag2)
				{
					WoaModHarm.WoaModHarm.Logger.LogDebug("Inner exception:");
					SynchronizeUpgradesPatch.LogException(ex.InnerException);
				}
			}
		}
        internal static void ResetPreviousMaxValues()
		{
			bool isMasterClient = PhotonNetwork.IsMasterClient;
			if (isMasterClient)
			{
				SynchronizeUpgradesPatch.previousMaxValues.Clear();
				WoaModHarm.WoaModHarm.Logger.LogInfo("Previous max upgrades values reseted.");
			}
		}

}
