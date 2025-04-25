using UnityEngine;
using System;

public class WoaUI : MonoBehaviour
{
    private bool showWindow = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.None))
        {
            showWindow = !showWindow;
        }
    }
    void OnGUI()
    {
        if(!showWindow) return;
    }
}