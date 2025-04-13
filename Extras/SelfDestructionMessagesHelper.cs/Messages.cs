using System.Collections.Generic;

namespace SDM;
public static class Messages
{
    public static List<string> GetMessages()
    {
        List<string> SDM_L = new List<string>();
        string[] array = {"KnobHeads", "Later Bitches", "Fuck Yall i am out", "I never loved you"};
        foreach(string message in array)
        {
            SDM_L.Add(message);
        }
        return SDM_L;
    }
}